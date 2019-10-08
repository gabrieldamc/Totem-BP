using Camera_NET;
using DirectShowLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public partial class CaptureWebCamcs : Form
    {
        private CameraChoice _CameraChoice = new CameraChoice();
        private bool _bZoomed = false;
        private double _fZoomValue = 1.0;
        public Bitmap _latestFrame;
        int timeout = 30;
        DateTime start = DateTime.Now;
        private NormalizedRect _MouseSelectionRect = new NormalizedRect(0, 0, 0, 0);
        private bool _bDrawMouseSelection = false;
        public Bitmap bitmap;
        int camera_idx = 1;
        private bool isRead = false;
        private DateTime start_captura;
        WebcamConfig wc = new WebcamConfig();
        public bool IsRead
        {
            get { return isRead; }
            set
            {
                isRead = value;
                OnIsReadChanged();
            }
        }
        private void OnIsReadChanged()
        {

        }
        public CaptureWebCamcs(int _cameraidx, int v)
        {
            timeout = v;
            camera_idx = _cameraidx;
            InitializeComponent();
            progressBar1.Maximum = v * 1000;
            progressBar1.Value = v * 1000;
        }

        private void CaptureWebCamcs_Load(object sender, EventArgs e)
        {
            try
            {
                setmaxres(camera_idx);
            }
            catch { }
            start_captura = DateTime.Now;

            start = DateTime.Now;
            timer.Start();
        }
        private void setmaxres(int CamIdx)
        {
            _CameraChoice.UpdateDeviceList();

            SetCamera(_CameraChoice.Devices[CamIdx].Mon,
                new Resolution(wc.Resolution.Width, wc.Resolution.Height));

            if (!cameraControl.CameraCreated)
                return;
            set_camera_par(CamIdx, wc);
            cameraControl.MixerEnabled = false;
            ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);
            Resolution res = new Resolution(800, 600);
            foreach (var r in resolutions)
            {
                if (r.Width > res.Width)
                {
                    res = r;
                }
            }            
        }
        private void set_camera_par(int CamIdx, WebcamConfig wc)
        {
            if (new FilterGraph() is IFilterGraph2 graphBuilder)
            {
                graphBuilder.AddSourceFilterForMoniker(_CameraChoice.Devices[CamIdx].Mon, null, _CameraChoice.Devices[CamIdx].Name, out IBaseFilter capFilter);

                ResolutionList resolutions = Camera.GetResolutionList(cameraControl.Moniker);
                Resolution res = new Resolution(800, 600);
                foreach (var r in resolutions)
                {
                    if (r.Width > res.Width)
                    {
                        res = r;
                    }
                }

                bool new_config = false;
                wc.config_salvar_valor("Resolution", res.Width + "X" + res.Height);
                if (wc.Resolution.Width != res.Width && wc.Resolution.Height != res.Height)
                {
                    new_config = true;
                }
                string n_cam = _CameraChoice.Devices[CamIdx].Name;
                if (n_cam != wc.WebcamName)
                {
                    new_config = true;
                    wc.config_salvar_valor("WebcamName", _CameraChoice.Devices[CamIdx].Name);
                }


                IAMCameraControl _camera = capFilter as IAMCameraControl;
                _camera.Get(CameraControlProperty.Focus, out int v, out CameraControlFlags f);
                if (f != CameraControlFlags.None)
                {
                    if (new_config)
                    {
                        if (n_cam.Contains("Brio"))
                        {
                            _camera.Set(CameraControlProperty.Focus, 115, CameraControlFlags.Manual);
                            wc.config_salvar_valor("Focus", "115");
                        }
                    }
                    else
                    {
                        if (wc.Focus == "Auto")
                        {
                            _camera.Set(CameraControlProperty.Focus, 115, CameraControlFlags.Auto);
                        }
                        else
                        {
                            _camera.Set(CameraControlProperty.Focus, Convert.ToInt32(wc.Focus), CameraControlFlags.Manual);
                        }

                    }

                }
                //_camera.Set(CameraControlProperty.Zoom, wc.Zoom, CameraControlFlags.Manual);

                _camera.Get(CameraControlProperty.Exposure, out int v1, out CameraControlFlags f1);
                IAMVideoProcAmp _cameraVP = capFilter as IAMVideoProcAmp;
                int rMin, rMax, rDelta, rDeflt;
                VideoProcAmpFlags vflag;

                if (new_config)
                {
                    _cameraVP.GetRange(VideoProcAmpProperty.Contrast, out rMin, out rMax, out rDelta, out rDeflt, out vflag);

                    wc.config_salvar_valor("Contrast", rDeflt.ToString());
                    _cameraVP.Set(VideoProcAmpProperty.Contrast, rDeflt, VideoProcAmpFlags.Manual);
                    _cameraVP.GetRange(VideoProcAmpProperty.Brightness, out rMin, out rMax, out rDelta, out rDeflt, out vflag);
                    wc.config_salvar_valor("Brightness", (rDeflt).ToString());
                    _cameraVP.Set(VideoProcAmpProperty.Brightness, rDeflt, VideoProcAmpFlags.Manual);
                    _cameraVP.GetRange(VideoProcAmpProperty.BacklightCompensation, out rMin, out rMax, out rDelta, out rDeflt, out vflag);
                    wc.config_salvar_valor("BacklightCompensation", (rDeflt).ToString());
                    _cameraVP.GetRange(VideoProcAmpProperty.Gain, out rMin, out rMax, out rDelta, out rDeflt, out vflag);
                    wc.config_salvar_valor("Gain", (rDeflt).ToString());
                    _cameraVP.GetRange(VideoProcAmpProperty.Gamma, out rMin, out rMax, out rDelta, out rDeflt, out vflag);
                    wc.config_salvar_valor("Gamma", (rDeflt).ToString());
                }
                else
                {
                    _cameraVP.Set(VideoProcAmpProperty.Contrast, wc.Contrast, VideoProcAmpFlags.Manual);
                    _cameraVP.Set(VideoProcAmpProperty.Brightness, wc.Brightness, VideoProcAmpFlags.Manual);
                    _cameraVP.Set(VideoProcAmpProperty.BacklightCompensation, wc.BacklightCompensation, VideoProcAmpFlags.Auto);
                    _cameraVP.Set(VideoProcAmpProperty.Gain, wc.Gain, VideoProcAmpFlags.Manual);
                    _cameraVP.Set(VideoProcAmpProperty.Gamma, wc.Gamma, VideoProcAmpFlags.Manual);
                }
            }
        }
        private void SetCamera(IMoniker camera_moniker, Resolution resolution)
        {
            try
            {
                //cameraControl.DirectShowLogFilepath = @"C:\YOUR\LOG\PATH.txt";

                cameraControl.SetCamera(camera_moniker, resolution);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Erro ao iniciar o scanner");
                if (e.Message == "Camera doesn't support media type with requested resolution and bits per pixel.")
                {
                    wc.config_salvar_valor("WebcamName", "----");
                }
            }

            if (!cameraControl.CameraCreated)
                return;
            cameraControl.MixerEnabled = true;
            cameraControl.OutputVideoSizeChanged += Camera_OutputVideoSizeChanged;
            UpdateCameraBitmap();
        }
        private void Camera_OutputVideoSizeChanged(object sender, EventArgs e)
        {
            UpdateCameraBitmap();
        }

        private void UpdateCameraBitmap()
        {
            if (!cameraControl.MixerEnabled)
                return;

            cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);

            #region D3D bitmap mixer
            //if (cameraControl.UseGDI)
            //{
            //    cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);
            //}
            //else
            //{
            //    cameraControl.OverlayBitmap = GenerateAlphaBitmap();
            //}
            #endregion
        }
        private Bitmap GenerateColorKeyBitmap(bool useAntiAlias)
        {
            int w = cameraControl.OutputVideoSize.Width;
            int h = cameraControl.OutputVideoSize.Height;

            if (w <= 0 || h <= 0)
                return null;

            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(bmp);
            if (useAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            else
            {
                g.SmoothingMode = SmoothingMode.None;
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            }

            // Clear the bitmap with the color key
            g.Clear(cameraControl.GDIColorKey);

            // Draw selection rect --------------------------
            if (_bDrawMouseSelection && IsMouseSelectionRectCorrect())
            {
                Color color_of_pen = Color.Gray;
                if (IsMouseSelectionRectCorrectAndGood())
                {
                    color_of_pen = Color.Green;
                }

                Pen pen = new Pen(color_of_pen, 2.0f);

                Rectangle rect = new Rectangle(
                        (int)(_MouseSelectionRect.left * w),
                        (int)(_MouseSelectionRect.top * h),
                        (int)((_MouseSelectionRect.right - _MouseSelectionRect.left) * w),
                        (int)((_MouseSelectionRect.bottom - _MouseSelectionRect.top) * h)
                    );
                g.DrawLine(pen, rect.Left - 5, rect.Top, rect.Right + 5, rect.Top);
                g.DrawLine(pen, rect.Left - 5, rect.Bottom, rect.Right + 5, rect.Bottom);
                g.DrawLine(pen, rect.Left, rect.Top - 5, rect.Left, rect.Bottom + 5);
                g.DrawLine(pen, rect.Right, rect.Top - 5, rect.Right, rect.Bottom + 5);
                pen.Dispose();
            }

            // Draw zoom text if needed
            if (_bZoomed)
            {
                Font font = new Font("Tahoma", 16);
                Brush textColorKeyed = new SolidBrush(Color.DarkBlue);
                g.DrawString("Zoom: " + Math.Round(_fZoomValue, 1).ToString("0.0") + "x", font, textColorKeyed, 4, 4);
                font.Dispose();
                textColorKeyed.Dispose();
            }
            {
                Font font = new Font("Tahoma", 16);
                Brush textColorKeyed = new SolidBrush(Color.Black);
            }


            // dispose Graphics
            g.Dispose();

            // return the bitmap
            return bmp;
        }
        private bool IsMouseSelectionRectCorrectAndGood()
        {
            if (!IsMouseSelectionRectCorrect())
            {
                return false;

            }

            // Zoom
            if (Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < 0.1f ||
                Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < 0.1f)
            {
                return false;
            }

            return true;
        }

        private bool IsMouseSelectionRectCorrect()
        {
            if (Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < float.Epsilon * 10 ||
                Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < float.Epsilon * 10)
            {
                return false;
            }

            if (_MouseSelectionRect.left >= _MouseSelectionRect.right ||
                _MouseSelectionRect.top >= _MouseSelectionRect.bottom)
            {
                return false;
            }

            if (_MouseSelectionRect.left < 0 ||
                _MouseSelectionRect.top < 0 ||
                _MouseSelectionRect.right > 1.0 ||
                _MouseSelectionRect.bottom > 1.0)
            {
                return false;
            }
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            start_captura = DateTime.Now.AddSeconds(-29);
        }
      
        private void timer_Tick(object sender, EventArgs e)
        {
            if (start_captura.AddSeconds(30) < DateTime.Now)
            {
                timer.Stop();
                if (!cameraControl.CameraCreated)
                { this.Close(); }
                bitmap = cameraControl.SnapshotOutputImage();
                cameraControl.CloseCamera();
                this.Close();
            }
            if ((start.AddSeconds(timeout) - DateTime.Now).Seconds < 0 && IsRead)
            {
                timer.Stop();
                if (!cameraControl.CameraCreated)
                { this.Close(); }
                bitmap = cameraControl.SnapshotOutputImage();
                cameraControl.CloseCamera();
                this.Close();
            }
            else
            {               
                long t_rem = ((start.AddSeconds(timeout) - DateTime.Now).Ticks / 10000);
                if (t_rem > 0)
                {
                    lbl_timeout.Text = string.Format("Captura em {0} segundo{1}", (int)(start.AddSeconds(timeout) - DateTime.Now).TotalSeconds,
                                                ((start.AddSeconds(timeout) - DateTime.Now).Seconds) > 1 ? "s" : "");
                    progressBar1.Value = (int)(t_rem);
                }


            }
            //}  
        }
    }
}

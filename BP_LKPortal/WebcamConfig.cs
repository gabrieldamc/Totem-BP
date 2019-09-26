using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LKPortal
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

        class WebcamConfig
        {
            System.Configuration.Configuration config;
            public String WebcamName { get; private set; }
            public Camera_NET.Resolution Resolution { get; private set; }
            public String Focus { get; private set; }
            public int Zoom { get; private set; }
            public int Exposure { get; private set; }
            public int Brightness { get; private set; }
            public int Contrast { get; private set; }
            public int BacklightCompensation { get; private set; }
            public int Gain { get; private set; }
            public int Gamma { get; private set; }
            public string[] config_allkeys { get; private set; }

            public WebcamConfig()
            {
            volta:
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += @"\Agecom Soluções\Totem\user.config";
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = path;
                try
                {
                    config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                    config_allkeys = config.AppSettings.Settings.AllKeys;
                }
                catch { try { System.IO.File.Delete(path); goto volta; } catch { } }
                WebcamName = config_ler_valor("WebcamName", "------");
                string _Resolution = config_ler_valor("Resolution", "800x600");
                if (_Resolution.ToUpper().Contains("X"))
                {
                    Resolution = new Camera_NET.Resolution(Convert.ToInt32(_Resolution.ToUpper().Split('X')[0]),
                        Convert.ToInt32(_Resolution.ToUpper().Split('X')[1]));
                }
                Focus = config_ler_valor("Focus", "Auto");
                Zoom = Convert.ToInt32(config_ler_valor("Zoom", "100"));
                Exposure = Convert.ToInt32(config_ler_valor("Exposure", "0"));
                Brightness = Convert.ToInt32(config_ler_valor("Brightness", "0"));
                Contrast = Convert.ToInt32(config_ler_valor("Contrast", "0"));
                BacklightCompensation = Convert.ToInt32(config_ler_valor("BacklightCompensation", "0"));
                Gain = Convert.ToInt32(config_ler_valor("Gain", "0"));
                Gamma = Convert.ToInt32(config_ler_valor("Gamma", "0"));
            }



            public string config_ler_valor(string coluna, string valor)
            {
                string ret = null;
                try
                {
                    ret = config.AppSettings.Settings[coluna].Value;
                }
                catch (Exception)
                {
                }
                if (ret == null)
                {
                    config_salvar_valor(coluna, valor);
                    ret = valor;
                }
                config.Save();
                return ret;
            }
            public void config_salvar_valor(string coluna, string valor)
            {
                config_allkeys = config.AppSettings.Settings.AllKeys;

                if (Array.Find(config_allkeys, s => s == coluna) != null)
                    config.AppSettings.Settings[coluna].Value = valor;
                else
                    config.AppSettings.Settings.Add(new KeyValueConfigurationElement(coluna, valor));
                config.Save();
            }
        }
    }


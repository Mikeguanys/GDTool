using System.Configuration;

namespace GDCreateTool.Comm
{
    public static class PComm
    {
        public static string ConnectionName { get; } = "NowConnection";
        /// <summary>
        /// 修改AppSetting
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool ModifyAppSetting(this string Key, string Value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[Key].Value = Value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 修改ConnectStr
        /// </summary>
        /// <returns></returns>
        public static bool ModifyConnectStr(this string Key, string Value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection csSection = config.ConnectionStrings;
                csSection.ConnectionStrings[Key].ConnectionString = Value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}

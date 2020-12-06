using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace MemoriesAdmin.Helpers
{
   
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                if (CrossSettings.IsSupported)
                    return CrossSettings.Current;

                return null; // 
            }
        }
       
        public static string Username
        {
            get => AppSettings.GetValueOrDefault(nameof(Username), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Username), value);
        }
        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
       
        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
        }

       

    }
}
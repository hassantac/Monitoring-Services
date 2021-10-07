using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Text;

namespace Meetings.Common.Helper
{
    public static class AppSettingHelper
    {
        #region Private Fields

        #endregion


        #region Private Methods
        private static string GetSettingValue(string parentKey, string childKey)
        {
            try
            {
                IConfigurationRoot configuration = GetSettingConfiguration();

                if (!configuration.GetSection(parentKey).Exists())
                {
                    throw new Exception(MessageHelper.AppSettingMissing(parentKey));
                }

                if (!configuration.GetSection(parentKey).GetSection(childKey).Exists())
                {
                    throw new Exception(MessageHelper.AppSettingMissing(childKey));
                }

                return configuration.GetSection(parentKey).GetSection(childKey).Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }



        private static IConfigurationRoot GetSettingConfiguration()
        {
            try
            {
                return new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion


        #region Constructors

        #endregion


        #region Properties

        #endregion


        #region Fields

        // Parent Section
        public const string Portal = "Portal";

        public const string CustomSettings = "Custom_Settings";

        public const string AppConfigutions = "App_Configutions";

        // Child Section
        public const string JwtTokenSecret = "Jwt_Token_Secret";

        public const string JwtValueSecret = "Jwt_Value_Secret";

        public const string ApiToken = "Api_Token";

        public const string PasswordSalt = "Password_Salt";

        public const string PasswordSecret = "Password_Secret";

        public const string EnableSignature = "Enable_Signature";

        public const string EnableSwagger = "Enable_Swagger";

        public const string EnableSeeder = "Enable_Seeder";

        public const string ClientId = "Client_Id";

        public const string ClientSecret = "Client_Secret";

        public const string Tenant = "Tenant_Id";

        public const string Cron = "Cron";

        public const string ExcelFilePath = "Excel_File_Path";

        public static string UtcDifference = "Utc_difference";

        public static string AdminURL = "Admin_URL";



        #endregion


        #region Methods
        public static bool GetEnableSeeder()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSeeder));
        }
        public static string GetCron()
        {
            return GetSettingValue(AppConfigutions, Cron);
        }
        public static bool GetEnableSwagger()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSwagger));
        }

        public static bool GetEnableSignature()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSignature));
        }
        public static string GetAdminURL()
        {
            return GetSettingValue(AppConfigutions, AdminURL);
        }
        public static string GetJwtTokenSecret()
        {
            return GetSettingValue(CustomSettings, JwtTokenSecret);
        }

        public static string GetJwtValueSecret()
        {
            return GetSettingValue(CustomSettings, JwtValueSecret);
        }
        public static string GetApiToken()
        {
            return GetSettingValue(CustomSettings, ApiToken);
        }

        public static string GetPasswordSalt()
        {
            return GetSettingValue(CustomSettings, PasswordSalt);
        }

        public static string GetPasswordSecret()
        {
            return GetSettingValue(CustomSettings, PasswordSecret);
        }
        public static string GetClientId()
        {
            return GetSettingValue(AppConfigutions, ClientId);
        }
        public static string GetClientSecret()
        {
            return GetSettingValue(AppConfigutions, ClientSecret);
        }
        public static string GetTenant()
        {
            return GetSettingValue(AppConfigutions, Tenant);
        }

        public static string GetHangFireConnection()
        {
            return GetSettingValue("ConnectionStrings", "HangFireConnection");
        }
        public static string GetDefaultConnection()
        {
            return GetSettingValue("ConnectionStrings", "DefaultConnection");
        }
        public static string GetExcelFilePath()
        {
            return GetSettingValue(CustomSettings, ExcelFilePath);
        }
        public static int GetUtcDifference()
        {
            return int.Parse(GetSettingValue(CustomSettings, UtcDifference));
        }

        #endregion
    }
}

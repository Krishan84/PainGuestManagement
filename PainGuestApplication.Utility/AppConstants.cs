using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace PainGuestApplication.Utility
{
    public class AppConstants
    {
        private static IConfiguration _configuration;
        protected static readonly object LockObject = new object();
        protected static volatile string _baseUrl;
        protected static volatile string _applicationUserId;
        protected static volatile NameValueCollection _azureConfig;
        protected static volatile NameValueCollection _graphApiConfig;
        protected static volatile NameValueCollection _clientConfig;
        protected static volatile NameValueCollection _authConfig;
        protected static volatile NameValueCollection _mailConfig;
        protected static volatile string _supportEmail;
        protected static volatile NameValueCollection _stateCityLookUpApiConfig;
        protected static volatile NameValueCollection _cryptography;
        private static AppConstants Instance = null;
        public static AppConstants GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (LockObject)
                    {
                        Instance = new AppConstants();
                    }
                }

                return Instance;
            }
        }

        public static void SetConfiguration(IConfiguration configuration)
        {
            if (_configuration == null)
                _configuration = configuration;
        }

        public static string BaseUrl
        {
            get
            {
                if (_baseUrl == null)
                {
                    lock (LockObject)
                    {
                        _baseUrl = _configuration.GetConnectionString("DefaultConnection");
                    }
                }
                return _baseUrl;
            }
        }

        public static string ApplicationUserId
        {
            get
            {
                if (_applicationUserId == null)
                {
                    lock (LockObject)
                    {
                        _applicationUserId = "0f16e16f-5746-4216-8972-5a248e3038ea";
                    }
                }
                return _applicationUserId;
            }
        }

        public static NameValueCollection AzureConfig
        {
            get
            {
                if (_azureConfig == null)
                {
                    lock (LockObject)
                    {
                        _azureConfig = new NameValueCollection();
                        _azureConfig.Set("ClientId", _configuration["AzureConfig:ClientId"]);
                        _azureConfig.Set("ClientSecret", _configuration["AzureConfig:ClientSecret"]);
                        _azureConfig.Set("Tenant", _configuration["AzureConfig:Tenant"]);
                        _azureConfig.Set("ExtensionFieldId", _configuration["AzureConfig:ExtensionFieldId"]);
                        _azureConfig.Set("AccountName", _configuration["AzureConfig:AccountName"]);
                        _azureConfig.Set("KeyValue", _configuration["AzureConfig:KeyValue"]);
                    }
                }
                
                return _azureConfig;
            }
        }
    }
}

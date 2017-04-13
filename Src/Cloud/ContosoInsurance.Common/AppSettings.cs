using Microsoft.Azure;
using System;

namespace ContosoInsurance.Common
{
    public static class AppSettings
    {
        public static readonly string StorageConnectionString = CloudConfigurationManager.GetSetting("MS_AzureStorageAccountConnectionString");

        public static readonly string ClaimManualApproverUrl = CloudConfigurationManager.GetSetting("Contoso_ClaimManualApproverUrl");

        public static readonly string ApplicationInsightsInstrumentationKey = CloudConfigurationManager.GetSetting("MS_ApplicationInsightsInstrumentationKey");

        public static readonly bool AutoSeedUserData = CloudConfigurationManager.GetSetting("AutoSeedUserData").IgnoreCaseEqualsTo("true");

        public const int BlobReadExpireMinitues = 5;

        public const string AADClaimNameType = "name";

        public static class Queues
        {
            public static string MobileClaims = "mobile-claims";
        }

        public static class CustomerMock
        {
            public const string FirstName = "Ron" ;
            public const string LastName = "Gabel";
            public const string UserId = "http://schemas.microsoft.com/identity/claims/identityprovider: microsoftaccount:sid:93715240606f11f997e6ead05452ba9f";
            public const string Email = "rong-demo@outlook.com";
            private const string MockImagePath = "/content/images/mock/";
            public static readonly string UserPhotoPath = MockImagePath + "Ron Gabel.jpg";
            public static readonly string SelectedVehiclePath = MockImagePath + "Selected-Vehicle.png";
            public static readonly string DriverLicensePath = MockImagePath + "OCR-Image_DriverLicense_RonGabel.jpg";
            public static readonly string LicensePlatePath = MockImagePath + "OCR-Image_LicensePlate_RonGabel.jpg";
            public static readonly string PolicyIDPath = MockImagePath + "OCR-Image_PolicyID_RonGabel.jpg";
            public static string[] CrashImagesPaths = new string[] { MockImagePath+ "ContosoInsurance-CrashImage_1.jpg", MockImagePath+ "ContosoInsurance-CrashImage_2.jpg",MockImagePath+"ContosoInsurance-CrashImage_3.jpg"};

            public const string LicensePlate = "LicensePlate";
            public const string InsuranceCard = "InsuranceCard";
            public const string DriverLicense = "DriverLicense";
        }

        public static readonly string CreateMobileClaimFromWebUrl = CloudConfigurationManager.GetSetting("CreateMobileClaimFromWebUrl");
    }
}

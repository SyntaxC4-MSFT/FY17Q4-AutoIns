using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoInsurance.MVC.Models
{
    public class AddClaimViewModel
    {
        public int CustomerId;
        public int CustomerVehicleId;
        public string UserPhotoPath;
        public string DriverLicensePath;
        public string LicensePlatePath;
        public string PolicyIDPath;
        public string SelectedVehiclePath;
        public string[] CrashImagesPaths;
    }
}
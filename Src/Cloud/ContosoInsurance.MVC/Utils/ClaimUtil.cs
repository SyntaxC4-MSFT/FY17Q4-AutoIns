using ContosoInsurance.API.Helpers;
using ContosoInsurance.Common;
using ContosoInsurance.Common.Data.CRM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ContosoInsurance.MVC.Utils
{
    public class ClaimUtil
    {
        private static ClaimsDbContext dbContext = new ClaimsDbContext();
        public static async Task<Customer> GetCustomerMock()
        {
            var firstName = AppSettings.CustomerMock.FirstName;
            var lastName = AppSettings.CustomerMock.LastName;
            var queryable = dbContext.Customers
                    .Where(i => i.FirstName.ToLower() == firstName.ToLower()
                            && i.LastName.ToLower() == lastName.ToLower());
            var customer = await queryable.FirstOrDefaultAsync();
            if (customer == null)
            {
                var helper = new SeedDataHelper();
                await helper.SeedDataAsync(AppSettings.CustomerMock.UserId, firstName, lastName, AppSettings.CustomerMock.Email);
                customer = await dbContext.Customers.Where(
                                i => i.FirstName.ToLower() == firstName.ToLower()
                                  && i.LastName.ToLower() == lastName.ToLower()).FirstAsync();
            }
            return customer;
        }

        public static int ParseDamageAssessmentToInt(string damageAssessment)
        {
            var result = 0;
            try
            {
                ClaimDamageAssessment assessment;
                Enum.TryParse(damageAssessment, out assessment);
                result = (int)assessment;
            }
            catch (Exception ex)
            {
            }
            return result;
        }


        public static List<Tuple<string,string>> GetOtherPartyImages()
        {
            string[] imagePathsArray = new string[] { AppSettings.CustomerMock.DriverLicensePath, AppSettings.CustomerMock.LicensePlatePath, AppSettings.CustomerMock.PolicyIDPath };
            List<Tuple<string, string>> base64Result = new List<Tuple<string, string>>();
            base64Result.Add(Tuple.Create(GetImageAsBase64(imagePathsArray[0]),AppSettings.CustomerMock.DriverLicense));
            base64Result.Add(Tuple.Create(GetImageAsBase64(imagePathsArray[1]),AppSettings.CustomerMock.LicensePlate));
            base64Result.Add(Tuple.Create(GetImageAsBase64(imagePathsArray[2]),AppSettings.CustomerMock.InsuranceCard));
            return base64Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> claim image base64 and claim image name</returns>
        public static List<Tuple<string, string>> GetClaimImages(Guid uid)
        {
            List<Tuple<string, string>> base64Result = new List<Tuple<string, string>>();
            var i = 0;
            foreach (var imagePath in AppSettings.CustomerMock.CrashImagesPaths)
            {
                i += 1;
                base64Result.Add(Tuple.Create(GetImageAsBase64(imagePath), string.Format("claim-{0}-0{1}", uid, i)));
            }
            return base64Result;
        }

        private static string GetImageFolder(string imageName)
        {
            return HttpContext.Current.Server.MapPath("~" + imageName);
        }


        private static string GetImageAsBase64(string imagePath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(GetImageFolder(imagePath));
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
    }
}
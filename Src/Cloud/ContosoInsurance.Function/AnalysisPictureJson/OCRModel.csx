#r "System.ComponentModel.DataAnnotations"

#load "OCRAttribute.csx"
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;


public class PicturesQCRData
{
    public OcrResults partycard { get; set; }

    public OcrResults partylicense { get; set; }

    public OcrResults partyplate { get; set; }
}

public static class ImageKind
{
    public const string LicensePlate = "LicensePlate";
    public const string InsuranceCard = "InsuranceCard";
    public const string DriverLicense = "DriverLicense";
}

public class OtherParty
{
    //Ideally, the OCR attributes defined in this class would be read from a data file
    //so code does not need to be re-compiled to adjust them. To keep the sample simple
    //they are defined here.
    //Keep in mind, these OCR attributes are configured to work with the sample OCR
    //images provided with this sample.  If you wish to use different images you must
    //adjust these OCR coordinates to work with the images you supply.
    public int Id { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 189, 200, 20, @"^\w+")]
    public string FirstName { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 173, 200, 20)]
    public string LastName { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 207, 200, 20)]
    public string Street { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 225, 200, 20, @"^\w+")]
    public string City { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 225, 200, 20, @"(?<=\w+\s+)\w+")]
    public string State { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 225, 200, 20, @"\d+$")]
    public string Zip { get; set; }

    [Column(TypeName = "date")]
    [OCR(ImageKind.DriverLicense, 248, 245, 70, 20)]
    public DateTime? DOB { get; set; }

    [OCR(ImageKind.InsuranceCard, 5, 78, 82, 22)]
    public string PolicyId { get; set; }

    [Column(TypeName = "date")]
    [OCR(ImageKind.InsuranceCard, 134, 78, 76, 22)]
    public DateTime? PolicyStart { get; set; }

    [Column(TypeName = "date")]
    [OCR(ImageKind.InsuranceCard, 264, 78, 76, 22)]
    public DateTime? PolicyEnd { get; set; }

    [OCR(ImageKind.DriverLicense, 200, 142, 321, 131, @"[0-9 ]+")]
    public string DriversLicenseNumber { get; set; }

    [OCR(ImageKind.LicensePlate, 144, 104, 280, 132)]
    public string LicensePlate { get; set; }

    [OCR(ImageKind.InsuranceCard, 185, 198, 200, 23)]
    public string VIN { get; set; }
}

#r "Newtonsoft.Json"
#load "OCRModel.csx"
#load "OCR.csx"
using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    var jsonContent = await req.Content.ReadAsStringAsync();
    var picturesQCRData = JsonConvert.DeserializeObject<PicturesQCRData>(jsonContent);
    var otherParty = new OtherParty();
    await OCR.UpdateAsync(otherParty, picturesQCRData.partycard, picturesQCRData.partylicense, picturesQCRData.partyplate);
    return req.CreateResponse(HttpStatusCode.OK, otherParty);
}

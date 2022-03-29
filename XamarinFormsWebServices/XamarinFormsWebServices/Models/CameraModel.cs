using System;
namespace XamarinFormsWebServices.Models
{
    public class CameraModel
    {
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }

        public string MediaType { get; set; }

        public string MediaUrl { get; set; }
    }
}

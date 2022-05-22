using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace SetPhotoGps.Service
{
    public static class FileExtensionService
    {
        public static bool GetIsImage(FileInfo file)
        {
            return GetImageFileExtensions().Contains(file.Extension.ToLower());
        }

        public static bool GetIsJpgOrJpeg(FileInfo file)
        {
            var lowerCaseFileExtension = file.Extension.ToLower();
            return (lowerCaseFileExtension == ".jpg") || (lowerCaseFileExtension == ".jpeg");
        }

        private static List<string> GetImageFileExtensions()
        {
            return ImageCodecInfo.GetImageEncoders()
                                 .Select(c => c.FilenameExtension)
                                 .SelectMany(e => e.Split(';'))
                                 .Select(e => e.Replace("*", "").ToLower())
                                 .ToList();
        }
    }
}
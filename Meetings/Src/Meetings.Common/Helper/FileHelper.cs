using Meetings.Common.Enums;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Drawing = System.Drawing;

namespace Meetings.Common.Helper
{
    public static class FileHelper
    {
        #region Private Methods

        private static void SaveJpeg(string path, Drawing.Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
            // JPEG image codec
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        private static bool AddFile(string fileContent, string path)
        {
            byte[] byt = Convert.FromBase64String(fileContent);

            var size = (byt.Length / 1024);

            var isImage = IsValidImage(byt);

            if (isImage)
            {
                if (size > 300)
                {
                    using var ms = new MemoryStream(byt);
                    var img = Drawing.Image.FromStream(ms);
                    SaveJpeg(path, img, 50);
                }
                File.WriteAllBytes(path, byt);
            }
            else
            {
                File.WriteAllBytes(path, byt);
            }

            return true;
        }

        private static string GetFileName(string extension)
        {
            return Guid.NewGuid().ToString() + "." + extension;
        }

        #endregion Private Methods



        #region Methods

        public static string GetFileLink(string fileName, FileLinkType type)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }
            return type switch
            {
                _ => "/v1/product/image/No_Image.jpeg/view",
            };
        }

        public static string GetFileLink(string filename, string folder_name, AccountType type)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return string.Empty;
            }
            return type switch
            {
                AccountType.Admin => $"v1/user/{folder_name}/{filename}/view",
                _ => "/v1/product/image/No_Image.jpeg/view",
            };
        }

        public static string UploadFiles(string content, string extension, FileLinkType type)
        {
            var fileName = GetFileName(extension);
            string iconPath = string.Empty;
            switch (type)
            {
                default:
                    break;
            }
            AddFile(content, iconPath + fileName);
            return fileName;
        }

        public static async Task<bool> AddFileAsync(string fileContent, string path)
        {
            byte[] byt = Convert.FromBase64String(fileContent);

            await File.WriteAllBytesAsync(path, byt);

            return true;
        }

        public static bool AddFile(byte[] byt, string path)
        {
            File.WriteAllBytes(path, byt);

            return true;
        }

        public static async Task<bool> AddFileAsync(byte[] byt, string path)
        {
            await File.WriteAllBytesAsync(path, byt);

            return true;
        }

        public static bool IsValidImage(byte[] bytes)
        {
            try
            {
                using var ms = new MemoryStream(bytes);
                Drawing.Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        #endregion Methods
    }
}
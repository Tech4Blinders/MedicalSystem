using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace MedicalSystem.Api.Services.UploadImage
{
    public class UploadImg:IUploadImg
    {
        private readonly IConfiguration _config;
        private readonly Cloudinary cloudinary;
        public UploadImg(IConfiguration config)
        {
            _config= config;
            var cloudinaryCloudName = _config.GetValue<string>("cloudinaryCloudName");
            var cloudinaryApiKey = _config.GetValue<string>("cloudinaryApiKey");
            var cloudinaryApiSecret = _config.GetValue<string>("cloudinaryApiSecret");

            Account account = new Account(cloudinaryCloudName, cloudinaryApiKey, cloudinaryApiSecret);
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public string uploadImg(string fileName ,Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder = "Medical System"
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}



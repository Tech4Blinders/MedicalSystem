namespace MedicalSystem.Api.Services.UploadImage
{
    public interface IUploadImg
    {
        public string uploadImg(string fileName, Stream stream);
    }
}

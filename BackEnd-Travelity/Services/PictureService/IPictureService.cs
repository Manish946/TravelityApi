using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.PictureService
{
    public interface IPictureService
    {
        Task<ICollection<Picture>> GetAllPictures();
        Task<Picture> GetPictureById(int id);
        Task<bool> PictureExistsByID(int id);

        Task<bool> CreatePicture(Picture picture);
        Task<bool> DeletePicture(Picture picture);
    }
}

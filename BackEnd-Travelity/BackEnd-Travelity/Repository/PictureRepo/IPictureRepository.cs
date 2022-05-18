using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.PictureRepo
{
    public interface IPictureRepository
    {
        Task<ICollection<Picture>> GetAllPictures();
        Task<Picture> GetPictureById(int id);
        Task<bool> PictureExistsByID(int id);
        Task<bool> CreatePicture(Picture picture);
        Task<bool> Save();
        Task<bool> DeletePicture(Picture picture);
    }
}

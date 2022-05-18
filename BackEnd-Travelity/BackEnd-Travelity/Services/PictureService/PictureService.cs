using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.PictureRepo;

namespace BackEnd_Travelity.Services.PictureService
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository pictureRepo;

        public PictureService(IPictureRepository _pictureRepo)
        {
            pictureRepo = _pictureRepo;
        }

        public async Task<ICollection<Picture>> GetAllPictures() => await pictureRepo.GetAllPictures();
        public async Task<Picture> GetPictureById(int id) => await pictureRepo.GetPictureById(id);
        public async Task<bool> PictureExistsByID(int id) => await pictureRepo.PictureExistsByID(id);

        public async Task<bool> CreatePicture(Picture picture) => await pictureRepo.CreatePicture(picture);
        public async Task<bool> DeletePicture(Picture picture) => await pictureRepo.DeletePicture(picture);
    }
}

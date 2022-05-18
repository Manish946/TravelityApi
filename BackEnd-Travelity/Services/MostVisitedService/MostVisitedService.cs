using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.MostVisitedRepo;

namespace BackEnd_Travelity.Services.MostVisitedService
{
    public class MostVisitedService : IMostVisitedService
    {
        private readonly IMostVisitedRepository mostVisitedRepo;

        public MostVisitedService(IMostVisitedRepository _mostVisitedRepo)
        {
            mostVisitedRepo = _mostVisitedRepo;
        }

        public async Task<ICollection<MostVisited>> GetAllMostVisiteds() => await mostVisitedRepo.GetAllMostVisiteds();
        public async Task<MostVisited> GetMostVisitedById(int id) => await mostVisitedRepo.GetMostVisitedById(id);
        public async Task<bool> MostVisitedExistsByID(int id) => await mostVisitedRepo.MostVisitedExistsByID(id);

        public async Task<bool> CreateMostVisited(MostVisited mostVisited) => await mostVisitedRepo.CreateMostVisited(mostVisited);
        public async Task<bool> UpdateMostVisited(MostVisited mostVisited) => await mostVisitedRepo.UpdateMostVisited(mostVisited);
        public async Task<bool> DeleteMostVisited(MostVisited mostVisited) => await mostVisitedRepo.DeleteMostVisited(mostVisited);

    }
}

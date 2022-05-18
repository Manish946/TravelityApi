using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.MostVisitedRepo
{
    public interface IMostVisitedRepository
    {
        Task<ICollection<MostVisited>> GetAllMostVisiteds();
        Task<MostVisited> GetMostVisitedById(int id);
        Task<bool> MostVisitedExistsByID(int id);
        Task<bool> CreateMostVisited(MostVisited mostVisited);
        Task<bool> Save();
        Task<bool> UpdateMostVisited(MostVisited mostVisited);
        Task<bool> DeleteMostVisited(MostVisited mostVisited);
    }
}

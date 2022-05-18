using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.ExplorerRepo
{
    public interface IExplorerRepository
    {
        Task<ICollection<Explorer>> GetAllExplorers();
        Task<Explorer> GetExplorerById(int id);
        Task<bool> ExplorerExistsByID(int id);
        Task<bool> CreateExplorer(Explorer explorer);
        Task<bool> Save();
        Task<bool> DeleteExplorer(Explorer explorer);
    }
}

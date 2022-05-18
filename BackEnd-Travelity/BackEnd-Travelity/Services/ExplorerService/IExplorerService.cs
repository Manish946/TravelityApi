using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.ExplorerService
{
    public interface IExplorerService
    {
        Task<ICollection<Explorer>> GetAllExplorers();
        Task<Explorer> GetExplorerById(int id);
        Task<bool> ExplorerExistsByID(int id);

        Task<bool> CreateExplorer(Explorer explorer);
        Task<bool> DeleteExplorer(Explorer explorer);
    }
}

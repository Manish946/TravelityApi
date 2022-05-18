using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.ExplorerRepo;


namespace BackEnd_Travelity.Services.ExplorerService
{
    public class ExplorerService : IExplorerService
    {
        private readonly IExplorerRepository explorerRepo;

        public ExplorerService(IExplorerRepository _explorerRepo)
        {
            explorerRepo = _explorerRepo;
        }

        public async Task<ICollection<Explorer>> GetAllExplorers() => await explorerRepo.GetAllExplorers();
        public async Task<Explorer> GetExplorerById(int id) => await explorerRepo.GetExplorerById(id);
        public async Task<bool> ExplorerExistsByID(int id) => await explorerRepo.ExplorerExistsByID(id);

        public async Task<bool> CreateExplorer(Explorer explorer) => await explorerRepo.CreateExplorer(explorer);
        public async Task<bool> DeleteExplorer(Explorer explorer) => await explorerRepo.DeleteExplorer(explorer);
    }
}

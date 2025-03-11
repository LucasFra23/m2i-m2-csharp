using TestMAUI.Models;

namespace TestMAUI.Repositories
{
    public interface IColorsRepository
    {
        Task<List<Couleur>> GetColorsAsync();
        Task AddColorAsync(Couleur color);
        Task RemoveColorAsync(Couleur color);
        Task UpdateColorAsync(int index, Couleur color);
    }
}

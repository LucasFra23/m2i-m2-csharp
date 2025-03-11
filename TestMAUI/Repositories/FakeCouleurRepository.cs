using TestMAUI.Models;

namespace TestMAUI.Repositories
{
    class FakeCouleurRepository : IColorsRepository
    {
        private readonly List<Couleur> _couleurs;

        public FakeCouleurRepository()
        {
            _couleurs = new List<Couleur>
            {
                new Couleur("Rouge", "#FF0000"),
                new Couleur("Vert", "#00FF00"),
                new Couleur("Bleu", "#0000FF"),
                new Couleur("Jaune", "#FFFF00"),
                new Couleur("Cyan", "#00FFFF"),
                new Couleur("Magenta", "#FF00FF"),
                new Couleur("Blanc", "#FFFFFF"),
                new Couleur("Noir", "#000000")
            };
        }

        public Task<List<Couleur>> GetColorsAsync()
        {
            return Task.FromResult(_couleurs);
        }

        public Task AddColorAsync(Couleur color)
        {
            _couleurs.Add(color);
            return Task.CompletedTask;
        }

        public Task RemoveColorAsync(Couleur color)
        {
            _couleurs.Remove(color);
            return Task.CompletedTask;
        }

        public Task UpdateColorAsync(int index, Couleur color)
        {
            _couleurs[index] = color;
            return Task.CompletedTask;
        }
    }
}

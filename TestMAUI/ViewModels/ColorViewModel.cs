using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestMAUI.Models;
using TestMAUI.Repositories;
using TestMAUI.Views;

namespace TestMAUI.ViewModels
{
    public partial class ColorViewModel : ObservableObject
    {
        private readonly IColorsRepository _repository;
        public ObservableCollection<Couleur> Couleurs { get; } = new();

        public ColorViewModel(IColorsRepository repository)
        {
            _repository = repository;
            CreateColors();
        }

        private async void CreateColors()
        {
            var colors = await _repository.GetColorsAsync();
            Couleurs.Clear();
            foreach (var color in colors)
            {
                Couleurs.Add(color);
            }
        }

        [RelayCommand]
        private async Task AddRandomColor()
        {
            string hex = $"#{RandomColor()}";
            var newColor = new Couleur("Random", hex);
            await _repository.AddColorAsync(newColor);
            Couleurs.Add(newColor);
        }

        string RandomColor()
        {
            Random random = new();
            return random.Next(0x1000000).ToString("X6");
        }

        [RelayCommand]
        private async Task DeleteColor(Couleur couleur)
        {
            await _repository.RemoveColorAsync(couleur);
            Couleurs.Remove(couleur);
        }

        [RelayCommand]
        private async void ClickOnColor(Couleur couleur)
        {
            var index = Couleurs.IndexOf(couleur);
            var editPage = new EditColorPage(this, index);
            await Application.Current.MainPage.Navigation.PushAsync(editPage);
        }

        public async Task UpdateColor(int index, Couleur color)
        {
            await _repository.UpdateColorAsync(index, color);
            Couleurs[index] = color;
        }
    }
}

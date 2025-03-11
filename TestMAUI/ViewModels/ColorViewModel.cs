using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TestMAUI.Models;
using TestMAUI.Views;

namespace TestMAUI.ViewModels
{
    public partial class ColorViewModel : ObservableObject
    {
        public ObservableCollection<Couleur> Couleurs { get; } = new();

        public ColorViewModel()
        {
            CreateColors();
        }

        void CreateColors()
        {
            /*Couleurs.Add(new Couleur("Rouge", "#FF0000"));
            Couleurs.Add(new Couleur("Vert", "#00FF00"));
            Couleurs.Add(new Couleur("Bleu", "#0000FF"));
            Couleurs.Add(new Couleur("Jaune", "#FFFF00"));
            Couleurs.Add(new Couleur("Cyan", "#00FFFF"));
            Couleurs.Add(new Couleur("Magenta", "#FF00FF"));*/
            Couleurs.Add(new Couleur("Blanc", "#FFFFFF"));
            Couleurs.Add(new Couleur("Noir", "#000000"));
        }

        [RelayCommand]
        private void AddRandomColor()
        {
            string hex = $"#{RandomColor()}";
            Couleurs.Add(new Couleur($"Random Color {Couleurs.Count + 1}", hex));
        }

        string RandomColor()
        {
            Random random = new();
            return random.Next(0x1000000).ToString("X6");
        }

        [RelayCommand]
        private void DeleteColor(Couleur couleur)
        {
            Couleurs.Remove(couleur);
        }

        [RelayCommand]
        private async Task ClickOnColor(Couleur couleur)
        {
            var editPage = new EditColorPage(couleur);
            await Application.Current.MainPage.Navigation.PushAsync(editPage);
            var updatedColor = await editPage.Task;

            // Update the color in the collection
            var index = Couleurs.IndexOf(couleur);
            if (index != -1)
            {
                Couleurs[index] = updatedColor;
            }
        }
    }
}

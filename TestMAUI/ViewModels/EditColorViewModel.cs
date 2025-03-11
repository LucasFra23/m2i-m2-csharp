using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TestMAUI.Models;

namespace TestMAUI.ViewModels
{
    public partial class EditColorViewModel : ObservableObject
    {
        [ObservableProperty]
        private Couleur couleur;

        private ColorViewModel _colorViewModel;
        private int _index;

        public EditColorViewModel()
        {
            // Default constructor for XAML usage
        }

        public EditColorViewModel(ColorViewModel colorViewModel, int index)
        {
            _colorViewModel = colorViewModel;
            _index = index;
            Couleur = colorViewModel.Couleurs[index];
        }

        [RelayCommand]
        private async void Save()
        {
            await _colorViewModel.UpdateColor(_index, Couleur);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}

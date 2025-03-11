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

        private TaskCompletionSource<Couleur> _taskCompletionSource;

        public EditColorViewModel()
        {
            // Default constructor for XAML usage
        }

        public EditColorViewModel(Couleur couleur, TaskCompletionSource<Couleur> taskCompletionSource)
        {
            Couleur = couleur;
            _taskCompletionSource = taskCompletionSource;
        }

        [RelayCommand]
        private async void Save()
        {
            _taskCompletionSource.SetResult(Couleur);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}

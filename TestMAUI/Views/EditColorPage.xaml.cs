using TestMAUI.Models;
using TestMAUI.ViewModels;

namespace TestMAUI.Views;

public partial class EditColorPage : ContentPage
{
    public Task<Couleur> Task => _taskCompletionSource.Task;
    private TaskCompletionSource<Couleur> _taskCompletionSource;

    public EditColorPage(Couleur couleur)
    {
        InitializeComponent();
        _taskCompletionSource = new TaskCompletionSource<Couleur>();
        BindingContext = new EditColorViewModel(couleur, _taskCompletionSource);
    }
}
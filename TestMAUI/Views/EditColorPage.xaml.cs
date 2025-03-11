using TestMAUI.Models;
using TestMAUI.ViewModels;

namespace TestMAUI.Views;

public partial class EditColorPage : ContentPage
{
    public EditColorPage(ColorViewModel colorViewModel, int index)
    {
        InitializeComponent();
        BindingContext = new EditColorViewModel(colorViewModel, index);
    }
}
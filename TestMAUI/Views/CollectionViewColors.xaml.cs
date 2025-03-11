using TestMAUI.Models;
using TestMAUI.ViewModels;

namespace TestMAUI.Views;

public partial class CollectionViewColors : ContentPage
{
    public CollectionViewColors(ColorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
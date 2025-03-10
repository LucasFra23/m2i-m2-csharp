using TestMAUI.Models;

namespace TestMAUI.Views;

public partial class CollectionViewColors : ContentPage
{
    public IList<Couleur> Couleurs { get; private set; }

    public CollectionViewColors()
    {
        InitializeComponent();
        CreateColors();
        BindingContext = this;
    }

    void CreateColors()
    {
        Couleurs = new List<Couleur>();
        Couleurs.Add(new Couleur { Name = "Rouge", BoxViewColor = "Red" });
        Couleurs.Add(new Couleur { Name = "Vert", BoxViewColor = "Green" });
        Couleurs.Add(new Couleur { Name = "Bleu", BoxViewColor = "Blue" });
        Couleurs.Add(new Couleur { Name = "Jaune", BoxViewColor = "Yellow" });
        Couleurs.Add(new Couleur { Name = "Cyan", BoxViewColor = "Cyan" });
        Couleurs.Add(new Couleur { Name = "Magenta", BoxViewColor = "Magenta" });
        Couleurs.Add(new Couleur { Name = "Noir", BoxViewColor = "Black" });
        Couleurs.Add(new Couleur { Name = "Blanc", BoxViewColor = "White" });
    }
}
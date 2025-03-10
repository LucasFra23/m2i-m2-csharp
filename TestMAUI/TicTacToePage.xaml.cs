namespace TestMAUI;

public partial class TicTacToePage : ContentPage
{
    private char currentPlayer = 'X';
    private Button[] buttons = new Button[9];

    public TicTacToePage()
    {
        InitializeComponent();

        Grid grid = this.FindByName<Grid>("grid");

        int i = 0;
        foreach (var child in grid.Children)
        {
            if (child is Button button)
            {
                buttons[i] = button;
                i++;
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.Text = currentPlayer.ToString();
        button.IsEnabled = false;
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        currentPlayer = 'X';
        foreach (var button in buttons)
        {
            button.Text = string.Empty;
            button.IsEnabled = true;
        }
    }
}

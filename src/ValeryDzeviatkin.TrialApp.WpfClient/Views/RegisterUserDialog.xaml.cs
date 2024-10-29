using System.Windows;

namespace ValeryDzeviatkin.TrialApp.WpfClient.Views;

public partial class RegisterUserDialog : Window
{
    public RegisterUserDialog()
    {
        InitializeComponent();
    }
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
    }
}
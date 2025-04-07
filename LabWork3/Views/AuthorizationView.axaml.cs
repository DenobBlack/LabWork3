using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LabWork3.ViewModels;

namespace LabWork3.Views;

public partial class AuthorizationView : UserControl
{
    public AuthorizationView()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}
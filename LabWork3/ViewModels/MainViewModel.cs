using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LabWork3.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public static NavigationService NavigationService { get; } = new NavigationService();
    [ObservableProperty]
    private ObservableObject? _currentPage;
    [ObservableProperty]
    private ViewModelBase page;

    public MainViewModel()
    {
        NavigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }
    private void OnCurrentViewModelChanged(object? sender, ObservableObject? viewModel)
    {
        CurrentPage = viewModel;
    }

    [RelayCommand]
    private void Authorization()
    {
        //Page = new AuthorizationViewModel();
        NavigationService.NavigateTo(new AuthorizationViewModel());
    }
    [RelayCommand]
    private void Registration()
    {
        //Page = new RegistrationViewModel();
        NavigationService.NavigateTo(new RegistrationViewModel());
    }
}

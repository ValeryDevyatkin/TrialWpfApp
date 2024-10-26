using System.Windows.Input;
using Unity;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal class MainViewModel : ViewModelBase
{
    public MainViewModel(IUnityContainer container) : base(container)
    {
        LogInViewModel = new LogInViewModel(container);
    }

    public LogInViewModel LogInViewModel { get; }

    #region IsUserLoggedIn: bool

    public bool IsUserLoggedIn
    {
        get => _isUserLoggedIn;
        set => SetProperty(ref _isUserLoggedIn, value);
    }

    private bool _isUserLoggedIn;

    #endregion

    #region IsPreloaderVisible: bool

    public bool IsPreloaderVisible
    {
        get => _isPreloaderVisible;
        set => SetProperty(ref _isPreloaderVisible, value);
    }

    private bool _isPreloaderVisible;

    #endregion

    #region CommandProgressText: string?

    public string? CommandProgressText
    {
        get => _commandProgressText;
        set => SetProperty(ref _commandProgressText, value);
    }

    private string? _commandProgressText;

    #endregion

    #region LogIn command

    public ICommand LogInCommand => _logInCommand ??=
        new AsyncCommand(ExecuteLogInAsync, progressText: "Loggining in ...");

    private ICommand? _logInCommand;

    private Task ExecuteLogInAsync(object? parameter)
    {
        // TODO VDE: implement Api call.
        IsUserLoggedIn = true;

        return Task.CompletedTask;
    }

    #endregion

    #region LogOut command

    public ICommand LogOutCommand => _logOutCommand ??=
        new AsyncCommand(ExecuteLogOutAsync, progressText: "Loggining out ...");

    private ICommand? _logOutCommand;

    private Task ExecuteLogOutAsync(object? parameter)
    {
        // TODO VDE: implement Api call.
        IsUserLoggedIn = false;

        return Task.CompletedTask;
    }

    #endregion

    #region RegisterUser command

    public ICommand RegisterUserCommand => _registerUserCommand ??=
        new Command(ExecuteRegisterUserCommand);

    private ICommand? _registerUserCommand;

    private void ExecuteRegisterUserCommand(object? parameter)
    {
        // TODO VDE: implement Api call.
    }

    #endregion
}
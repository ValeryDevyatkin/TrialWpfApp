using Unity;
using ValeryDzeviatkin.MVVM;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal class LogInViewModel : ViewModelBase
{
    // This is only for design-time development.
    public LogInViewModel() : base(ServiceLocator.Container)
    {
    }

    public LogInViewModel(IUnityContainer container) : base(container)
    {
    }

    #region Login: string?

    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    private string? _login;

    #endregion
}
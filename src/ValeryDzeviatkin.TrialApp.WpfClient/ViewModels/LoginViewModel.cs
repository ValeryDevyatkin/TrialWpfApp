using Unity;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal class LoginViewModel : ViewModelBase
{
    public LoginViewModel(IUnityContainer container) : base(container)
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
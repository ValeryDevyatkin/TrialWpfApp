using Unity;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal class MainViewModel : ViewModelBase
{
    public MainViewModel(IUnityContainer container) : base(container)
    {
    }

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
}
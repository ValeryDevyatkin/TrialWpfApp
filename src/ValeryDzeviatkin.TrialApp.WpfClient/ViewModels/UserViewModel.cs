using Unity;
using ValeryDzeviatkin.MVVM;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal class UserViewModel : ViewModelBase
{
    // This is only for design-time development.
    public UserViewModel() : base(ServiceLocator.Container)
    {
    }

    public UserViewModel(IUnityContainer container) : base(container)
    {
    }

    #region Id: int?

    public int? Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    private int? _id;

    #endregion

    #region Login: string?

    public string? Login
    {
        get => _login;
        set => SetProperty(ref _login, value);
    }

    private string? _login;

    #endregion

    #region FirstName: string?

    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string? _firstName;

    #endregion

    #region LastName: string?

    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    private string? _lastName;

    #endregion

    #region Email: string?

    public string? Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    private string? _email;

    #endregion

    #region PhoneNumber: string?

    public string? PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    private string? _phoneNumber;

    #endregion
}
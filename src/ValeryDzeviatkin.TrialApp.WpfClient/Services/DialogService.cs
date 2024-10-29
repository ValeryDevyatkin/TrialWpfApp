using System.Security;
using Unity;
using ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;
using ValeryDzeviatkin.TrialApp.WpfClient.Views;

namespace ValeryDzeviatkin.TrialApp.WpfClient.Services;

record RegisterUserDialoResult(bool IsSucess, UserViewModel? UserViewModel, string? password);

internal class DialogService
{
    private readonly IUnityContainer _container;

    public DialogService(IUnityContainer container)
    {
        _container = container;
    }

    public RegisterUserDialoResult ShowRegisterUserDialog()
    {
        var userViewModel = new UserViewModel(_container);
        var mainWindow = _container.Resolve<MainWindow>();

        var dialog = new RegisterUserDialog()
        {
            Owner = mainWindow,
            DataContext = userViewModel,
            Title = "Register New User",
        };

        var dialogResult = dialog.ShowDialog();
        var isSuccess = dialogResult ?? false;

        var rsult = new RegisterUserDialoResult
        (
            isSuccess,
            isSuccess ? userViewModel : null,
            null
            //isSuccess ? dialog.RegionWrappers.Password : null
        );

        return rsult;
    }
}
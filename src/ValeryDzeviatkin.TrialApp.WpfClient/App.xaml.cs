using System.Windows;
using System.Windows.Threading;
using Unity;
using ValeryDzeviatkin.MVVM;
using ValeryDzeviatkin.MVVM.Helpers;
using ValeryDzeviatkin.MVVM.Interfaces;
using ValeryDzeviatkin.TrialApp.WpfClient.Services;
using ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

namespace ValeryDzeviatkin.TrialApp.WpfClient;

internal partial class App
{
    public App() : base(ServiceLocator.Container)
    {
    }

    public override void BlockUiForCommand(IAsyncCommand command)
    {
        var mainViewModel = Container.Resolve<MainViewModel>();
        mainViewModel.CommandProgressText = command.ProgressText;
        mainViewModel.IsPreloaderVisible = true;
        MainWindow?.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => { }));
    }

    public override void UnlockUiForCommand(IAsyncCommand command)
    {
        var mainViewModel = Container.Resolve<MainViewModel>();
        mainViewModel.IsPreloaderVisible = false;
        mainViewModel.CommandProgressText = null;
    }
    protected override void RegisterTypes()
    {
        base.RegisterTypes();

        // Services.
        Container
           .RegisterSingleton<DialogService>()
            ;
    }

    protected override void OnStartup(StartupEventArgs args)
    {
        try
        {
            base.OnStartup(args);

            CreateMainWindow().Show();
        }
        catch (Exception e)
        {
            this.HandleException(e);

            throw;
        }
    }

    protected override void OnExit(ExitEventArgs args)
    {
        try
        {
            base.OnExit(args);
        }
        catch (Exception e)
        {
            this.HandleException(e);
        }
    }

    protected override void HandleExceptionExternal(ExceptionLogItem ex)
    {
        MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
using System.Windows;
using ValeryDzeviatkin.MVVM;
using ValeryDzeviatkin.MVVM.Helpers;
using ValeryDzeviatkin.MVVM.Interfaces;

namespace ValeryDzeviatkin.TrialApp.WpfClient;

internal partial class App
{
    public App() : base(ServiceLocator.Container)
    {
    }

    public override void BlockUiForCommand(IAsyncCommand command)
    {
        throw new NotImplementedException();
    }

    public override void UnlockUiForCommand(IAsyncCommand command)
    {
        throw new NotImplementedException();
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
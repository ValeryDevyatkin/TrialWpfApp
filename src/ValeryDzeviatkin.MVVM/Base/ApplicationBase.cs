using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Unity;
using ValeryDzeviatkin.MVVM.Helpers;
using ValeryDzeviatkin.MVVM.Interfaces;

namespace ValeryDzeviatkin.MVVM.Base;

public abstract class ApplicationBase<TMainWindow, TMainViewModel> : Application, IUiForCommandBlocker
    where TMainWindow : Window
    where TMainViewModel : ViewModelBase
{
    protected ApplicationBase(IUnityContainer container)
    {
        // TODO VDE: register twice ?
        Container = container
                   .RegisterInstance(this)
                   .RegisterInstance<Application>(this);
    }

    public IUnityContainer Container { get; }
    public abstract void BlockUiForCommand(IAsyncCommand command);
    public abstract void UnlockUiForCommand(IAsyncCommand command);

    public Window CreateMainWindow()
    {
        var window = Container.Resolve<TMainWindow>() ?? throw new NullReferenceException();
        var viewModel = Container.Resolve<TMainViewModel>() ?? throw new NullReferenceException();

        MainWindow = window;
        MainWindow.DataContext = viewModel;

        var assembly = GetType().Assembly;
        var version = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

        var assemblyName = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ??
                           throw new NullReferenceException();

        MainWindow.Title = $"{assemblyName} v.{version}";

        return window;
    }

    protected virtual void RegisterTypes()
    {
        Container
           .RegisterSingleton<TMainWindow>()
           .RegisterSingleton<TMainViewModel>()
            ;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        ExceptionLogHelper.Init(HandleExceptionExternal);

        DispatcherUnhandledException += OnDispatcherUnhandledException;

        base.OnStartup(e);

        RegisterTypes();
    }

    protected abstract void HandleExceptionExternal(ExceptionLogItem ex);

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        this.HandleException(e.Exception);
    }
}
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

    protected override void HandleExceptionExternal(ExceptionLogItem ex)
    {
        throw new NotImplementedException();
    }
}
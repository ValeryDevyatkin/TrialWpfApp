using System.Windows;
using System.Windows.Input;
using ValeryDzeviatkin.MVVM.Helpers;
using ValeryDzeviatkin.MVVM.Interfaces;

namespace ValeryDzeviatkin.MVVM.Base;

public abstract class CommandBase : ICommand
{
    private bool _isDisabled;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object parameter) => !_isDisabled && CanExecuteExternal(parameter);

    public abstract void Execute(object parameter);

    protected void Disable()
    {
        _isDisabled = true;

        ChangeCanExecute();
    }

    protected void Enable()
    {
        _isDisabled = false;

        ChangeCanExecute();
    }

    protected virtual bool CanExecuteExternal(object parameter) => true;

    private void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

public abstract class AsyncCommandBase : CommandBase, IAsyncCommand
{
    protected bool ShouldBlockUi { get; set; }
    public string? ProgressText { get; protected set; }

    public override async void Execute(object parameter)
    {
        Disable();

        if (ShouldBlockUi)
        {
            ((IUiForCommandBlocker)Application.Current).BlockUiForCommand(this);

            await Task.Delay(350);
        }

        try
        {
            await ExecuteExternalAsync(parameter);
        }
        catch (Exception e)
        {
            this.HandleException(e);
        }

        if (ShouldBlockUi)
        {
            ((IUiForCommandBlocker)Application.Current).UnlockUiForCommand(this);
        }

        Enable();
    }

    protected abstract Task ExecuteExternalAsync(object parameter);
}

public class AsyncCommand : AsyncCommandBase
{
    private readonly Predicate<object> _canExecute;
    private readonly Func<object, Task> _execute;

    public AsyncCommand(Func<object, Task> execute, Predicate<object>? canExecute = null, bool shouldBlockUi = false,
        string? progressText = null)
    {
        ShouldBlockUi = shouldBlockUi;
        ProgressText = progressText;

        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute ?? (parameter => base.CanExecuteExternal(parameter));
    }

    protected override bool CanExecuteExternal(object parameter) => _canExecute(parameter);

    protected override Task ExecuteExternalAsync(object parameter) => _execute(parameter);
}
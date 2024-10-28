using System.Windows;
using System.Windows.Input;
using ValeryDzeviatkin.MVVM.Helpers;
using ValeryDzeviatkin.MVVM.Interfaces;

namespace ValeryDzeviatkin.MVVM.Base;

public abstract class CommandBase : ICommand
{
    private bool _isDisabled;
    private readonly Predicate<object?>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    protected CommandBase(Predicate<object?>? canExecute = null)
    {
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => !_isDisabled && (_canExecute?.Invoke(parameter) ?? true);

    public abstract void Execute(object? parameter);

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

    private void ChangeCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

public sealed class Command : CommandBase
{
    private readonly Action<object?> _execute;

    public Command(
        Action<object?> execute,
        Predicate<object?>? canExecute = null
        ) : base(canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public override void Execute(object? parameter)
    {
        Disable();

        try
        {
            _execute(parameter);
        }
        catch (Exception e)
        {
            this.HandleException(e);
        }

        Enable();
    }
}

public sealed class AsyncCommand : CommandBase, IAsyncCommand
{
    public string? ProgressText { get; }

    private readonly Func<object?, Task> _execute;

    public AsyncCommand(
        Func<object?, Task> execute,
        Predicate<object?>? canExecute = null,
        string? progressText = null
        ) : base(canExecute)
    {
        ProgressText = progressText;

        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public override async void Execute(object? parameter)
    {
        Disable();

        var uiBlocker = (IUiForCommandBlocker)Application.Current;
        uiBlocker.BlockUiForCommand(this);

        await Task.Delay(500);

        try
        {
            await _execute(parameter);
        }
        catch (Exception e)
        {
            this.HandleException(e);
        }

        uiBlocker.UnlockUiForCommand(this);

        Enable();
    }
}
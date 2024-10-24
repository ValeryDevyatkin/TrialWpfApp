namespace ValeryDzeviatkin.MVVM.Interfaces;

public interface IUiForCommandBlocker
{
    void BlockUiForCommand(IAsyncCommand command);
    void UnlockUiForCommand(IAsyncCommand command);
}
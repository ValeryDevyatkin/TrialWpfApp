using System.Windows.Input;
using ValeryDzeviatkin.MVVM.Base;

namespace ValeryDzeviatkin.TrialApp.WpfClient.ViewModels;

internal enum MainViewTabType
{
    UserInfo,
    DeveloperInfo,
    BonusView,
}

internal partial class MainViewModel
{
    #region SelectedMainViewTab: MainViewTabType

    public MainViewTabType SelectedMainViewTab
    {
        get => _selectedMainViewTab;
        set => SetProperty(ref _selectedMainViewTab, value);
    }

    private MainViewTabType _selectedMainViewTab;

    #endregion

    #region SelectMainViewTab command

    public ICommand SelectMainViewTabCommand => _selectMainViewTabCommand ??=
        new Command(ExecuteSelectMainViewTabCommand);

    private ICommand? _selectMainViewTabCommand;

    private void ExecuteSelectMainViewTabCommand(object? parameter)
    {
        if (parameter is MainViewTabType tabType)
        {
            SelectedMainViewTab = tabType;
        }
    }

    #endregion
}
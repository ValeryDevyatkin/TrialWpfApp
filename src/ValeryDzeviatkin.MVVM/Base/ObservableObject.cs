using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValeryDzeviatkin.MVVM.Base;

public abstract class ObservableObject : INotifyPropertyChanged
{
    public virtual event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;

    public bool SetProperty<T>(
        ref T source,
        T newValue,
        Action? onChanged = null,
        Action? onChanging = null,
        [CallerMemberName] string? propertyName = null)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            throw new ArgumentException(nameof(propertyName));
        }

        if (EqualityComparer<T>.Default.Equals(source, newValue))
        {
            return false;
        }

        OnPropertyChanging(propertyName, onChanging);

        source = newValue;

        OnPropertyChanged(propertyName, onChanged);

        return true;
    }

    private void OnPropertyChanging(string propertyName, Action? action = null)
    {
        action?.Invoke();

        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }

    private void OnPropertyChanged(string propertyName, Action? action = null)
    {
        action?.Invoke();

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
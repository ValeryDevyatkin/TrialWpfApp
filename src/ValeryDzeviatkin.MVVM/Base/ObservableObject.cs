using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

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

    public bool SetString(
        ref string source,
        string newValue,
        string regex,
        [CallerMemberName] string propertyName = "")
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            throw new ArgumentException(nameof(propertyName));
        }

        if (string.IsNullOrWhiteSpace(regex))
        {
            throw new ArgumentException(nameof(regex));
        }

        if (source == newValue)
        {
            return false;
        }

        var isNotMatchRegex = !string.IsNullOrEmpty(newValue) &&
                              !new Regex(regex).IsMatch(newValue);

        if (!isNotMatchRegex)
        {
            source = newValue;
        }

        OnPropertyChanged(propertyName);

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
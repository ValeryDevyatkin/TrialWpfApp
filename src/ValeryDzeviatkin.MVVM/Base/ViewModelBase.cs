using Unity;

namespace ValeryDzeviatkin.MVVM.Base;

public abstract class ViewModelBase : ObservableObject
{
    protected ViewModelBase(IUnityContainer container)
    {
        Container = container;
    }

    public IUnityContainer Container { get; }
}
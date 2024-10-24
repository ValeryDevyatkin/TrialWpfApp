using Unity;

namespace ValeryDzeviatkin.MVVM;

public static class ServiceLocator
{
    public static IUnityContainer Container { get; } = new UnityContainer();
}
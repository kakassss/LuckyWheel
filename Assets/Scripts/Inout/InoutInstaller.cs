using Zenject;

public class InoutInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InoutManager>().AsSingle().NonLazy();
    }
}

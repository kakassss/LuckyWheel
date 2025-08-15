using UnityEngine;
using Zenject;

public class InoutInstaller : MonoInstaller
{
    [SerializeField] private InoutSO _inoutSO;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_inoutSO).AsSingle().NonLazy();
        Container.Bind<InoutManager>().AsSingle().NonLazy();
    }
}

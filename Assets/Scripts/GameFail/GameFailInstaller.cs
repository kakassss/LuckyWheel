using UnityEngine;
using Zenject;

public class GameFailInstaller : MonoInstaller
{
    [SerializeField] private GameObject _popupFail;
    //[SerializeField] private GameObject _popupSuccess;
    
    public override void InstallBindings()
    {
        Container.Bind<GameFailManager>().AsSingle().WithArguments(_popupFail).NonLazy();
    }
}

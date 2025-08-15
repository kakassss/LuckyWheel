using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpinInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _spinObjects; 
    [SerializeField] private Transform _spinParentTransform;
    [SerializeField] private SpinRewardsDataSO _spinRewardsDataSo;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_spinRewardsDataSo).AsSingle().NonLazy();
        Container.Bind<SpinObjectManager>().AsSingle().WithArguments(_spinObjects,_spinParentTransform).NonLazy();
        Container.Bind<SpinMovementManager>().AsSingle().NonLazy();
        Container.Bind<SpinRewardManager>().AsSingle().NonLazy();
        Container.Bind<SpinIndexManager>().AsSingle().NonLazy();
        
        Container.Bind<SpinEvents>().AsSingle().NonLazy();
        Container.Bind<SpinRotationProvider>().AsSingle().NonLazy();
    }
}

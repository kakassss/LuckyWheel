using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpinInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _spinObjects; 
    [SerializeField] private Transform _spinParentTransform;
    
    public override void InstallBindings()
    {
        Container.Bind<SpinManager>().AsSingle().WithArguments(_spinObjects,_spinParentTransform).NonLazy();
        Container.Bind<SpinMovement>().AsSingle().NonLazy();
    }
}

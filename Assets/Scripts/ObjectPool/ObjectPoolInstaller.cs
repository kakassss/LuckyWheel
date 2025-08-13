using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [Header("Object Pool")]
    [SerializeField] private InoutObject _poolPrefab;
    [SerializeField] private int _poolSize;
    [SerializeField] private Transform _poolParent;
    
    public override void InstallBindings()
    {
        Container.Bind<ObjectPool<InoutObject>>().AsSingle().WithArguments(_poolPrefab,_poolSize,_poolParent).NonLazy();
    }
}
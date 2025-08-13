using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private InventoryDataUI _inventoryDataUI;
    [SerializeField] private Transform _inventoryParent;
    
    public override void InstallBindings()
    {
        Container.Bind<InventoryManager>().AsSingle().WithArguments(_inventoryDataUI,_inventoryParent).NonLazy();
    }
}

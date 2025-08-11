using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpinManager
{
    private List<GameObject> _instantiatedSpins = new List<GameObject>();

    private int _currentSpinIndex = 0;
    
    private readonly List<GameObject> _spinObjects;
    private readonly Transform _spinParentTransform;
    private readonly IInstantiator _instantiator;
    
    public SpinManager(List<GameObject> spinObjects, Transform spinParentTransform, IInstantiator instantiator)
    {
        _spinObjects = spinObjects;
        _spinParentTransform = spinParentTransform;
        _instantiator = instantiator;
        
        InstantiateSpinObjects();
        SetActiveSpin();
    }

    private void InstantiateSpinObjects()
    {
        _instantiatedSpins.Clear();
        
        foreach (var spinObject in _spinObjects)
        {
            var spinPrefab = _instantiator.InstantiatePrefab(spinObject);
            spinPrefab.transform.SetParent(_spinParentTransform);
            spinPrefab.transform.localPosition = Vector3.zero;
            spinPrefab.gameObject.SetActive(false);
            
            _instantiatedSpins.Add(spinPrefab);
        }
    }

    private void SetActiveSpin()
    {
        foreach (var spin in _instantiatedSpins)
        {
            spin.gameObject.SetActive(false);
        }
        
        _instantiatedSpins[_currentSpinIndex].gameObject.SetActive(true);
    }
    
}

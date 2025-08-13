using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpinObjectManager : IDisposable
{
    private List<GameObject> _instantiatedSpins = new List<GameObject>();
    
    private readonly List<GameObject> _spinObjects;
    private readonly Transform _spinParentTransform;
    private readonly IInstantiator _instantiator;
    private readonly SpinIndexManager _spinIndexManager;
    private readonly SpinEvents _spinEvents;
    
    public SpinObjectManager(List<GameObject> spinObjects, Transform spinParentTransform, IInstantiator instantiator,
        SpinIndexManager spinIndexManager, SpinEvents spinEvents)
    {
        _spinObjects = spinObjects;
        _spinParentTransform = spinParentTransform;
        _instantiator = instantiator;
        _spinIndexManager = spinIndexManager;
        _spinEvents = spinEvents;
        
        InstantiateSpinObjects();
        SetActiveSpin();
        
        _spinEvents.AddOnSpinActionsEnd(SetActiveSpin);
    }

    public void Dispose()
    {
        _spinEvents.RemoveOnSpinActionsEnd(SetActiveSpin);
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

        var index = _spinIndexManager.GetCurrentSpinIndex();
        _instantiatedSpins[index].gameObject.SetActive(true);
    }
}

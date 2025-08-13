using UnityEngine;
using Zenject;

public class InoutManager : MonoBehaviour
{
    private const int INOUTOBJECT_AMOUNT = 5;
    
    private ObjectPool<InoutObject> _inoutObjectPool;

    [Inject]
    private void Construct(ObjectPool<InoutObject> inoutObjectPool)
    {
        _inoutObjectPool = inoutObjectPool;
    }


    private void StartInout()
    {
        for (int i = 0; i < INOUTOBJECT_AMOUNT; i++)
        {
            var inout = _inoutObjectPool.GetFromPool();
            
        }
    }
    
}

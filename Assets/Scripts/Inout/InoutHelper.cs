using UnityEngine;

public class InoutHelper
{
    private InoutSO _inoutSO;
    
    public InoutHelper(InoutSO inoutSO)
    {
        _inoutSO = inoutSO;    
    }

    private Sprite GetSpriteFromIndex(int index)
    {
        if (_inoutSO.InoutDictionary.TryGetValue(index, out var sprite))
        {
            return sprite;
        }
        
        //Return first sprite
        Debug.LogError("Invalid index");
        return _inoutSO.InoutDictionary[0];
    }
}

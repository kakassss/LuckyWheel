using System;

public class SpinIndexManager : IDisposable
{
    public int CurrentSpinIndex => _currentSpinIndex;
    
    private readonly SpinEvents _spinEvents;
    
    private int _currentSpinIndex = 1;
    
    public SpinIndexManager(SpinEvents spinEvents)
    {
        _spinEvents = spinEvents;
        
        _spinEvents.AddSpinMovementEnd(IncreaseSpinIndex);
    }

    public void Dispose()
    {
        _spinEvents.RemoveSpinMovementEnd(IncreaseSpinIndex);
    }

    private void IncreaseSpinIndex()
    {
        _currentSpinIndex++;
    }

    public int GetCurrentSpinIndex()
    {
        if (_currentSpinIndex == 1) return 1;
        
        if (_currentSpinIndex % 30 == 0)
        {
            //Return Golden Spin
            return 2;
        }

        if (_currentSpinIndex % 5 == 0)
        {
            //Return Silver Spin
            return 1;
        }
        
        //Return Bronze Spin
        return 0;
    }
}
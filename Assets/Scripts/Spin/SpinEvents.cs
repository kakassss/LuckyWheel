using System;

public class SpinEvents
{
    private Action OnSpinMovementEnd;
    private Action OnSpinActionsEnd;

    public void FireSpinMovementEnd()
    {
        OnSpinMovementEnd?.Invoke();
    }

    public void AddSpinMovementEnd(Action action)
    {
        OnSpinMovementEnd += action;
    }

    public void RemoveSpinMovementEnd(Action action)
    {
        OnSpinMovementEnd -= action;
    }
    
    public void FireOnSpinActionsEnd()
    {
        OnSpinActionsEnd?.Invoke();
    }

    public void AddOnSpinActionsEnd(Action action)
    {
        OnSpinActionsEnd += action;
    }

    public void RemoveOnSpinActionsEnd(Action action)
    {
        OnSpinActionsEnd -= action;
    }
}
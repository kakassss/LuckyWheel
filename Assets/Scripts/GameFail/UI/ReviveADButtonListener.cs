using Zenject;

public class ReviveADButtonListener : BaseButtonListener
{
    private GameFailManager _gameFailManager;
    private SpinEvents _spinEvents;

    [Inject]
    private void Construct(GameFailManager gameFailManager, SpinEvents spinEvents)
    {
        _gameFailManager = gameFailManager;
        _spinEvents = spinEvents;
    }
    
    protected override void OnClick()
    {
        _gameFailManager.ReviveAndClosePopup();
        _spinEvents.FireOnSpinActionsEnd();
    }
}

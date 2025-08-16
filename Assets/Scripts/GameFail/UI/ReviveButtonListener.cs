using Zenject;

public class ReviveButtonListener : BaseButtonListener
{
    private const string COIN = "Coin";
    
    private GameFailManager _gameFailManager;
    private SpinEvents _spinEvents;
    private InventoryManager _inventoryManager;

    private int _cost = 20;
    
    [Inject]
    private void Construct(GameFailManager gameFailManager, SpinEvents spinEvents, InventoryManager inventoryManager)
    {
        _gameFailManager = gameFailManager;
        _spinEvents = spinEvents;
        _inventoryManager = inventoryManager;
    }
    
    protected override void OnClick()
    {
        var coinData = _inventoryManager.GetInventoryDataByName(COIN);
        var coinDataUI = _inventoryManager.GetDataUIByName(COIN);
        
        if(coinData == null) return;
        if(coinData.Amount < _cost) return;
        
        
        coinData.Amount -= _cost;
        coinDataUI.Amount -= _cost;
        coinDataUI.Text.text = coinDataUI.Amount.ToString();
        
        _gameFailManager.ReviveAndClosePopup();
        _spinEvents.FireOnSpinActionsEnd();
    }
}

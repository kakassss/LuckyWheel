using TMPro;
using UnityEngine;
using Zenject;

public class ZoneUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _superZoneText;
    [SerializeField] private TMP_Text _zoneText;
    
    private SpinIndexManager _spinIndexManager;
    private SpinEvents _spinEvents;

    private int _superZone = 30;
    private int _zone = 5;
    
    [Inject]
    private void Construct(SpinIndexManager spinIndexManager, SpinEvents spinEvents)
    {
        _spinIndexManager = spinIndexManager;
        _spinEvents = spinEvents;
    }

    private void OnEnable()
    {
        _spinEvents.AddOnSpinActionsEnd(SetUI);
    }

    private void OnDisable()
    {
        _spinEvents.RemoveOnSpinActionsEnd(SetUI);
    }

    private void SetUI()
    {
        if(_spinIndexManager.CurrentSpinIndex == 1) return;
        
        var currentIndex = _spinIndexManager.GetCurrentSpinIndex();

        if (currentIndex == 1)
        {
            _zone += 5;
            _zoneText.text = _zone.ToString();
        }

        if (currentIndex == 2)
        {
            _superZone += 30;
            _superZoneText.text = _superZone.ToString();
        }

    }
    
    
}

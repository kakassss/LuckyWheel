using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StageScrollBarUI : MonoBehaviour
{
    [SerializeField] private List<Image> _stageImages;
    [SerializeField] private List<TMP_Text> _stageTexts;

    [Header("Active Colors")]
    [SerializeField] private Color _textColorDefaultBlack;
    
    [SerializeField] private Color _textColorDefault;
    [SerializeField] private Color _textColorZone;
    [SerializeField] private Color _textColorSuperZone;
    
    [SerializeField] private Color _imageColorDefault;
    [SerializeField] private Color _imageColorZone;
    [SerializeField] private Color _imageColorSuperZone;
    
    [Header("Inactive Colors")]
    [SerializeField] private Color _textInactiveColorDefault;
    [SerializeField] private Color _textInactiveColorZone;
    [SerializeField] private Color _textInactiveColorSuperZone;
    
    private int _stageIndex = 1;
    
    private SpinEvents _spinEvents;
    private SpinIndexManager _spinIndexManager;

    [Inject]
    private void Construct(SpinEvents spinEvents, SpinIndexManager spinIndexManager)
    {
        _spinEvents = spinEvents;
        _spinIndexManager = spinIndexManager;
    }
        
    private void Awake()
    {
        SetStageUI();
    }

    private void SetStageUI()
    {
        for (int i = 0; i < _stageTexts.Count; i++)
        {
            _stageTexts[i].text = _stageIndex.ToString();
            SetUIColor(_stageTexts[i],_stageImages[i],_stageIndex);
            _stageIndex++;
        }
    }
    
    private void OnEnable()
    {
        _spinEvents.AddSpinMovementEnd(SetInActiveColors);
    }

    private void OnDisable()
    {
        _spinEvents.RemoveSpinMovementEnd(SetInActiveColors);
    }
    
    private void SetInActiveColors()
    {
        if (_spinIndexManager.CurrentSpinIndex == 2)
        {
            _stageTexts[0].color = _textInactiveColorZone;
            return;
        }
        
        if ((_spinIndexManager.CurrentSpinIndex) % 30 == 0)
        {
            _stageTexts[_spinIndexManager.CurrentSpinIndex -1].color = _textInactiveColorSuperZone;
            _stageTexts[_spinIndexManager.CurrentSpinIndex - 2].color = _textInactiveColorDefault;
            return;
        }

        if ((_spinIndexManager.CurrentSpinIndex) % 5 == 0)
        {
            _stageTexts[_spinIndexManager.CurrentSpinIndex - 1].color = _textInactiveColorZone;
            _stageTexts[_spinIndexManager.CurrentSpinIndex - 2].color = _textInactiveColorDefault;
            return;
        }
        
        _stageTexts[_spinIndexManager.CurrentSpinIndex -1].color = _textColorDefaultBlack;
        if((_spinIndexManager.CurrentSpinIndex -1) % 5 != 0 || (_spinIndexManager.CurrentSpinIndex -1) % 30 != 0)
            _stageTexts[_spinIndexManager.CurrentSpinIndex - 2].color = _textInactiveColorDefault;
    }

    private void SetUIColor(TMP_Text text,Image image,int index)
    {
        //First stage zone
        if (index == 1)
        {
            text.color = _textColorZone;
            image.color = _imageColorZone;
            return;
        }
        
        if (index % 30 == 0)
        {
            text.color = _textColorSuperZone;
            image.color = _imageColorSuperZone;
            return;
        }

        if (index % 5 == 0)
        {
            text.color = _textColorZone;
            image.color = _imageColorZone;
            return;
        }
        
        text.color = _textColorDefault;
        image.color = _imageColorDefault;
    }
    
}

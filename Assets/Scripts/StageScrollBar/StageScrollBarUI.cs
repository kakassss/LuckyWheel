using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageScrollBarUI : MonoBehaviour
{
    [SerializeField] private List<Image> _stageImages;
    [SerializeField] private List<TMP_Text> _stageTexts;

    [SerializeField] private Color _textColorDefault;
    [SerializeField] private Color _textColorZone;
    [SerializeField] private Color _textColorSuperZone;
    
    [SerializeField] private Color _imageColorDefault;
    [SerializeField] private Color _imageColorZone;
    [SerializeField] private Color _imageColorSuperZone;
    
    private int _stageIndex = 1;

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

    private void SetUIColor(TMP_Text text,Image image,int index)
    {
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

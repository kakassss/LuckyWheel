using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class StageScrollBarAnimation : MonoBehaviour
{
    private const int POSX_MOVEMENT = -125;
    
    [SerializeField] private RectTransform _scrollBarTexts;
    [SerializeField] private RectTransform _scrollBarImages;
    
    private SpinEvents _spinEvents;

    [Inject]
    private void Construct(SpinEvents spinEvents)
    {
        _spinEvents = spinEvents;
    }

    private void OnEnable()
    {
        _spinEvents.AddSpinMovementEnd(Movement);
    }

    private void OnDisable()
    {
        _spinEvents.RemoveSpinMovementEnd(Movement);
    }

    private void Movement()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetAutoKill(true);
        
        sequence.Join(_scrollBarTexts.DOAnchorPos(new Vector2(_scrollBarTexts.anchoredPosition.x + POSX_MOVEMENT,_scrollBarTexts.anchoredPosition.y), .5f));
        sequence.Join(_scrollBarImages.DOAnchorPos(new Vector2(_scrollBarImages.anchoredPosition.x + POSX_MOVEMENT,_scrollBarImages.anchoredPosition.y), .5f));
    }
}

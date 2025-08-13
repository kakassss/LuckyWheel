using DG.Tweening;
using UnityEngine;

public class StageScrollBarAnimation : MonoBehaviour
{
    private const int POSX_MOVEMENT = -125;
    
    [SerializeField] private RectTransform _scrollBarTexts;
    [SerializeField] private RectTransform _scrollBarImages;
    
    private void Movement()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetAutoKill(true);
        
        sequence.Join(_scrollBarTexts.DOAnchorPos(new Vector2(_scrollBarTexts.anchoredPosition.x + POSX_MOVEMENT,_scrollBarTexts.anchoredPosition.y), .5f));
        sequence.Join(_scrollBarImages.DOAnchorPos(new Vector2(_scrollBarImages.anchoredPosition.x + POSX_MOVEMENT,_scrollBarImages.anchoredPosition.y), .5f));
    }
}

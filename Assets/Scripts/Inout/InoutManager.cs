using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;


public class InoutManager : IDisposable
{
    private const int INOUTOBJECT_AMOUNT = 5;
    
    private readonly ObjectPool<InoutObject> _inoutObjectPool;
    private readonly SpinRewardManager _spinRewardManager;
    private readonly SpinEvents _spinEvents;
    private readonly InventoryManager _inventoryManager;
    
    private List<InoutObject> _inoutObjects = new List<InoutObject>();
    private float _rangeX = 200f;
    private float _rangeY = 200f;
    
    private float _scaleAmount = 1.35f;
    private float _scaleDuration = 0.25f;
    
    private InoutManager(ObjectPool<InoutObject> inoutObjectPool, SpinRewardManager spinRewardManager,
        SpinEvents spinEvents, InventoryManager inventoryManager)
    {
        _inoutObjectPool = inoutObjectPool;
        _spinRewardManager = spinRewardManager;
        _spinEvents = spinEvents;
        _inventoryManager = inventoryManager;
        
        _spinEvents.AddSpinMovementEnd(StartInout);
    }

    public void Dispose()
    {
        _spinEvents.RemoveSpinMovementEnd(StartInout);
    }

    private void StartInout()
    {
        _inoutObjects.Clear();
        
        for (int i = 0; i < INOUTOBJECT_AMOUNT; i++)
        {
            var inout = _inoutObjectPool.GetFromPool();
            inout.ObjectImage.sprite = _spinRewardManager.CurrentSpinRewardData.Icon;
            
            _inoutObjects.Add(inout);
        }
        
        InoutMovementSequence();
    }

    private void InoutMovementSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetAutoKill(true);

        for (int i = 0; i < _inoutObjects.Count; i++)
        {
            var randomX = Random.Range(-_rangeX, _rangeX);
            var randomY = Random.Range(-_rangeY, _rangeY);
            
            Vector3 targetPos = new Vector3(randomX, randomY, 0);
            
            sequence.Join(_inoutObjects[i].ObjectRect.DOAnchorPos(targetPos, 0.5f));
        }

        sequence.OnComplete(InoutTargetMovementSequence);
    }

    private void InoutTargetMovementSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetAutoKill(true);
        var target = _inventoryManager.GetDataUI(_spinRewardManager.CurrentSpinRewardData);
        
        TextAnimation(target,1f);
        
        for (int i = 0; i < _inoutObjects.Count; i++)
        {
            sequence.Join(_inoutObjects[i].ObjectRect.DOMove(target.transform.position, 0.5f));
        }
        
        sequence.OnComplete((() =>
        {
            for (int i = 0; i < _inoutObjects.Count; i++)
            {
                _inoutObjects[i].gameObject.SetActive(false);
            }
            
            ScaleAnimation(target.image.transform);

            _spinEvents.FireOnSpinActionsEnd();
        }));
    }
    private Tween _textTween;
    private void TextAnimation(InventoryDataUI dataUI, float duration)
    {
        _textTween.SetAutoKill(true);
        _textTween = DOTween.To(() => dataUI.TempAmount, x => {
            dataUI.TempAmount = x;
            dataUI.Text.text = dataUI.TempAmount.ToString();
        }, dataUI.Amount, duration).OnComplete((() => dataUI.TempAmount = dataUI.Amount));

        
    }
    
    private void ScaleAnimation(Transform rectTransform)
    {
        rectTransform.localScale = Vector3.one;
        
        Sequence sequence = DOTween.Sequence();
        sequence.SetAutoKill(true);
        
        sequence.Append(rectTransform.DOScale(_scaleAmount, _scaleDuration).SetEase(Ease.OutQuad));
        sequence.Append(rectTransform.DOScale(1f, _scaleDuration).SetEase(Ease.InQuad));
    }
    
}

using DG.Tweening;
using UnityEngine;

public class SpinMovement
{
    private const int SPIN_ANGLE = 45;
    private const float SPIN_360 = 360;
    private const int SPIN_360AMOUNT = 1;
    
    private Vector3 targetRotation;
    private float duration = 2f;

    private void SetTargetRotation()
    {
        var randomAngleIndex = Random.Range(0, 8);
        var randomAngle = SPIN_ANGLE * randomAngleIndex;
        targetRotation = new Vector3(0, 0, randomAngle);
    }
    
    public void StartMovement(Transform transform)
    {
        SetTargetRotation();
        
        transform.DORotate(targetRotation, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuad);
    }
}

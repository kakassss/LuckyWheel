using UnityEngine;
using Zenject;

public class SpinButtonListener : BaseButtonListener
{
    [SerializeField] private Transform _spinTransform;
    
    private SpinMovement _spinMovement;

    [Inject]
    private void Construct(SpinMovement spinMovement)
    {
        _spinMovement = spinMovement;
    }

    protected override void OnClick()
    {
        _spinMovement.StartMovement(_spinTransform);
    }
}

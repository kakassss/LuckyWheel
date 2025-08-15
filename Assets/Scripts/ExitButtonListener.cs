using UnityEngine.SceneManagement;
using Zenject;

public class ExitButtonListener : BaseButtonListener
{
    private SpinIndexManager _spinIndexManager;
    private SpinMovementManager _spinMovementManager;
    
    [Inject]
    private void Construct(SpinIndexManager spinIndexManager, SpinMovementManager spinMovementManager)
    {
        _spinIndexManager = spinIndexManager;
        _spinMovementManager = spinMovementManager;
    }
    
    protected override void OnClick()
    {
        if (_spinIndexManager.CurrentSpinIndex == 1 || 
            _spinIndexManager.CurrentSpinIndex % 5 == 0 || 
            _spinIndexManager.CurrentSpinIndex % 30 == 0)
        {
            if(_spinMovementManager.IsSpinning == true) return;
        
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

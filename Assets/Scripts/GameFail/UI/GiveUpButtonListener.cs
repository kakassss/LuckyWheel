using UnityEngine.SceneManagement;

public class GiveUpButtonListener : BaseButtonListener
{
    protected override void OnClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

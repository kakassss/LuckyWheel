using UnityEngine;

public class GameFailManager
{
    private readonly GameObject _popupFail;
    public bool Fail;
    
    public GameFailManager(GameObject popupFail)
    {
        _popupFail = popupFail;
    }
    
    public void GameFailTrigger()
    {
        Fail = true;
    }

    public void OpenGameFailPopup()
    {
        _popupFail.SetActive(true);
    }

    public void ReviveAndClosePopup()
    {
        Fail = false;
        _popupFail.SetActive(false);
    }
}

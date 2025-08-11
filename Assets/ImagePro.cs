using UnityEngine.UI;

public class ImagePro : Image
{
    protected override void OnValidate()
    {
        maskable = false;
        raycastTarget = false;
    }
}

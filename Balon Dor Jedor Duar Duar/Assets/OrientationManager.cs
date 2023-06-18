using UnityEngine;
public class OrientationManager : MonoBehaviour
{
    private Quaternion landscapeLeftRotation = Quaternion.Euler(0f, 0f, -90f);
    private Quaternion landscapeRightRotation = Quaternion.Euler(0f, 0f, 90f);

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            transform.parent.rotation = landscapeLeftRotation;
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            transform.parent.rotation = landscapeRightRotation;
        }
    }
}

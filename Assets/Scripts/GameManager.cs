using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool PopupIsAlowed;
    public void PopupAllowed()
    {
        PopupIsAlowed = Popups;
    }
}
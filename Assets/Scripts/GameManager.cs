using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool CrossHair;

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.P))
        {
            Popups = !Popups;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            CrossHair = !CrossHair;
        }
    }
}
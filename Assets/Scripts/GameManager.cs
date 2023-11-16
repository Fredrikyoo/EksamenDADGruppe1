using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool CrossHair;
    public bool PauseScreenActive;
    bool RememberCrossHair;
    public GameObject PauseScreen;

    void Start()
    {
        PauseScreenActive = false;
        PauseScreen.SetActive(false);
    }
    public void DataBladEnable()
    {
        Popups = !Popups;
    }
    public void CrossHairEnable()
    {
        CrossHair = !CrossHair;
    }
    public void ReturnToSim()
    {
        PauseScreen.SetActive(false);
        PauseScreenActive = false;
        CrossHair = RememberCrossHair;
        Debug.Log("test");
    }

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.P))
        {
            RememberCrossHair = CrossHair;
            if(PauseScreenActive == false)
            {
                PauseScreenActive = true;
                CrossHair = false;
                PauseScreen.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            CrossHair = !CrossHair;
        }
    }
}
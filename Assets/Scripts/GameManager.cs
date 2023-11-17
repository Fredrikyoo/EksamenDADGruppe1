using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool CrossHair;
    public bool PauseScreenActive;
    bool RememberCrossHair;
    public GameObject PauseScreen;
    public GameObject OptionsScreen;

    public GameObject DataBladButton;
    public GameObject CrossHairButton;
    //public GameObject DataBladButton;
    //public GameObject CrossHairButton;

    TextMeshProUGUI DataBladText;
    TextMeshProUGUI CrossHairText; 
    
    void Start()
    {
        PauseScreenActive = false;
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(false);

        DataBladText = DataBladButton.GetComponent<TextMeshProUGUI>();
        CrossHairText = CrossHairButton.GetComponent<TextMeshProUGUI>();

        RememberCrossHair = CrossHair;
        UpdateSettings();
    }
    public void DataBladEnable()
    {
        Popups = !Popups;
        UpdateSettings();
    }
    public void CrossHairEnable()
    {
        RememberCrossHair = !RememberCrossHair;
        UpdateSettings();
    }
    public void ReturnToSim()
    {
        PauseScreen.SetActive(false);
        PauseScreenActive = false;
        CrossHair = RememberCrossHair;
    }
    public void GoToOptions()
    {
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void ReturnOptions()
    {
        OptionsScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void UpdateSettings()
    {
        if(Popups == true){
            DataBladText.text = "On";
        } else {
            DataBladText.text = "Off";
        }
        if(RememberCrossHair == true){
            CrossHairText.text = "On";
        } else {
            CrossHairText.text = "Off";
        }
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            DataBladEnable();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            CrossHairEnable();
        }
        StartPage.CrossHairActive = CrossHair;
        StartPage.DataBladActive = Popups;
    }
}
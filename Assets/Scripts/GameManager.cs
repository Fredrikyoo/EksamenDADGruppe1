using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool CrossHair;
    public bool LiveDatas;
    public bool Extras;
    public bool PauseScreenActive;
    bool RememberCrossHair;
    public GameObject PauseScreen;
    public GameObject OptionsScreen;

    public GameObject DataBladButton;
    public GameObject CrossHairButton;
    public GameObject LiveDataButton;
    public GameObject ExtrasButton;

    public GameObject CrossHairGameObject;
    public GameObject ExtrasGameObject;

    TextMeshProUGUI DataBladText;
    TextMeshProUGUI CrossHairText; 
    TextMeshProUGUI LiveDataText;
    TextMeshProUGUI ExtrasText; 
    
    void Start()
    {
        PauseScreenActive = false;
        PauseScreen.SetActive(false);
        OptionsScreen.SetActive(false);

        DataBladText = DataBladButton.GetComponent<TextMeshProUGUI>();
        CrossHairText = CrossHairButton.GetComponent<TextMeshProUGUI>();
        LiveDataText = LiveDataButton.GetComponent<TextMeshProUGUI>();
        ExtrasText = ExtrasButton.GetComponent<TextMeshProUGUI>();

        Popups = SettingsStateController.DataBladSettingController;
        LiveDatas = SettingsStateController.LiveDataSettingController;
        CrossHair = SettingsStateController.CrossHairSettingController;
        Extras = SettingsStateController.ExtrasSettingController;

        RememberCrossHair = CrossHair;
        UpdateSettings();
    }
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.P))
        {
            RememberCrossHair = CrossHair;

            if(PauseScreenActive == false)
            {
                PauseScreenActive = true;
                UpdateSettings();
                CrossHair = false;
                PauseScreen.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            RememberCrossHair = CrossHair;
            if(PauseScreenActive == false)
            {
                PauseScreenActive = true;
                UpdateSettings();
                CrossHair = false;
                OptionsScreen.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            DataBladEnable();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CrossHairEnable();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LiveDataEnable();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ExtrasEnable();
        }
        Debug.Log("crosshair "+ CrossHair);
        Debug.Log("remember crosshair "+ RememberCrossHair);
    }

    public void DataBladEnable()
    {
        Popups = !Popups;
        Debug.Log("DatabaldEnable");
        UpdateSettings();
    }
    public void CrossHairEnable()
    {
        if(PauseScreenActive == true){
            RememberCrossHair = !RememberCrossHair;
        } else {
            CrossHair = !CrossHair;
        }
        Debug.Log("CrossHairEnable");
        UpdateSettings();
    }
    public void LiveDataEnable()
    {
        LiveDatas = !LiveDatas;
        Debug.Log("LiveDataEnable");
        UpdateSettings();
    }
    public void ExtrasEnable()
    {
        Extras = !Extras;
        Debug.Log("ExtrasEnable");
        UpdateSettings();
    }

    public void ReturnToSim()
    {
        PauseScreen.SetActive(false);
        PauseScreenActive = false;
        CrossHair = RememberCrossHair;
        if(CrossHair == true){
            CrossHairGameObject.SetActive(true);
        } else {
            CrossHairGameObject.SetActive(false);
        }
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
        if(PauseScreenActive == true){
            if(RememberCrossHair == true){
                CrossHairText.text = "On";
            } else {
                CrossHairText.text = "Off";
            }
            CrossHairGameObject.SetActive(false);
        } else {
            if(CrossHair == true){
                CrossHairGameObject.SetActive(true);
            } else {
                CrossHairGameObject.SetActive(false);
            }
        }
        if(Extras == true){
            ExtrasText.text = "On";
            ExtrasGameObject.SetActive(true);
        } else {
            ExtrasText.text = "Off";
            ExtrasGameObject.SetActive(false);
        }
        if(LiveDatas == true){
            LiveDataText.text = "On";
        } else {
            LiveDataText.text = "Off";
        }
    }
}
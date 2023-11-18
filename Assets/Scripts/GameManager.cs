using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool Popups;
    public bool CrossHair;
    public bool LiveData;
    public bool Extras;
    public bool PauseScreenActive;
    bool RememberCrossHair;
    public GameObject PauseScreen;
    public GameObject OptionsScreen;

    public GameObject DataBladButton;
    public GameObject CrossHairButton;
    public GameObject LiveDataButton;
    public GameObject ExtrasButton;

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
                CrossHair = false;
                PauseScreen.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            ExtrasEnable();
        }
    }

    public void DataBladEnable()
    {
        Popups = !Popups;
        Debug.Log("DatabaldEnable");
        UpdateSettings();
    }
    public void CrossHairEnable()
    {
        RememberCrossHair = !RememberCrossHair;
        Debug.Log("CrossHairEnable");
        UpdateSettings();
    }
    public void LiveDataEnable()
    {
        LiveData = !LiveData;
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
        if(Extras == true){
            ExtrasText.text = "On";
        } else {
            ExtrasText.text = "Off";
        }
        if(LiveData == true){
            LiveDataText.text = "On";
        } else {
            LiveDataText.text = "Off";
        }
    }
}
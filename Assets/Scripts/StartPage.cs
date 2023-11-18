using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartPage : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject OptionsScreen;
    public GameObject InfoScreen;

    public bool CrossHairActive;
    public bool DataBladActive;
    public bool ExtrasActive;
    public bool LiveDataActive;

    public GameObject DataBladButton;
    public GameObject CrossHairButton;
    public GameObject LiveDataButton;
    public GameObject ExtrasButton;

    TextMeshProUGUI DataBladText;
    TextMeshProUGUI CrossHairText;
    TextMeshProUGUI ExtrasText;
    TextMeshProUGUI LiveDataText;

    void Start(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
        InfoScreen.SetActive(false);

        DataBladText = DataBladButton.GetComponent<TextMeshProUGUI>();
        CrossHairText = CrossHairButton.GetComponent<TextMeshProUGUI>();
        LiveDataText = LiveDataButton.GetComponent<TextMeshProUGUI>();
        ExtrasText = ExtrasButton.GetComponent<TextMeshProUGUI>();

        UpdateSettingsStart();
    }

    public void StartSim(){
        SettingsStateController.DataBladSettingController = DataBladActive;
        SettingsStateController.LiveDataSettingController = LiveDataActive;
        SettingsStateController.CrossHairSettingController = CrossHairActive;
        SettingsStateController.ExtrasSettingController = ExtrasActive;
        SceneManager.LoadScene("Playground");
    }
    public void OptionsSim(){
        StartScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void ReturnOptionsSim(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }
    public void InfoSim(){
        StartScreen.SetActive(false);
        InfoScreen.SetActive(true);
    }
    public void ReturnInfoSim(){
        StartScreen.SetActive(true);
        InfoScreen.SetActive(false);
    }
    public void ExitSim(){
        Debug.Log("supposed to exit game");
    }

    public void DataBladSetting(){
        if(DataBladActive == false){
            DataBladActive = true;
            DataBladText.text = "On";
        } else {
            DataBladActive = false;
            DataBladText.text = "Off";
        }
    }
    public void CrossHairSetting(){
        if(CrossHairActive == false){
            CrossHairActive = true;
            CrossHairText.text = "On";
        } else {
            CrossHairActive = false;
            CrossHairText.text = "Off";
        }
    }
    public void LiveDataSetting(){
        if(LiveDataActive == false){
            LiveDataActive = true;
            LiveDataText.text = "On";
        } else {
            LiveDataActive = false;
            LiveDataText.text = "Off";
        }
    }
    public void ExtrasSetting(){
        if(ExtrasActive == false){
            ExtrasActive = true;
            ExtrasText.text = "On";
        } else {
            ExtrasActive = false;
            ExtrasText.text = "Off";
        }
    }

    public void UpdateSettingsStart(){
        if(DataBladActive == true){
            DataBladText.text = "On";
        } else {
            DataBladText.text = "Off";
        }
        if(CrossHairActive == true){
            CrossHairText.text = "On";
        } else {
            CrossHairText.text = "Off";
        }
        if(ExtrasActive == true){
            ExtrasText.text = "On";
        } else {
            ExtrasText.text = "Off";
        }
        if(LiveDataActive == true){
            LiveDataText.text = "On";
        } else {
            LiveDataText.text = "Off";
        }
    }
}
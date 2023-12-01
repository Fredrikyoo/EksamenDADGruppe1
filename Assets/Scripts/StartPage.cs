using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections.Generic;

public class StartPage : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject OptionsScreen;
    public GameObject InfoScreen;

    bool CrossHairActive;
    bool DataBladActive;
    bool ExtrasActive;
    bool LiveDataActive;

    public GameObject DataBladButton;
    public GameObject CrossHairButton;
    public GameObject LiveDataButton;
    public GameObject ExtrasButton;

    public GameObject StartSimButton;
    public GameObject StartOptionsButton;
    public GameObject StartInfoButton;
    public GameObject StartExitButton;

    TextMeshProUGUI DataBladText;
    TextMeshProUGUI CrossHairText;
    TextMeshProUGUI ExtrasText;
    TextMeshProUGUI LiveDataText;

    TextMeshProUGUI StartSimButtonText;
    TextMeshProUGUI StartOptionsButtonText;
    TextMeshProUGUI StartInfoButtonText;
    TextMeshProUGUI StartExitButtonText;

    public List<TextMeshProUGUI> StartList = new List<TextMeshProUGUI>();

    void Start(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
        InfoScreen.SetActive(false);

        DataBladText = DataBladButton.GetComponent<TextMeshProUGUI>();
        CrossHairText = CrossHairButton.GetComponent<TextMeshProUGUI>();
        LiveDataText = LiveDataButton.GetComponent<TextMeshProUGUI>();
        ExtrasText = ExtrasButton.GetComponent<TextMeshProUGUI>();

        StartSimButtonText = StartSimButton.GetComponent<TextMeshProUGUI>();
        StartOptionsButtonText = StartOptionsButton.GetComponent<TextMeshProUGUI>();
        StartInfoButtonText = StartInfoButton.GetComponent<TextMeshProUGUI>();
        StartExitButtonText = StartExitButton.GetComponent<TextMeshProUGUI>();
        StartList.Add(StartSimButtonText); StartList.Add(StartOptionsButtonText); StartList.Add(StartInfoButtonText); StartList.Add(StartExitButtonText);

        UpdateSettingsStart();
        UpdateScalingStart(StartSimButton, new Vector3(-Screen.width / 7f, Screen.height/4f, 0));
        UpdateScalingStart(StartOptionsButton, new Vector3(-Screen.width / 7f, Screen.height/8f, 0));
        UpdateScalingStart(StartInfoButton, new Vector3(-Screen.width / 7f, 0, 0));
        UpdateScalingStart(StartExitButton, new Vector3(-Screen.width / 7f, -Screen.height/8f, 0));
        
    }

    public void StartSim(){
        //Sender data til controller før vi starter simulatoren
        SettingsStateController.DataBladSettingController = DataBladActive;
        SettingsStateController.LiveDataSettingController = LiveDataActive;
        SettingsStateController.CrossHairSettingController = CrossHairActive;
        SettingsStateController.ExtrasSettingController = ExtrasActive;
        SceneManager.LoadScene("Playground");
    }
    public void OptionsSim(){
        StartScreen.SetActive(false);
        OptionsScreen.SetActive(true);
        InfoScreen.SetActive(false);
    }
    public void MainSim(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
        InfoScreen.SetActive(false);
    }
    public void InfoSim(){
        StartScreen.SetActive(false);
        InfoScreen.SetActive(true);
        OptionsScreen.SetActive(false);
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

    void UpdateSettingsStart(){
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
    void UpdateScalingStart(GameObject obj, Vector3 offset)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = offset;
        Debug.Log(Screen.width);
        if(Screen.width > 2400){
            rectTransform.sizeDelta = new Vector2(1000, 1000);
        }else if(Screen.width > 1200){
            rectTransform.sizeDelta = new Vector2(450, 100);
        }else if(Screen.width > 800){
            rectTransform.sizeDelta = new Vector2(350, 70);
        }else{
            rectTransform.sizeDelta = new Vector2(200, 200);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject OptionsScreen;

    public static bool CrossHairActive;
    public static bool DataBladActive;

    void Start(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }
    void Update(){
        if(CrossHairActive == true){
            Debug.Log("CrossHairActive");
        }
    }
    public void StartSim(){
        SceneManager.LoadScene("Playground");
    }
    public void OptionsSim(){
        StartScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }
    public void DataBladSetting(){
        FindObjectOfType<GameManager>().DataBladEnable();
    }
    public void CrossHairSetting(){
        FindObjectOfType<GameManager>().CrossHairEnable();
    }
    public void ReturnOptionsSim(){
        StartScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }
    public void ExitSim(){
        //SceneManager.LoadScene("Playground");
        Debug.Log("supposed to exit game");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeSim(){
        FindObjectOfType<GameManager>().ReturnToSim();
    }
    public void OptionsSim(){
        FindObjectOfType<GameManager>().GoToOptions();
    }
    public void ReturnFromOptionsSim(){
        FindObjectOfType<GameManager>().ReturnOptions();
    }
    public void BackToStartPage(){
        FindObjectOfType<StartPage>().MainSim();
    }
    public void ExitSim(){
        SceneManager.LoadScene("StartPage");
        Debug.Log("escape");
    }

    public void DataBladSetting(){
        FindObjectOfType<GameManager>().DataBladEnable();
    }
    public void CrossHairSetting(){
        FindObjectOfType<GameManager>().CrossHairEnable();
    }
    public void LiveDataSetting(){
        FindObjectOfType<GameManager>().LiveDataEnable();
    }
    public void ExtrasSetting(){
        FindObjectOfType<GameManager>().ExtrasEnable();
    }
}

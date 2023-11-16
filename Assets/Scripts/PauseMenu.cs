using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeSim(){
        FindObjectOfType<GameManager>().ReturnToSim();
        //FindObjectOfType<StarterAssetsInputs>().ReturnFromPause();
        Debug.Log("resume");
    }
    public void OptionsSim(){
        SceneManager.LoadScene("Settings");
        Debug.Log("options");
    }
    public void ExitSim(){
        SceneManager.LoadScene("StartPage");
        Debug.Log("escape");
    }
}

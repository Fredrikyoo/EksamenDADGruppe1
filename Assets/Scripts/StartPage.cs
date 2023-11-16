using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public void StartSim(){
        SceneManager.LoadScene("Playground");
    }
    public void OptionsSim(){
        SceneManager.LoadScene("Settings");
    }
    public void ExitSim(){
        //SceneManager.LoadScene("Playground");
    }
}
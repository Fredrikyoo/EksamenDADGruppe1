using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettingsScript : MonoBehaviour
{
    public void StartSim(){
        SceneManager.LoadScene("Playground");
    }
    public void StartScreen(){
        SceneManager.LoadScene("StartPage");
    }
}

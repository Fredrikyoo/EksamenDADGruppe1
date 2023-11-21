using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LiveDataValues : MonoBehaviour
{
    public GameObject DG1Button;
    public GameObject UDG1Button;
    public GameObject ADG1Button;
    public GameObject COSqDG1Button;
    public GameObject FDG1Button;
    public GameObject PDG1Button;

    TextMeshProUGUI DG1Text;
    TextMeshProUGUI UDG1Text;
    TextMeshProUGUI ADG1Text; 
    TextMeshProUGUI COSqDG1Text;
    TextMeshProUGUI FDG1Text;
    TextMeshProUGUI PDG1Text;  
    
    void Start(){
        DG1Text = DG1Button.GetComponent<TextMeshProUGUI>();
        UDG1Text = UDG1Button.GetComponent<TextMeshProUGUI>();
        ADG1Text = ADG1Button.GetComponent<TextMeshProUGUI>();
        COSqDG1Text = COSqDG1Button.GetComponent<TextMeshProUGUI>();
        FDG1Text = FDG1Button.GetComponent<TextMeshProUGUI>();
        PDG1Text = PDG1Button.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
         if(Application.internetReachability==NetworkReachability.NotReachable){
            DG1Text.text = "Connected to database";
        } else if(Application.internetReachability==NetworkReachability.ReachableViaLocalAreaNetwork) {
            DG1Text.text = "Disconnected from database";
        }
    }
}

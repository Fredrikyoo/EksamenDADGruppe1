using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupDatablad : MonoBehaviour
{
    public GameObject Popup;
    public GameObject GameManagement;

    void Start(){
        Popup.SetActive(false);
    }
    void OnTriggerEnter(Collider other){
        bool PopupAllowed = GameManagement.GetComponent<GameManager>().Popups;
        //henter verdi fra gamemanager og sjekker om Popups er aktive eller ikke
        if(PopupAllowed == true){
            Popup.SetActive(true);
        } else {
            Debug.Log("Popup is diasbled");
        }
    }
    void OnTriggerExit(Collider other){
        Popup.SetActive(false);
    }
}

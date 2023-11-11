using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupDatablad : MonoBehaviour
{
    public GameObject Popup;
    public GameObject GameManager;

    void Start(){
        Popup.SetActive(false);
        //PopupAllowed = GameManager.GetComponent<>(GameManager);
    }
    void OnTriggerEnter(Collider other){
        Popup.SetActive(true);
    }
    void OnTriggerExit(Collider other){
        Popup.SetActive(false);
    }
}

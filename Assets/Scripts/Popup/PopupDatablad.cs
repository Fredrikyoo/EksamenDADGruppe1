using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupDatablad : MonoBehaviour
{
    public GameObject Popup;
    public GameObject LiveData;
    public GameObject GameManagement;

    void Start(){
        Popup.SetActive(false);
        LiveData.SetActive(false);
    }
    void OnTriggerEnter(Collider other){
        bool PopupAllowed = GameManagement.GetComponent<GameManager>().Popups;
        bool LiveDataAllowed = GameManagement.GetComponent<GameManager>().LiveDatas;

        if(PopupAllowed == true && LiveDataAllowed == true){
            Debug.Log("Unique Case");
            LiveData.SetActive(true);
            Popup.SetActive(true);

            MoveObject(Popup, new Vector3(220, 0, 0));
            MoveObject(LiveData, new Vector3(-220, 0, 0));
        } 
        if(PopupAllowed == false && LiveDataAllowed == true){
            LiveData.SetActive(true);
        } 
        if(PopupAllowed == true && LiveDataAllowed == false){
            Popup.SetActive(true);
        } 
    }
    void OnTriggerExit(Collider other){
        Popup.SetActive(false);
        LiveData.SetActive(false);
        MoveObjectBack(Popup, new Vector3(0, 0, 0));
        MoveObjectBack(LiveData, new Vector3(0, 0, 0));
    }
    void MoveObject(GameObject obj, Vector3 offset)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            Debug.Log("Before Move - " + obj.name + " position: " + rectTransform.anchoredPosition3D);
            rectTransform.anchoredPosition3D += offset;
            Debug.Log("After Move - " + obj.name + " position: " + rectTransform.anchoredPosition3D);
        }
    }
    void MoveObjectBack(GameObject obj, Vector3 offset)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition3D = offset;
        }
    }
}

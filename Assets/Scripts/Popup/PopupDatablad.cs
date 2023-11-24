using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupDatablad : MonoBehaviour
{
    public GameObject Popup;
    public GameObject LiveData;
    public GameObject CrossHairTempRemove;
    public GameObject GameManagement;

    void Start(){
        Popup.SetActive(false);
        LiveData.SetActive(false);
    }
    void OnTriggerEnter(Collider other){
        bool PopupAllowed = GameManagement.GetComponent<GameManager>().Popups;
        bool LiveDataAllowed = GameManagement.GetComponent<GameManager>().LiveDatas;
        if(gameObject.name == "DG1" || gameObject.name == "DG2"){
            if(PopupAllowed == true && LiveDataAllowed == true){
            //putting two pages beside eachother
            LiveData.SetActive(true);
            Popup.SetActive(true);

            MoveObject(Popup, new Vector3(220, 0, 0));
            MoveObject(LiveData, new Vector3(-220, 0, 0));
            } 
            if(PopupAllowed == false && LiveDataAllowed == true){
                LiveData.SetActive(true);
                CrossHairTempRemove.SetActive(false);
            } 
            if(PopupAllowed == true && LiveDataAllowed == false){
                Popup.SetActive(true);
                CrossHairTempRemove.SetActive(false);
            }
        } else {
            if(PopupAllowed == true){
                Popup.SetActive(true);
                CrossHairTempRemove.SetActive(false);
            }
        }
         
    }
    void OnTriggerExit(Collider other){
        bool CrossHairTempReturn = GameManagement.GetComponent<GameManager>().CrossHair;
        if (CrossHairTempReturn == true){
            CrossHairTempRemove.SetActive(true);
        } else {
            CrossHairTempRemove.SetActive(false);
        }
        Popup.SetActive(false);
        LiveData.SetActive(false);
        MoveObject(Popup, new Vector3(0, 0, 0));
        MoveObject(LiveData, new Vector3(0, 0, 0));
    }
    void MoveObject(GameObject obj, Vector3 offset)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = offset;
    }
}

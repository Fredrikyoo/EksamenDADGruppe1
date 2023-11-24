using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Raycast : MonoBehaviour
{
    private Renderer _renderer;

    public GameObject Screen;
    public GameObject TE301tmp;
    public GameObject TE302tmp;
    public GameObject TE303tmp;
    public GameObject TE304tmp;
    public GameObject HE101tmp;
    public GameObject HE102tmp;
    public GameObject Statictmp;

    TextMeshProUGUI TE301Text; 
    TextMeshProUGUI TE302Text;     
    TextMeshProUGUI TE303Text;
    TextMeshProUGUI TE304Text;
    TextMeshProUGUI HE101Text;
    TextMeshProUGUI HE102Text;
    TextMeshProUGUI StaticText;

    bool TvOn;
    public List<TextMeshProUGUI> textListTV = new List<TextMeshProUGUI>();

    private void Start(){

        TE301Text = TE301tmp.GetComponent<TextMeshProUGUI>();
        TE302Text = TE302tmp.GetComponent<TextMeshProUGUI>();
        TE303Text = TE303tmp.GetComponent<TextMeshProUGUI>();
        TE304Text = TE304tmp.GetComponent<TextMeshProUGUI>();
        HE101Text = HE101tmp.GetComponent<TextMeshProUGUI>();
        HE102Text = HE102tmp.GetComponent<TextMeshProUGUI>();
        StaticText = Statictmp.GetComponent<TextMeshProUGUI>();
        _renderer = GetComponent<Renderer>();
        textListTV.Add(TE301Text); textListTV.Add(TE302Text); textListTV.Add(TE303Text); textListTV.Add(TE304Text); textListTV.Add(HE101Text); textListTV.Add(HE102Text); 
        TvOn = false;
        TurnTvOff();
    }
    public void OnMouseDown(){
        if(TvOn == false){
            TurnTvOn();
            TvOn = true;
        } else {
            TurnTvOff();
            TvOn = false;
        }
    }
    private void TurnTvOn(){
        Screen.GetComponent<Renderer>().material.color = new Color32(250, 250, 250, 255);
        StaticText.text = "Cooling process water temp innlet: \n Cooling process water temp outlet: \n Cooling water temp innlet: \n Cooling water temp outlet: \nAir temp machine room: \n Air humid machine room:";
        for(int i = 0; i < textListTV.Count; i += 1){
            textListTV[i].text = "cold";
        }
    }
    private void TurnTvOff(){
        Screen.GetComponent<Renderer>().material.color = new Color32(20, 20, 20, 255);
        StaticText.text = "";
        for(int i = 0; i < textListTV.Count; i += 1){
            textListTV[i].text = "";
        }
    }
}

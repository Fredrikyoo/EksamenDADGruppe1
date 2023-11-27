using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;
using System.Collections.Generic;

public class Raycast : MonoBehaviour
{
    private Renderer _renderer;

    public GameObject Screen;
    public GameObject TE301tmp;
    public GameObject TE302tmp;
    public GameObject TE303tmp;
    public GameObject TE304tmp;
    public GameObject TE101tmp;
    public GameObject HE102tmp;
    public GameObject Statictmp;
    public GameObject GameManagement;

    TextMeshProUGUI TE301Text; 
    TextMeshProUGUI TE302Text;     
    TextMeshProUGUI TE303Text;
    TextMeshProUGUI TE304Text;
    TextMeshProUGUI TE101Text;
    TextMeshProUGUI HE102Text;
    TextMeshProUGUI StaticText;

    private string url;
    bool TvOn;
    public List<TextMeshProUGUI> textListTV = new List<TextMeshProUGUI>();

    private void Start(){

        TE301Text = TE301tmp.GetComponent<TextMeshProUGUI>();
        TE302Text = TE302tmp.GetComponent<TextMeshProUGUI>();
        TE303Text = TE303tmp.GetComponent<TextMeshProUGUI>();
        TE304Text = TE304tmp.GetComponent<TextMeshProUGUI>();
        TE101Text = TE101tmp.GetComponent<TextMeshProUGUI>();
        HE102Text = HE102tmp.GetComponent<TextMeshProUGUI>();
        StaticText = Statictmp.GetComponent<TextMeshProUGUI>();
        _renderer = GetComponent<Renderer>();
        textListTV.Add(TE301Text); textListTV.Add(TE302Text); textListTV.Add(TE303Text); textListTV.Add(TE304Text); textListTV.Add(TE101Text); textListTV.Add(HE102Text); 
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
        StaticText.text = "Cooling process water temp inn: \n Cooling process water temp out: \n Cooling water temp inn: \n Cooling water temp out: \n Air temp machine room: \n Air humid machine room:";
        string[] TypeIot = {"723TE301","723TE302","723TE303","723TE304","301TE101","301HE102"};
        string[] TypeMes = {"°C","°C","°C","°C","°C","%"};
        for(int i = 0; i < textListTV.Count; i += 1){
            textListTV[i].text = "No data";
        }
        bool LiveDataAllowed = GameManagement.GetComponent<GameManager>().LiveDatas;                    //finner verdier tilhørende DGX hvis live er aktiv
        if(LiveDataAllowed == true){
            GetValues(textListTV, TypeIot, TypeMes);
        }
    }
    private void TurnTvOff(){
        Screen.GetComponent<Renderer>().material.color = new Color32(20, 20, 20, 255);
        StaticText.text = "";
        for(int i = 0; i < textListTV.Count; i += 1){
            textListTV[i].text = "";
        }
    }

    private void GetValues(List<TextMeshProUGUI> Texts, string[] system, string[] mestyp)
    {                                                      
        for(int i = 0; i < textListTV.Count; i += 1)
        {
            string measurements = GetMeasurementFromDatabase(system[i]);          //henter målinger
            string value = GetMeasurementByIndex(measurements,1);                  //velger ønsket verdi
            float valueTall = float.Parse(value);
            valueTall = Mathf.Round(valueTall * 10.0f) * 0.1f;
            if(i == textListTV.Count-1){
                valueTall = Mathf.Round(valueTall);
            }
            valueTall.ToString();
            textListTV[i].text = valueTall + mestyp[i];
        }
        Debug.Log("Operation Complete");
    }
    private string GetMeasurementFromDatabase(string system){                                                   //func som henter all måling       lr
        url = "http://192.168.38.100/get-iot-data-by-tagname.php?name=" + system +"&amount=1";
        string response;
        using (WebClient client = new WebClient()){
            response = client.DownloadString(url);                              //returne verdi hentet ved å bruke konstruert url
        }
        return response;
    }
    private string GetMeasurementByIndex(string measurements,int index){        //finner målingen vi ønsker
        string[] parts = measurements.Split(',');                               
        return parts[index];                                                    
    }
}

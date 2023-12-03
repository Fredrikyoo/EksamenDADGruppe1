using System.Net;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections.Generic;

public class LiveDataValues : MonoBehaviour
{
    private bool testing;

    public GameObject ConDGXtmp;
    public GameObject UDGXtmp;
    public GameObject PDGXtmp;
    public GameObject QDGXtmp;
    public GameObject FDGXtmp;
    public GameObject VelDGXtmp;
    public GameObject IDGXtmpL1;
    public GameObject IDGXtmpL2;
    public GameObject IDGXtmpL3;
    public GameObject SdhDGXtmp;
    public GameObject RunDGXtmp;
    public GameObject RevDGXtmp;
    public GameObject TagDGXtmp;
    public GameObject StaDG1tmp;
    public GameObject GameManagement;
    public GameObject StaticSetup1tmp;
    public GameObject StaticSetup2tmp;

    TextMeshProUGUI ConDGXText;      
    TextMeshProUGUI UDGXText;      
    TextMeshProUGUI PDGXText;      
    TextMeshProUGUI QDGXText;    
    TextMeshProUGUI FDGXText;     
    TextMeshProUGUI VelDGXText;    
    TextMeshProUGUI IDGXTextL1;    
    TextMeshProUGUI IDGXTextL2;  
    TextMeshProUGUI IDGXTextL3;  
    TextMeshProUGUI SdhDGXText;    
    TextMeshProUGUI RunDGXText;   

    TextMeshProUGUI RevDGXText;     
    TextMeshProUGUI StableText;     
    TextMeshProUGUI TagnameText; 
    TextMeshProUGUI StaticSetup1Text;     
    TextMeshProUGUI StaticSetup2Text;

     
    private string url;
    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    
    void Start(){
        UDGXText = UDGXtmp.GetComponent<TextMeshProUGUI>();
        PDGXText = PDGXtmp.GetComponent<TextMeshProUGUI>();
        QDGXText = QDGXtmp.GetComponent<TextMeshProUGUI>();
        FDGXText = FDGXtmp.GetComponent<TextMeshProUGUI>();
        VelDGXText = VelDGXtmp.GetComponent<TextMeshProUGUI>();
        IDGXTextL1 = IDGXtmpL1.GetComponent<TextMeshProUGUI>();
        IDGXTextL2 = IDGXtmpL2.GetComponent<TextMeshProUGUI>();
        IDGXTextL3 = IDGXtmpL3.GetComponent<TextMeshProUGUI>();
        SdhDGXText = SdhDGXtmp.GetComponent<TextMeshProUGUI>();
        RunDGXText = RunDGXtmp.GetComponent<TextMeshProUGUI>();
        RevDGXText = RevDGXtmp.GetComponent<TextMeshProUGUI>();

        ConDGXText = ConDGXtmp.GetComponent<TextMeshProUGUI>();
        StableText = StaDG1tmp.GetComponent<TextMeshProUGUI>();
        TagnameText = TagDGXtmp.GetComponent<TextMeshProUGUI>();
        StaticSetup1Text = StaticSetup1tmp.GetComponent<TextMeshProUGUI>();
        StaticSetup2Text = StaticSetup2tmp.GetComponent<TextMeshProUGUI>();
        
        textList.Add(UDGXText); textList.Add(PDGXText); textList.Add(QDGXText); textList.Add(FDGXText); textList.Add(VelDGXText); textList.Add(IDGXTextL1); 
        textList.Add(IDGXTextL2); textList.Add(IDGXTextL3); textList.Add(SdhDGXText); textList.Add(RunDGXText); textList.Add(RevDGXText);
    }

    void OnTriggerEnter(Collider other){
        string[] RealDG1 = {"DG1-GEN-V","DG1-LOAD","DG1-LOAD-KVAR","DG1-GEN-FRQ","DG1-VELOC",           //verdier vi kan hente lagt i liste
                    "DG1-I-L1","DG1-I-L2","DG1-I-L3","DG1-SHD","DG1-RUN","DG1-REV-PWR"};
        string[] RealDG2 = {"DG2-GEN-V","DG2-LOAD","DG2-LOAD-KVAR","DG2-GEN-FRQ","DG2-VELOC",
                    "DG2-I-L1","DG2-I-L2","DG2-I-L3","DG2-SHD", "DG2-RUN","DG2-REV-PWR"};
        string[] TypeDGX = {"V","KW","KVAR","HZ","","A","A","A","","",""};
        bool LiveDataAllowed = GameManagement.GetComponent<GameManager>().LiveDatas;                    //finner verdier tilhørende DGX hvis live er aktiv
        if (LiveDataAllowed == true){
            if(gameObject.name == "DG1"){
                GetValues(RealDG1, textList, TypeDGX);
            } else if(gameObject.name == "DG2"){
                GetValues(RealDG2, textList, TypeDGX);
            } else {
                Debug.Log("error");
            }
        }
    }

    private void GetValues(string[] RealDG1, List<TextMeshProUGUI> Texts, string[] type)
    {    
        testing = false; //Ingeniør kan endre denne verdien under testing
        if(testing == false){
            for(int i = 0; i < RealDG1.Length; i += 1)
            {
                string measurements = GetMeasurementFromDatabase(RealDG1[i]);          //henter målinger
                string value = GetMeasurementByIndex(measurements,1);                  //velger ønsket verdi
                textList[i].text = value + type[i];
            }
            if(RevDGXText.text == "1"){
                RevDGXText.text = "ON";
            }else{
                RevDGXText.text = "OFF";
            }
            if(RunDGXText.text == "1"){
                RunDGXText.text = "Running";
            }else{
                RunDGXText.text = "Not running";
            }
            if(SdhDGXText.text == "1"){
                SdhDGXText.text = "On";
            } else {
                SdhDGXText.text = "Off";
            }
            StableText.text = "Stable"; //Extension -> AH AHH AL og ALL signaler eksiterer ikke enda
            TagnameText.text = "Tagname: " + gameObject.name;
            ConDGXText.text = "Connected to database";
        }else{
            Debug.Log("Testing mode on, toggle testing mode on component object");
        }     
        for(int i = 0; i < RealDG1.Length; i += 1){     //juster skrift str
            if(Screen.width > 2400){
                //placholder
            }else if(Screen.width > 1200){
                textList[i].fontSize = 30;
                StableText.fontSize = 30;
                TagnameText.fontSize = 30;
                ConDGXText.fontSize = 30;
                StaticSetup1Text.fontSize = 30;
                StaticSetup2Text.fontSize = 30;
            }else if(Screen.width > 800){
                textList[i].fontSize = 20;
                StableText.fontSize = 20;
                TagnameText.fontSize = 20;
                ConDGXText.fontSize = 20;
                StaticSetup1Text.fontSize = 20;
                StaticSetup2Text.fontSize = 20;
            }else{
                //placholder
            }
        }
        if(Screen.width > 2400){
                //placholder
            }else if(Screen.width > 1200){
                UpdatePosition(StaDG1tmp, new Vector3(220, 125, 0)); 
                UpdatePosition(TagDGXtmp, new Vector3(0, 280, 0));
                UpdatePosition(ConDGXtmp, new Vector3(0, -280, 0));
                UpdatePosition(UDGXtmp, new Vector3(-147, 170, 0));
                UpdatePosition(PDGXtmp, new Vector3(-147, 125, 0));
                UpdatePosition(QDGXtmp, new Vector3(-147, 80, 0));
                UpdatePosition(FDGXtmp, new Vector3(-147, 35, 0));
                UpdatePosition(VelDGXtmp, new Vector3(220, 170, 0));
                UpdatePosition(IDGXtmpL1, new Vector3(-147, -10, 0));
                UpdatePosition(IDGXtmpL2, new Vector3(-147, -55, 0));
                UpdatePosition(IDGXtmpL3, new Vector3(-147, -100, 0));
                UpdatePosition(SdhDGXtmp, new Vector3(220, 80, 0)); 
                UpdatePosition(RunDGXtmp, new Vector3(0, -240, 0));
                UpdatePosition(RevDGXtmp, new Vector3(220, 35, 0));
                UpdatePosition(StaticSetup1tmp, new Vector3(-65, -8, 0)); 
                UpdatePosition(StaticSetup2tmp, new Vector3(-170, 51, 0));
            }else if(Screen.width > 800){
                UpdatePosition(StaDG1tmp, new Vector3(170, 70, 0)); 
                UpdatePosition(TagDGXtmp, new Vector3(0, 170, 0));
                UpdatePosition(ConDGXtmp, new Vector3(0, -160, 0));
                UpdatePosition(UDGXtmp, new Vector3(-74, 100, 0));
                UpdatePosition(PDGXtmp, new Vector3(-74, 70, 0));
                UpdatePosition(QDGXtmp, new Vector3(-74, 40, 0));
                UpdatePosition(FDGXtmp, new Vector3(-74, 10, 0));
                UpdatePosition(VelDGXtmp, new Vector3(170, 100, 0));
                UpdatePosition(IDGXtmpL1, new Vector3(-74, -20, 0));
                UpdatePosition(IDGXtmpL2, new Vector3(-74, -50, 0));
                UpdatePosition(IDGXtmpL3, new Vector3(-74, -80, 0));
                UpdatePosition(SdhDGXtmp, new Vector3(170, 40, 0)); 
                UpdatePosition(RunDGXtmp, new Vector3(0, -130, 0)); 
                UpdatePosition(RevDGXtmp, new Vector3(170, 10, 0));
                UpdatePosition(StaticSetup1tmp, new Vector3(23, -77, 0)); 
                UpdatePosition(StaticSetup2tmp, new Vector3(-180, 51, 0));
            }else{
                //placholder
            }                                          
        Debug.Log("Operation Complete");
    }
    private string GetMeasurementFromDatabase(string system){                                                   //func som henter all måling
        url = "http://192.168.38.100/get-tunglab-data-by-tagname.php?name=" + system + "&amount=1";             //lager ulr
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
    private void UpdatePosition(GameObject obj, Vector3 offset){
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = offset;
    }
}

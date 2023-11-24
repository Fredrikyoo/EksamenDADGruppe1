using System.Net;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections.Generic;

public class LiveDataValues : MonoBehaviour
{
    [Header("Diesel Generatior Main")]
    public GameObject DG1Button;
    public GameObject UDG1Button;
    public GameObject ADG1Button;
    public GameObject COSqDG1Button;
    public GameObject FDG1Button;
    public GameObject PDG1Button;

    [Header("Diesel Generatior L1")]
    public GameObject UDG1ButtonL1;
    public GameObject ADG1ButtonL1;
    public GameObject COSqDG1ButtonL1;
    public GameObject FDG1ButtonL1;
    public GameObject PDG1ButtonL1;

    [Header("Other Values")]
    public GameObject UDG1Stable;
    public GameObject UDG1Tagname;
    public GameObject UDG1ButtonL2;

    TextMeshProUGUI DG1Text;
    TextMeshProUGUI UDG1Text;
    TextMeshProUGUI ADG1Text; 
    TextMeshProUGUI COSqDG1Text;
    TextMeshProUGUI FDG1Text;
    TextMeshProUGUI PDG1Text; 
     
    TextMeshProUGUI UDG1TextL1;
    TextMeshProUGUI ADG1TextL1; 
    TextMeshProUGUI COSqDG1TextL1;
    TextMeshProUGUI FDG1TextL1;
    TextMeshProUGUI PDG1TextL1; 

    TextMeshProUGUI UDG1TextL2;
    TextMeshProUGUI StableText;
    TextMeshProUGUI TagnameText;
     
    private string url;
    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    
    void Start(){
        DG1Text = DG1Button.GetComponent<TextMeshProUGUI>();
        UDG1Text = UDG1Button.GetComponent<TextMeshProUGUI>();
        ADG1Text = ADG1Button.GetComponent<TextMeshProUGUI>();
        COSqDG1Text = COSqDG1Button.GetComponent<TextMeshProUGUI>();
        FDG1Text = FDG1Button.GetComponent<TextMeshProUGUI>();
        PDG1Text = PDG1Button.GetComponent<TextMeshProUGUI>();

        UDG1TextL1 = UDG1ButtonL1.GetComponent<TextMeshProUGUI>();
        ADG1TextL1 = ADG1ButtonL1.GetComponent<TextMeshProUGUI>();
        COSqDG1TextL1 = COSqDG1ButtonL1.GetComponent<TextMeshProUGUI>();
        FDG1TextL1 = FDG1ButtonL1.GetComponent<TextMeshProUGUI>();
        PDG1TextL1 = PDG1ButtonL1.GetComponent<TextMeshProUGUI>();
        UDG1TextL2 = UDG1ButtonL2.GetComponent<TextMeshProUGUI>();

        StableText = UDG1Stable.GetComponent<TextMeshProUGUI>();
        TagnameText = UDG1Tagname.GetComponent<TextMeshProUGUI>();

        if(Application.internetReachability==NetworkReachability.NotReachable){
            StableText.text = "Stable test";
            TagnameText.text = "DGX test";
        }
        // setter inn if DG1 / DG2
        textList.Add(UDG1Text); textList.Add(ADG1Text); textList.Add(COSqDG1Text); textList.Add(FDG1Text); textList.Add(PDG1Text); textList.Add(UDG1TextL1); 
        textList.Add(ADG1TextL1); textList.Add(COSqDG1TextL1); textList.Add(FDG1TextL1); textList.Add(PDG1TextL1); textList.Add(UDG1TextL2);
    }

    void Update(){
         if(Application.internetReachability==NetworkReachability.NotReachable){
            DG1Text.text = "Connected to database";
        } else if(Application.internetReachability==NetworkReachability.ReachableViaLocalAreaNetwork) {
            DG1Text.text = "Disconnected from database";
        }
    }
    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger enter");
        string[] RealDG1 = {"DG1-GEN-V","DG1-LOAD","DG1-LOAD-KVAR","DG1-GEN-FRQ","DG1-VELOC",
                    "DG1-I-L1","DG1-I-L2","DG1-I-L3","DG1-SHD","DG1-RUN","DG1-REV-PWR"};
        string[] RealDG2 = {"DG2-GEN-V","DG2-LOAD","DG2-LOAD-KVAR","DG2-GEN-FRQ","DG2-VELOC",
                    "DG2-VELOC","DG2-I-L1","DG2-I-L2","DG2-I-L3","DG2-SHD", "DG2-RUN","DG2-REV-PWR"};
        string[] TypeDGX = {"V","MVA","KVAR","HZ","","A","A","A","SHD?","","REV"};
        string DoOperation = GetValues(RealDG1, textList, TypeDGX);
    }

    private string GetValues(string[] RealDG1, List<TextMeshProUGUI> Texts, string[] type)
    {
        string valboi = "5";                                                        
        for(int i = 0; i < RealDG1.Length; i += 1)
        {
            string measurements = GetMeasurementFromDatabase(RealDG1[i]);          //henter målinger
            string value = GetMeasurementByIndex(measurements,1);                  // finner verdier
            textList[i].text = value + type[i];
        }
        if(textList[RealDG1.Length-2].text == "1"){
            textList[RealDG1.Length-2].text = "running";
            textList[RealDG1.Length-1].text = "";
        } else {
            textList[RealDG1.Length-2].text = "not running";
            textList[RealDG1.Length-1].text = "";
        }
        Debug.Log("Operation Complete");
        //Debug.Log("name = " + GameObject.name);
        return valboi; 
    }
    private string GetMeasurementFromDatabase(string system){                                                   //func som henter all måling
        url = "http://192.168.38.100/get-tunglab-data-by-tagname.php?name=" + system + "&amount=1";             //lager ulr
        string response;
        using (WebClient client = new WebClient()){
            response = client.DownloadString(url);                              //ved å bruke konstruert url
        }
        return response;
    }
    private string GetMeasurementByIndex(string measurements,int index){        //func som henter fra databsen
        string[] parts = measurements.Split(',');                               //splitter data opp i deler i parts
        return parts[index];                                                    //gir tilbaake valgte måling
    }
}

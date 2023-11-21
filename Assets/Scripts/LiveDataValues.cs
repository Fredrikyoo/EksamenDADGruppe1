using System.Net;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

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

    [Header("Diesel Generatior L2")]
    public GameObject UDG1ButtonL2;
    public GameObject ADG1ButtonL2;
    public GameObject COSqDG1ButtonL2;
    public GameObject FDG1ButtonL2;
    public GameObject PDG1ButtonL2;
    
    [Header("Diesel Generatior L3")]
    public GameObject UDG1ButtonL3;
    public GameObject ADG1ButtonL3;
    public GameObject COSqDG1ButtonL3;
    public GameObject FDG1ButtonL3;
    public GameObject PDG1ButtonL3;

    [Header("Other Values")]
    public GameObject UDG1Stable;
    public GameObject UDG1Tagname;

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
    TextMeshProUGUI ADG1TextL2; 
    TextMeshProUGUI COSqDG1TextL2;
    TextMeshProUGUI FDG1TextL2;
    TextMeshProUGUI PDG1TextL2; 
     
    TextMeshProUGUI UDG1TextL3;
    TextMeshProUGUI ADG1TextL3; 
    TextMeshProUGUI COSqDG1TextL3;
    TextMeshProUGUI FDG1TextL3;
    TextMeshProUGUI PDG1TextL3; 

    TextMeshProUGUI StableText;
    TextMeshProUGUI TagnameText;
     
    public string phpURL;
    private string url;

    //http://192.168.38.100/get-tunglab-data-by-tagname.php?name=DG1-LOAD&amount=1";
    
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
        ADG1TextL2 = ADG1ButtonL2.GetComponent<TextMeshProUGUI>();
        COSqDG1TextL2 = COSqDG1ButtonL2.GetComponent<TextMeshProUGUI>();
        FDG1TextL2 = FDG1ButtonL2.GetComponent<TextMeshProUGUI>();
        PDG1TextL2 = PDG1ButtonL2.GetComponent<TextMeshProUGUI>();

        UDG1TextL3 = UDG1ButtonL3.GetComponent<TextMeshProUGUI>();
        ADG1TextL3 = ADG1ButtonL3.GetComponent<TextMeshProUGUI>();
        COSqDG1TextL3 = COSqDG1ButtonL3.GetComponent<TextMeshProUGUI>();
        FDG1TextL3 = FDG1ButtonL3.GetComponent<TextMeshProUGUI>();
        PDG1TextL3 = PDG1ButtonL3.GetComponent<TextMeshProUGUI>();

        StableText = UDG1Stable.GetComponent<TextMeshProUGUI>();
        TagnameText = UDG1Tagname.GetComponent<TextMeshProUGUI>();

        if(Application.internetReachability==NetworkReachability.NotReachable){
            StableText.text = "Stable test";
            TagnameText.text = "DGX test";
        }

        string[] DG1 = {"DG1-GEN-V ", "DG1-CURR", "DG1-COS-PHI", "DG1-GEN-FRQ", "G1-AVA-POW",
                        "G1-U-L1/L2", "G1-I-L1", "G1-COSPHI-L1", "G1-FREQ-I-L1", "val5",
                        "G1-U-L1/L3", "G1-I-L2", "G1-COSPHI-L2", "G1-FREQ-I-L2", "val5",
                        "G1-U-L2/L3", "G1-I-L3", "G1-COSPHI-L3", "G1-FREQ-I-L3", "val5",
                        "DG1-CONN",""};
        string[] DG2 = {"DG2-GEN-V ", "DG2-CURR", "DG2-COS-PHI", "DG2-GEN-FRQ", "G2-AVA-POW ",
                        "G2-U-L1/L2", "G2-I-L1", "G2-COSPHI-L1", "G2-FREQ-I-L1", "val5",
                        "G2-U-L1/L3", "G2-I-L2", "G2-COSPHI-L2", "G2-FREQ-I-L2", "val5",
                        "G2-U-L2/L3", "G2-I-L3", "G2-COSPHI-L3", "G2-FREQ-I-L3", "val5",
                        "DG2-CONN",""};
    }

    void Update(){
         if(Application.internetReachability==NetworkReachability.NotReachable){
            DG1Text.text = "Connected to database";
            UDG1Text.text = "400V";
            ADG1Text.text = "14A";
            COSqDG1Text.text = "0.8";
            FDG1Text.text = "50HZ";
            PDG1Text.text = "7760W";
            
            UDG1TextL1.text = "230V";
            ADG1TextL1.text = "14A";
            COSqDG1TextL1.text = "0.8";
            FDG1TextL1.text = "50HZ";
            PDG1TextL1.text = "2586W";

            UDG1TextL2.text = "230V";
            ADG1TextL2.text = "14A";
            COSqDG1TextL2.text = "0.8";
            FDG1TextL2.text = "50HZ";
            PDG1TextL2.text = "2587W";

            UDG1TextL3.text = "230V";
            ADG1TextL3.text = "14A";
            COSqDG1TextL3.text = "0.8";
            FDG1TextL3.text = "50HZ";
            PDG1TextL3.text = "2587W";

        } else if(Application.internetReachability==NetworkReachability.ReachableViaLocalAreaNetwork) {
            DG1Text.text = "Disconnected from database";
            UDG1Text.text = "";
            ADG1Text.text = "";
            COSqDG1Text.text = "ERROR";
            FDG1Text.text = "";
            PDG1Text.text = "";

            UDG1TextL1.text = "";
            ADG1TextL1.text = "";
            COSqDG1TextL1.text = "ERROR";
            FDG1TextL1.text = "";
            PDG1TextL1.text = "";

            UDG1TextL2.text = "";
            ADG1TextL2.text = "";
            COSqDG1TextL2.text = "ERROR";
            FDG1TextL2.text = "";
            PDG1TextL2.text = "";

            UDG1TextL3.text = "";
            ADG1TextL3.text = "";
            COSqDG1TextL3.text = "ERROR";
            FDG1TextL3.text = "";
            PDG1TextL3.text = "";
        }
    }

    private string GetMeasurementByIndex(string measurements,int index){        //func som henter fra databsen
        string[] parts = measurements.Split(',');                               //splitter data opp i deler i parts
        return parts[index];                                                    //gir tilbaake valgte måling
    }
    private string GetMeasurementFromDatabase(GameObject Component){                                //func som henter all måling
        url = phpURL + "?name=" + Component.name + "&amount=1";                //lager ulr
        string response;
        using (WebClient client = new WebClient()){
            response = client.DownloadString(url);                              //ved å bruke konstruert url
        }
        return response;
    }
}

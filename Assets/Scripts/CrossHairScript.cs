using UnityEngine;

public class CrossHairScript : MonoBehaviour
{
    public GameObject GameManagement;
    public GameObject CrossHair;
    // Start is called before the first frame update
    void Update()
    {
         bool CrossHairActive = GameManagement.GetComponent<GameManager>().CrossHair;
         //sjekker crosshair er aktive i gamemanager
         if(CrossHairActive == true){
            CrossHair.SetActive(true);
         } else {
            CrossHair.SetActive(false);
         }
    }
}

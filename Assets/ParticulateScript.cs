using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParticulateScript : MonoBehaviour
{


   
    public TMP_Text TextNO2;
    public TMP_Text TextO3;
    public TMP_Text TextPM10;
    public TMP_Text TextPM25;
 


    void Start()
    {
        
        TextNO2.text =  PlayerPrefs.GetInt("NO2").ToString()+"�g/m�";
        TextO3.text =  PlayerPrefs.GetInt("O3").ToString()+"�g/m�";
        TextPM10.text = PlayerPrefs.GetInt("PM10").ToString()+"�g/m�";
        TextPM25.text = PlayerPrefs.GetInt("PM25").ToString()+"�g/m�";
     
    }
}

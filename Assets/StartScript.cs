using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StartScript : MonoBehaviour
{
    public TMP_Text TextAQI;
    public TMP_Text TextVille;
    public TMP_Text textReNo;
    public TMP_Text textReS;



    void Start()
    {
        TextAQI.text = PlayerPrefs.GetInt("AQI_101").ToString();
        TextVille.text = PlayerPrefs.GetString("Ville");
        textReNo.text =  PlayerPrefs.GetString("RecommandationNonSensible");
        textReS.text = PlayerPrefs.GetString("RecommandationSensible");


    }
}

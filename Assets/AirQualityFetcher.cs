using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class AirQualityFetcher : MonoBehaviour
{
    public Button fetchButtonLeuven; 
    public Button fetchButtonNamur; 
    public Button fetchButtonOostende;
    public Button fetchButtonCharleroi;
    public Button fetchButtonBrussel;

    private string token = "Your token";
    private string baseUrl = "https://api.aircheckr.com/territory/BE/LAU2/name/";

    void Start()
    {
        // Leuven
        if (fetchButtonLeuven != null)
        {
            fetchButtonLeuven.onClick.AddListener(() => FetchData("leuven"));
        }

        // Namur
        if (fetchButtonNamur != null)
        {
            fetchButtonNamur.onClick.AddListener(() => FetchData("namur"));
        }

        // Liège
        if (fetchButtonOostende != null)
        {
            fetchButtonOostende.onClick.AddListener(() => FetchData("Oostende"));
        }
        //Ostande
        if (fetchButtonBrussel != null)
        {
            fetchButtonBrussel.onClick.AddListener(() => FetchData("brussel"));
        }
        //Charleroi

        if (fetchButtonCharleroi != null)
        {
            fetchButtonCharleroi.onClick.AddListener(() => FetchData("Charleroi"));
        }

    }

    void FetchData(string cityName)
    {
        StartCoroutine(GetAirQualityData(cityName));
    }
    IEnumerator GetAirQualityData(string cityName)
    {
        string fullUrl = $"{baseUrl}{cityName}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(fullUrl))
        {
            webRequest.SetRequestHeader("x-access-token", token);
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                var root = JsonConvert.DeserializeObject<RootObject>(webRequest.downloadHandler.text);
                if (root != null && root.data.Length > 0)
                {
                    var firstItem = root.data[0];
                    PlayerPrefs.SetInt("AQI_101", firstItem.aqi_101);
                    PlayerPrefs.SetString("Ville", root.area_name);
                    PlayerPrefs.SetInt("NO2", firstItem.values.no2);
                    PlayerPrefs.SetInt("O3", firstItem.values.o3);
                    PlayerPrefs.SetInt("PM10", firstItem.values.pm10);
                    PlayerPrefs.SetInt("PM25", firstItem.values.pm25);
                    PlayerPrefs.SetString("RecommandationNonSensible", firstItem.recommend_non_sensitive.general);
                    PlayerPrefs.SetString("RecommandationSensible", firstItem.recommend_sensitive.general);
                    SceneLeuven();
                }
            }
            else
            {
                SceneManager.LoadScene("HorsConnection");
            }
        }
    }



    void SceneLeuven()
    {
        SceneManager.LoadScene("Start");
    }



    [Serializable]
    public class RootObject
    {
        public string area_name;
        public Data[] data;
    }

    [Serializable]
    public class Data
    {
        public DataTime dataTime;
        public Values values;
        public int aqi_101;
        public AQI aqi_11;
        public AQI aqi_4;
        public Recommendation recommend_non_sensitive;
        public Recommendation recommend_sensitive;
    }

    [Serializable]
    public class DataTime
    {
        public long start;
        public long end;
    }

    [Serializable]
    public class Values
    {
        public int no2;
        public int o3;
        public int pm10;
        public int pm25;
        public string recommend_non_sensitive;
        public string recommend_sensitive;
    }

    [Serializable]
    public class AQI
    {
        public int @class;
        public string name;
        public string color_hex;
        public int[] color_rgb;
    }

    [Serializable]
    public class Recommendation
    {
        public string general;
        public string sports;
        public string ventilation;
    }
}

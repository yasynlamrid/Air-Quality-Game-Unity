using UnityEngine;

public class ParallaxSky : MonoBehaviour
{
    public Texture excellentQualityTexture;
    public Texture goodQualityTexture;
    public Texture fairlyGoodQualityTexture;
    public Texture acceptableQualityTexture;
    public Texture mediumQualityTexture;
    public Texture poorQualityTexture;

    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        UpdateParallaxLayerBasedOnAQI();
    }

    void UpdateParallaxLayerBasedOnAQI()
    {
        int aqiValue = PlayerPrefs.GetInt("AQI_101", 101); 

        if (aqiValue > 90 && aqiValue <= 100)
        {
            _renderer.material.mainTexture = excellentQualityTexture;
        }
        else if (aqiValue > 80 && aqiValue <= 90)
        {
            _renderer.material.mainTexture = goodQualityTexture;
        }
        else if (aqiValue > 70 && aqiValue <= 80)
        {
            _renderer.material.mainTexture = fairlyGoodQualityTexture;
        }
        else if (aqiValue > 60 && aqiValue <= 70)
        {
            _renderer.material.mainTexture = acceptableQualityTexture;
        }
        else if (aqiValue > 50 && aqiValue <= 60)
        {
            _renderer.material.mainTexture = mediumQualityTexture;
        }
        else if (aqiValue >= 0 && aqiValue <= 50)
        {
            _renderer.material.mainTexture = poorQualityTexture;
        }
        else
        {
            Debug.LogWarning("Valeur AQI hors des plages définies ou inconnue, couche de parallaxe non modifiée.");
        }
    }
}

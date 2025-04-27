using UnityEngine;

public class ParallaxLayerSwitcher : MonoBehaviour
{
    public Texture leuvenLayerTexture; 
    public Texture namurLayerTexture;  
    public Texture brusselLayerTexture; 
    public Texture charleroiLayerTexture;
    public Texture OostendeLayerTexture;

    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        UpdateParallaxLayer();
    }

    void UpdateParallaxLayer()
    {
        string city = PlayerPrefs.GetString("Ville", "").ToLower();
        switch (city)
        {
            case "leuven":
                _renderer.material.mainTexture = leuvenLayerTexture;
                break;
            case "charleroi":
                _renderer.material.mainTexture = charleroiLayerTexture;
                break;
            case "namur":
                _renderer.material.mainTexture = namurLayerTexture;
                break;
            case "brussel":
                _renderer.material.mainTexture = brusselLayerTexture;
                break;
            case "oostende":
                _renderer.material.mainTexture = OostendeLayerTexture;
                break;
            default:
                Debug.LogWarning("Ville inconnue, couche de parallaxe non modifiée.");
                break;
        }
    }
}

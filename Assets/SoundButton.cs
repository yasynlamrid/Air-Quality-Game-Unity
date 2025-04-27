using UnityEngine;
using UnityEngine.EventSystems; // Nécessaire pour détecter les clics

public class SoundButton : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        audioSource.Play();
    }
}

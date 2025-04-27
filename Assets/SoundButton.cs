using UnityEngine;
using UnityEngine.EventSystems; // N�cessaire pour d�tecter les clics

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

using UnityEngine;
using System.Collections; 

public class BoxScript : MonoBehaviour
{
    public GameObject panelUI; 
    private Animator animator;
    private bool eventTriggered = false;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !eventTriggered)
        {
            eventTriggered = true;
            StartCoroutine(DisplayPanelAfterAnimation()); 
        }
    }
    public void ClosePanel()
    {
        panelUI.SetActive(false);
        Time.timeScale = 1f;
    }
    IEnumerator DisplayPanelAfterAnimation()
    {
        animator.SetBool("isOpen", true); // Déclenchez l'animation d'ouverture

    
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        panelUI.SetActive(true); 
        Time.timeScale = 0f; 
    }
}

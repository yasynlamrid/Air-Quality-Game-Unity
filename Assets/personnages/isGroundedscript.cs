using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGroundedscript : MonoBehaviour
{
    public AudioClip soundGround;   
    public AudioSource Audio;

    private void Start()
    {
        
        Audio = GetComponent<AudioSource>();


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<Playercontroller>().isGrounded = true;

        Audio.PlayOneShot(soundGround);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<Playercontroller>().isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

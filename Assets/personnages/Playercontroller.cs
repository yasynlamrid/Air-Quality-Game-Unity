using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class Playercontroller : MonoBehaviour
    //declarations des variables 



{
    public int Speed = 70, jump =300; 
    public bool isGrounded=false;
    private Animator Anim;
    public AudioClip soundJump, soundDead;
    private AudioSource Audio;
   

    void Start()

    {
        Anim=GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();

        
    }
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * Speed * Time.deltaTime);
      


        if (h > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Anim.SetBool("walk", true);
        }

        if (h < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Anim.SetBool("walk", true);
        }

        if (h == 0)
        {
            Anim.SetBool("walk", false);
        }

    }


    void FixedUpdate()
    {

        if (Input.GetButtonDown("Jump") && isGrounded==true)

        {
            Audio.PlayOneShot(soundJump);
            GetComponent<Rigidbody2D>().velocity = Vector2.up *jump;
            Anim.SetTrigger("jump");
            Anim.SetBool("walk",false);


        }
        
    }


    public void PlayerDead()
    {


        Anim.SetTrigger("dead");
        Audio.PlayOneShot(soundDead);



    }
}

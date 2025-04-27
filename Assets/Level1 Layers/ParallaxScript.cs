using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{


    float offset;
    public int speed;
    public GameObject Player;
 

    // Update is called once per frame
    void Update()
    {
        offset = Player.transform.position.x/speed;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset,0));
        
    }
}

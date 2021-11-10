using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float playerFalling = -25;
    float outOfBound = -100;
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= outOfBound)
        {
            Destroy(gameObject);
            Application.LoadLevel("Main");
            //Destroy(); //Destroy the first sign and show the next one
        }          
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
            Application.LoadLevel("Main");
            //Destroy(); //Destroy the first sign and show the next one
        }       
        if (gameObject.transform.position.y <= playerFalling)
        {
            //Make player make noise or something here
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public Color greencolor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    public Color whitecolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*

    //at least one of the colliding objects needs a rigid body
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;

        foreach( var contact in collision.contacts)//array of all contact points of collision
        {
            
        }
    }
    */
   
   
    private void OnTriggerEnter(Collider other)
    {
                 transform.GetComponent<Renderer>().material.color = greencolor;
       }


    private void OnTriggerExit(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }
    
}

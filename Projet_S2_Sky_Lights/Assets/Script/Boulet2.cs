using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulet2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //transform.Translate(Vector3.back *  170);
        if (transform.position.y < 80)
        {
            
            Destroy(this.gameObject);
            //Debug.LogError("detruie");
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "batteaux")
        {
            Destroy(this.gameObject);
        }
        
    }
}

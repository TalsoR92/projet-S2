using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Vector3.back *  170);
        if (transform.position.y < 80)
        {
            
            Destroy(this.gameObject);
            Debug.LogError("detruie");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

    


public class Personage : MonoBehaviourPunCallbacks
{

    public float moveSpeed = 10.0f;
    public float rotateSpeed = 180.0f;

    
    private void Update()
    {
        if (photonView.IsMine)
        {
            ProcessInput();
        }
    }
    

    public void ProcessInput()
    {
      // Déplacement personage
              if (Input.GetKey(KeyCode.UpArrow))
              {
                 transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
              }
              if (Input.GetKey(KeyCode.DownArrow))
              {
                  transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
              }
              
              // Rotation avec souris
              transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0) * Time.deltaTime * rotateSpeed);  
    }
    
    
    
}

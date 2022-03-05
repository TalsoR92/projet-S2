using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Personnage : MonoBehaviourPunCallbacks
{
    
    
    public float moveSpeed = 100.0f;
    public float rotateSpeed = 1800.0f;
    
    
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
                              
        // Rotation avec souris
        transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0) * Time.deltaTime * rotateSpeed); 
    }
}

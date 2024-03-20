using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringpedestal : MonoBehaviour
{
    private bool holding = false;
    private GameObject rcontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }





    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            // Match the position and rotation of the controller
            transform.position = rcontroller.GetComponent<Transform>().position;
            transform.rotation = rcontroller.GetComponent<Transform>().rotation;
        }
        
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("rcontroller"))
        {
            holding = true;
        }
        if (holding && other.CompareTag("DoorTrigger"))
        {
            // Assuming "DoorTrigger" is the tag of the collider on the door
            // Open the door
            Debug.Log("Opening door!");
            // Place code here to open the door
        }
    }
}

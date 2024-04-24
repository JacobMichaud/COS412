using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringpedestal : MonoBehaviour
{ 
    public GameObject pedestal;
    // Start is called before the first frame update
    void Start()
    {
        
    }





    // Update is called once per frame
    void Update()
    {
       
        
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("DoorTrigger"))
        {
            // Assuming "DoorTrigger" is the tag of the collider on the door
            // Open the door
            Debug.Log("Opening door!");
            transform.SetParent(pedestal.transform);
            transform.position=pedestal.transform.position;
            transform.rotation=pedestal.transform.rotation;
            // Place code here to open the door
        }
    }
}

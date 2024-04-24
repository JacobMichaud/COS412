using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suntile2 : Interactable
{
    public GameObject moon;
    public GameObject moonplane;
    public GameObject sunplane;
    public GameObject interactableOb;
    public GameObject interactableOb2;
    public LayerMask invisibleLayerMask;
    public GameObject sun;
    public GameObject moontext;
    public GameObject suntext;
   
    public override void Interact()
    {
        // Cast a ray from the moon to the plane
        Ray rayToPlane = new Ray(moon.transform.position, moon.transform.up);
        Ray rayToPlane2 = new Ray(sun.transform.position, -sun.transform.up);
        RaycastHit planeHit;
        RaycastHit planeHit2;
        
        // Check if the ray hits the plane
        if (Physics.Raycast(rayToPlane, out planeHit) && planeHit.collider.gameObject == moonplane)
        {
            // Cast a ray from the plane in the same direction
            Ray rayFromPlane = new Ray(planeHit.point, moon.transform.up);
            RaycastHit objectHit;
            

            // Check if the ray from the plane hits the interactable object
            if(Physics.Raycast(rayFromPlane, out objectHit) && objectHit.collider.gameObject == interactableOb)
            {
                moontext.GetComponent<MeshRenderer>().enabled = true;

                // Perform your interaction logic here
                Debug.Log("Interaction with the object!");
            }
            
            
        }
        if (Physics.Raycast(rayToPlane2, out planeHit2) && planeHit2.collider.gameObject == sunplane)
        {

            Ray rayFromPlane2 = new Ray(planeHit2.point, -sun.transform.up);
            RaycastHit objectHit2;


            if(Physics.Raycast(rayFromPlane2, out objectHit2) && objectHit2.collider.gameObject == interactableOb2)
            {
                suntext.GetComponent<MeshRenderer>().enabled = true;

                // Perform your interaction logic here
                Debug.Log("Interaction with the object!");
            }
            
        }
    }
}


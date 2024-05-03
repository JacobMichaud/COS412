using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasting : MonoBehaviour
{

    public GameObject sun;
    public GameObject moon;
    
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindWithTag("sun");
        moon = GameObject.FindWithTag("moon");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(sun.transform.position, -sun.transform.up, out hit))
        {
            // Check if the ray hits this object.
            if (hit.collider != null)
                {
            Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                 if (interactableObject != null)
                        {
                        
                          interactableObject.Interact(); // Calls the appropriate overridden method
                        }
                }
            Debug.DrawRay(sun.transform.position, -sun.transform.up * 50f, Color.yellow);
        }

        RaycastHit hit2;
        if (Physics.Raycast(moon.transform.position, moon.transform.up, out hit2))
        {
            // Check if the ray hits this object.
            if (hit2.collider != null)
                {
                     Interactable interactableObject = hit2.collider.GetComponent<Interactable>();
                    if (interactableObject != null)
                        {
                            interactableObject.Interact(); // Calls the appropriate overridden method
                        }
                }
            Debug.DrawRay(moon.transform.position, moon.transform.up * 50f, Color.blue);
        }

    }
}

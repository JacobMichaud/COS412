using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suntile1 : Interactable
{
   public GameObject door1;
   public GameObject door2;
    public GameObject pivot1; // Empty GameObject serving as pivot for door1
    public GameObject pivot2; // Empty GameObject serving as pivot for door2

    private Quaternion door1OpenRotation;
    
    private Quaternion door2OpenRotation;
    
   public float rotationSpeed = .3f; // Degrees per second

    private bool isOpening = false;
    
    public GameObject moon;
    
    
   void Start()
   {
 
    door1OpenRotation = Quaternion.Euler(0, 90, 0) * pivot1.transform.localRotation;
    door2OpenRotation = Quaternion.Euler(0, -90, 0) * pivot2.transform.localRotation;
   
    

   }
   public override void Interact()
    {
       if (!isOpening && moon.transform.position.y>0)
        {
           
            isOpening = true;
            
        }

        
    }

    void Update()
    {
        if (isOpening)
        {
            float step = rotationSpeed * Time.deltaTime;
            
            

            pivot1.transform.rotation = Quaternion.Slerp(pivot1.transform.rotation, door1OpenRotation, step);
            pivot2.transform.rotation = Quaternion.Slerp(pivot2.transform.rotation, door2OpenRotation, step);

            
                isOpening = false;
               
            
            
        }
    }
}
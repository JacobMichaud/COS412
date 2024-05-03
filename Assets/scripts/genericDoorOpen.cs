using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericDoorOpen : Interactable
{
    public GameObject door1;
    public GameObject door2;

    private Vector3 door1OriginalPosition;
    private Vector3 door2OriginalPosition;
    private Vector3 door1TargetPosition;
    private Vector3 door2TargetPosition;
    private bool opening;
    public bool down= false;
    public float duration = 2f; // Duration of the interpolation
    
    public GameObject sun;
    
    

    // Speed at which the doors will open and close
    public float doorSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // Store the original positions of the doors
        door1OriginalPosition = door1.transform.position;
        door2OriginalPosition = door2.transform.position;
        opening = false;
        // Calculate the target positions for the doors (you can adjust these values according to your scene)
        door1TargetPosition = door1OriginalPosition + Vector3.forward * 2f;
        door2TargetPosition = door2OriginalPosition + Vector3.back * 2f; 
        if(down == true){
            door1TargetPosition = door1OriginalPosition + Vector3.down * 10f;
        door2TargetPosition = door2OriginalPosition + Vector3.down * 10f; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (opening == false){
            CloseDoors();
        }
        else{
            StartCoroutine(waitforclose());
        }
        
    }
    public override void Interact()
    {
        if (sun.transform.position.y>0&&opening==false)
        {
        StartCoroutine(OpenDoors());
        }
    }


    IEnumerator waitforclose()
    {
       

        float elapsedTime = 0f;
    while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;



            yield return null;
        }
        opening = false;
    }

    IEnumerator OpenDoors()
    {
        opening = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // Move the doors towards their target positions
            door1.transform.position = Vector3.Lerp(door1.transform.position, door1TargetPosition, elapsedTime / duration);
            door2.transform.position = Vector3.Lerp(door2.transform.position, door2TargetPosition, elapsedTime / duration);
            yield return null;
        }

        
    }
    

    void CloseDoors()
    {
        // Move the doors back to their original positions
        door1.transform.position = Vector3.Lerp(door1.transform.position, door1OriginalPosition, Time.deltaTime * doorSpeed);
        door2.transform.position = Vector3.Lerp(door2.transform.position, door2OriginalPosition, Time.deltaTime * doorSpeed);
    }
}

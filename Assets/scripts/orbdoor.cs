using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbdoor : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    private Vector3 door1OriginalPosition;
    private Vector3 door2OriginalPosition;
    private Vector3 door1TargetPosition;
    private Vector3 door2TargetPosition;
    
    public float duration = 2f; // Duration of the interpolation
    public float doorSpeed = 2f; // Speed at which the doors will open and close
    public Material hitorb;
    public GameObject orb1;
    public GameObject orb2;
    public GameObject orb3;
    private bool doorsOpened = false;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        door1OriginalPosition = door1.transform.position;
        door2OriginalPosition = door2.transform.position;
        
        // Calculate the target positions for the doors (you can adjust these values according to your scene)
        door1TargetPosition = door1OriginalPosition + Vector3.left * 2f;
        door2TargetPosition = door2OriginalPosition + Vector3.right * 2f; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!doorsOpened && AllOrbsCompleted())
        {
            Debug.Log("Opening doors");
            OpenDoors();
            wall.SetActive(false);
        }
    }

    public bool AllOrbsCompleted()
    {
        return orb1.GetComponent<fireorb>().hit == true &&
               orb2.GetComponent<iceorb>().hit == true &&
               orb3.GetComponent<iceorb>().hit == true;
    }

    public void OpenDoors()
    {
        StartCoroutine(OpenDoorsCoroutine());
    }

    IEnumerator OpenDoorsCoroutine()
    {
        doorsOpened = true;

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            door1.transform.position = Vector3.Lerp(door1OriginalPosition, door1TargetPosition, elapsedTime / duration);
            door2.transform.position = Vector3.Lerp(door2OriginalPosition, door2TargetPosition, elapsedTime / duration);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class ring : MonoBehaviour
{
    private InputDevice rightController;
    public GameObject elementalring; // Reference to the ring object
    public bool holdingRing = false; // Flag to indicate if holding the ring
    float triggerValueRight;
    public ParticleSystem fireParticleSystem;
    public GameObject key;
    // Update is called once per frame

    void Start()
    {

    }
    void Update()
    {
        List<InputDevice> Rdevices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, Rdevices);

        if(Rdevices.Count > 0)
        {
            rightController = Rdevices[0];
           
        }
        

        if(holdingRing == true)
        {
            elementalring.transform.position=transform.position;
            elementalring.transform.rotation=transform.rotation;
            //fireParticleSystem.transform.position=transform.position;
            //fireParticleSystem.transform.rotation=transform.rotation;
            if (rightController.TryGetFeatureValue(CommonUsages.trigger, out triggerValueRight) && triggerValueRight > 0.1f && fireParticleSystem!=null)
        {
           fireParticleSystem.Play();
        }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring"))
        {
            Debug.Log("interacted with ring");
            // If the collided object is the ring, set it as the object being held
            elementalring.transform.SetParent(this.transform);
            holdingRing = true;
        }
        if (other.CompareTag("key"))
        {
            key.transform.SetParent(this.transform);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class ring2 : MonoBehaviour
{
    private InputDevice leftController;
    public GameObject elementalring2; // Reference to the ring object
    public bool holdingRing2 = false; // Flag to indicate if holding the ring
    float triggerValueLeft;
    public ParticleSystem iceParticleSystem;
    // Update is called once per frame

    void Start()
    {

    }
    void Update()
    {
        List<InputDevice> Ldevices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, Ldevices);

        if(Ldevices.Count > 0)
        {
            leftController = Ldevices[0];
           
        }
        

        if(holdingRing2 == true)
        {
            elementalring2.transform.position=transform.position;
            elementalring2.transform.rotation=transform.rotation;
            //iceParticleSystem.transform.position=transform.position;
            //iceParticleSystem.transform.rotation=transform.rotation;
            if (leftController.TryGetFeatureValue(CommonUsages.trigger, out triggerValueLeft) && triggerValueLeft > 0.1f && iceParticleSystem!=null)
        {
           iceParticleSystem.Play();
        }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ring2"))
        {
            Debug.Log("interacted with ring");
            // If the collided object is the ring, set it as the object being held
            elementalring2.transform.SetParent(this.transform);
            holdingRing2 = true;
        }
    }

    
}

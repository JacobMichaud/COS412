using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SunChange : MonoBehaviour
{
    private InputDevice targetDevice;
    public bool imReady = false;
    public GameObject sun;
    public float x;
   
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindWithTag("sun");
      x = 50.0f;
    
            
       

    }


    // Update is called once per frame
    void Update()
    {
        
     
        List<InputDevice> devices = new List<InputDevice>();
            //InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
            InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        //  InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics,  devices);
            InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics,  devices);
        

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            Debug.Log(targetDevice);
        }
        
        


		if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            x += 1;
            sun.transform.localRotation = Quaternion.Euler(x,0.0f,0.0f);
            Debug.Log("pressing primary button");
        }
            

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue> 0.1f)
        {
            Debug.Log("trigger pressed " + triggerValue);
            x += triggerValue;
            sun.transform.localRotation = Quaternion.Euler(x,0.0f,0.0f);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("primary Touchpad " + primary2DAxisValue);

        
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
             x += 1;
            sun.transform.localRotation = Quaternion.Euler(x,0.0f,0.0f);
        }
    }

}

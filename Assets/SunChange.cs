using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class SunChange : MonoBehaviour
{
    private InputDevice rightController;
    private InputDevice leftController;
    public bool imReady = false;
    public GameObject sun;
    public GameObject moon;
    public float x;
    public float y;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public GameObject rotationalpoint;
    bool primaryButtonValueRight, primaryButtonValueLeft;
    float triggerValueRight, triggerValueLeft, gripValueRight, gripValueLeft;
    Vector2 primary2DAxisValueRight, primary2DAxisValueLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindWithTag("sun");
        moon = GameObject.FindWithTag("moon");
        rotationalpoint = GameObject.FindWithTag("rotationalpoint");
            
       

    }


    // Update is called once per frame
    void Update()
    {
        
     
        List<InputDevice> Rdevices = new List<InputDevice>();
        List<InputDevice> Ldevices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, Ldevices);
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, Rdevices);
        

        if(Rdevices.Count > 0)
        {
            rightController = Rdevices[0];
           
        }
        if(Ldevices.Count > 0)
        {
            leftController = Ldevices[0];
            
        }
        
        

        if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonValueRight) && primaryButtonValueRight)
        {
            sunPlace();
           // Debug.Log("pressing primary button");
        }
        if (rightController.TryGetFeatureValue(CommonUsages.grip, out gripValueRight) && gripValueRight > 0.1f){
            y += gripValueRight;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x, 0.0f, y);
        }

        if (rightController.TryGetFeatureValue(CommonUsages.trigger, out triggerValueRight) && triggerValueRight > 0.1f)
        {
           // Debug.Log("trigger pressed " + triggerValueRight);
            x += triggerValueRight;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x, 0.0f, y);
        }

        if (rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValueRight) && primary2DAxisValueRight != Vector2.zero)
           // Debug.Log("primary Touchpad " + primary2DAxisValueRight);

        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonValueLeft) && primaryButtonValueLeft)
        {
               
                        
                
        }
          //  Debug.Log("pressing primary button");
        
        if (leftController.TryGetFeatureValue(CommonUsages.grip, out gripValueLeft) && gripValueLeft > 0.1f){
            y -= gripValueLeft;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x, 0.0f, y);
        }
        if (leftController.TryGetFeatureValue(CommonUsages.trigger, out triggerValueLeft) && triggerValueLeft > 0.1f)
        {
          //  Debug.Log("trigger pressed " + triggerValueLeft);
            x -= triggerValueLeft;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x, 0.0f, y);
        }

}
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
             x += 1;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x,0.0f,y);
        }
        if (Input.GetMouseButton(1))
        {
             x -= 1;
            rotationalpoint.transform.localRotation = Quaternion.Euler(x,0.0f,y);
        }
    }


    private void sunPlace()
    {
        RaycastHit hit;
        raycastOrigin = GameObject.FindWithTag("RightController").GetComponent<Transform>();
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            rotationalpoint.GetComponent<Transform>().position = hit.point;
          //  Debug.Log(hit.transform.name);
        }
    }


}

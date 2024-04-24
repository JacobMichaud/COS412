using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
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
    private bool done= true;
    private Camera cam;
    private void Awake() => cam = Camera.main;
    private void Update()
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


        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonValueLeft) && primaryButtonValueLeft)
        {
                
                            StartCoroutine(ButtonPressCoroutine());

                        
                    }
                        
                
        }
        
            

            
                IEnumerator ButtonPressCoroutine()
                        {
                           

            RaycastHit hit2;
            raycastOrigin = GameObject.FindWithTag("LeftController").GetComponent<Transform>();
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit2, Mathf.Infinity))
            {

                KeypadButton keypadButton = hit2.collider.GetComponent<KeypadButton>();
                button1 keypadButton1 = hit2.collider.GetComponent<button1>();
                    if(done == true){
                        done = false;
                    if (keypadButton != null)
                    {
                     keypadButton.PressButton();
                    }

                    if (keypadButton1 != null)
                    {
                    keypadButton1.PressButton();
                    }
                    yield return new WaitForSeconds(1f);
                    done = true;
                    }
                }
            }
                        }
    }

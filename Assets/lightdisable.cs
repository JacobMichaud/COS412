using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightdisable : MonoBehaviour
{
    private Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0)
        {
            // If so, disable the light
            lightComponent.enabled = false;
        }
        else
        {
            // Otherwise, enable the light
            lightComponent.enabled = true;
        }
    }
}

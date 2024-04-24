using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceorb : MonoBehaviour
{
    public Material complete;
        public bool hit = false;

    void OnParticleCollision(GameObject other)
   {
    
    if(other.transform.CompareTag("ice")){
        GetComponent<Renderer>().material = complete;
                hit = true;

    }
    
    
   }
}

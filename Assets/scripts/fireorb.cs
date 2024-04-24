using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireorb : MonoBehaviour
{
    public Material complete;
    public bool hit = false;
    void OnParticleCollision(GameObject other)
   {
    
    if(other.transform.CompareTag("fire")){
        GetComponent<Renderer>().material = complete;
        hit = true;
    }
    
    
   }
}

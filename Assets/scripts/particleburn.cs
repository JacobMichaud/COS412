using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleburn : MonoBehaviour
{
    

   void OnParticleCollision(GameObject other)
   {
    
    if(other.transform.CompareTag("fire")){
        this.gameObject.SetActive(false);
    }
    
    
   }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlefreeze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
   {
    if(other.transform.CompareTag("ice")){
        this.gameObject.SetActive(false);
    }
   }
}

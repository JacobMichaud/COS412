using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suntile3 : Interactable
{
    public Terrain terrain;
    public Texture2D newTexture;
    public GameObject sun;
    public GameObject icewall;
    public GameObject door;
    public GameObject audioo;
    public GameObject a1;
    public GameObject a2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if( sun.transform.position.y>0&&icewall.activeInHierarchy==false)
        {
          //  terrain.terrainData.terrainLayers[0].diffuseTexture = newTexture;
          //  light.SetActive(true);
            audioo.SetActive(false);
            a1.SetActive(false);
            a2.SetActive(false);
            door.SetActive(false);
        }
    }
}

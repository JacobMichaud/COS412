using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suntile4 : Interactable
{
    public Terrain terrain;
    public Texture2D newTexture;
    public Texture2D oldTexture;
    public GameObject moon;
    public GameObject firewall;
    public GameObject lighto;
    public GameObject audioo;
    public GameObject a1;
    public GameObject a2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnApplicationQuit()
    {
        terrain.terrainData.terrainLayers[0].diffuseTexture = oldTexture;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if( moon.transform.position.y>0&&firewall.activeInHierarchy==false)
        {
            terrain.terrainData.terrainLayers[0].diffuseTexture = newTexture;
            lighto.SetActive(true);
          //  audio.SetActive(false);
         //   a1.SetActive(false);
         //   a2.SetActive(false);

        }
    }
}

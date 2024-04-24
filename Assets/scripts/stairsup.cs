using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairsup : MonoBehaviour
{
    public GameObject stair1;
    public GameObject stair2;
    public GameObject stair3;
    public float duration = 1f; // Duration of the interpolation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movestairs()
    {
        StartCoroutine(RiseStaircase());
        
    }
    IEnumerator RiseStaircase()
    {
       

        float elapsedTime = 0f;

        // Initial positions
        Vector3 initialPosStair1 = stair1.transform.position;
        Vector3 initialPosStair2 = stair2.transform.position;
        Vector3 initialPosStair3 = stair3.transform.position;

        // Target positions 
        Vector3 targetPosStair1 = initialPosStair1 + Vector3.up * .5f;
        Vector3 targetPosStair2 = initialPosStair2 + Vector3.up * 1f;
        Vector3 targetPosStair3 = initialPosStair3 + Vector3.up * 1.5f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolate the positions using Lerp
            stair1.transform.position = Vector3.Lerp(initialPosStair1, targetPosStair1, elapsedTime / duration);
            stair2.transform.position = Vector3.Lerp(initialPosStair2, targetPosStair2, elapsedTime / duration);
            stair3.transform.position = Vector3.Lerp(initialPosStair3, targetPosStair3, elapsedTime / duration);

            yield return null;
        }

        // Ensure the objects reach the exact target positions
        stair1.transform.position = targetPosStair1;
        stair2.transform.position = targetPosStair2;
        stair3.transform.position = targetPosStair3;

    }
}

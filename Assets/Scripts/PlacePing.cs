using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePing : MonoBehaviour
{
    public Camera cam;
    public float range = 50f;
    
    public GameObject ping;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Vector3 pos = hit.point;
                pos.y = 30;
                ping.transform.position = pos;
            }
        }
    }
}

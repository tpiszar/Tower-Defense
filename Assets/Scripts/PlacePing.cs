using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePing : MonoBehaviour
{
    public Camera cam;
    public float range = 50f;

    public LayerMask mask;
    
    public GameObject ping;

    public AudioSource place;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, mask))
            {
                place.Play();
                Vector3 pos = hit.point;
                pos.y = 30;
                ping.transform.position = pos;
            }
        }
    }
}

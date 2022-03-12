using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Transform center;

    Transform ping;

    Vector3 lastPing = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        ping = GameObject.FindGameObjectWithTag("Player").GetComponent<PlacePing>().ping.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (ping.position != lastPing)
        {
            lastPing = ping.position;
            Vector3 lookPos = lastPing - transform.position;
            lookPos.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(lookPos.normalized, Vector3.up);
            center.transform.rotation = rotation;
            center.Rotate(new Vector3(0, -90, 0));
        }
    }
}

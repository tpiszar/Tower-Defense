using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public Camera cam;
    public float range = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                PanelBtn button = hit.transform.GetComponent<PanelBtn>();
                if (button != null)
                {
                    button.Click();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Enemy e;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 2 && other.gameObject.name == "DetectorBox" &&e.cannon == null)
        {
            e.agent.isStopped = true;
            e.shooting = true;
            e.rotating = true;
            e.cannon = other.transform.parent.GetComponent<Panel>().cannon.transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Material mat;
    public Rigidbody rig;
    public float force;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Vector3 dir = other.transform.position - transform.position;

            rig.AddForce(dir.normalized * force, ForceMode.Impulse);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Material oMat = other.GetComponent<Material>();
            if (oMat && mat.quantity >= oMat.quantity)
            {
                mat.quantity += oMat.quantity;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            rig.velocity = Vector3.zero;
        }
    }
}

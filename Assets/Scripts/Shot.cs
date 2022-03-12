using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.layer == 6)
        {
            other.GetComponentInParent<Cannon>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}

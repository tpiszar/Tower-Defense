using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public int dmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.layer == 7)
        {
            other.GetComponentInParent<Enemy>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}

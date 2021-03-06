using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public float rotationSpeed;
    public int quantity = 0;
    public float deathTime;
    public float time = 0;

    void Update()
    {
        if (time >= deathTime)
        {
            Destroy(this.gameObject);
        }
        time += Time.deltaTime;
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Manager.materials += quantity;
            quantity = 0;
            Destroy(this.gameObject);
        }
    }
}

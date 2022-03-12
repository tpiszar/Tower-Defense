using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public float rotationSpeed;
    public int quantity = 0;
    public float deathTime;

    void Start()
    {
        Destroy(this.gameObject, deathTime);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Manager.materials += quantity;
            Destroy(this.gameObject);
        }
    }
}

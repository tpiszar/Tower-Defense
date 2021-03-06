using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public Panel panel;
    public Transform center;
    public Transform barrel;

    public GameObject cannonBall;

    public float speed;
    public float fireRate;
    float nextFire = 0;

    public int health;
    public Slider healthBar;

    public GameObject materials;
    public int matDrop;

    public AudioSource fireSnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextFire += Time.deltaTime;
        if (nextFire >= fireRate && !Manager.calm)
        {
            fireSnd.Play();
            GameObject newCannonBall = Instantiate(cannonBall, barrel.position, Quaternion.identity);
            Vector3 dir = barrel.position - center.position;
            dir = dir.normalized;
            newCannonBall.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
            nextFire = 0;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.value = health;
        if (health <= 0)
        {
            panel.Reset();
            GameObject mats = Instantiate(materials, transform.position, Quaternion.identity);
            mats.GetComponent<Material>().quantity = matDrop;
            Destroy(this.gameObject);
        }
    }
}

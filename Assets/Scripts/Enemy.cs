using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    public GameObject shot;

    public Transform cannon;
    public Transform left;
    public Transform backLeft;
    public Transform right;
    public Transform backRight;
    bool arm = true;
    public bool shooting = false;
    public bool rotating = true;
    public float rotationSpeed;
    public float shotSpeed;
    public float fireRate;
    float nextFire = 0;

    public int fireMode;

    public int health;
    public GameObject materials;
    public int matDrop;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target.position);
        nextFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            if (cannon != null)
            {
                if (rotating)
                {
                    Vector3 lookPos = cannon.transform.position - transform.position;
                    lookPos.y = 0;

                    Quaternion rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(lookPos.normalized, Vector3.up), rotationSpeed * Time.deltaTime);

                    if (Mathf.Abs(transform.rotation.eulerAngles.magnitude - rotation.eulerAngles.magnitude) < .01f)
                    {
                        rotating = false;
                    }
                    transform.rotation = rotation;
                }
                else
                {
                    

                    nextFire += Time.deltaTime;
                    if (nextFire >= fireRate)
                    {
                        for (int i = 0; i < fireMode; i++)
                        {
                            Vector3 shootFrom;
                            Vector3 back;
                            if (arm)
                            {
                                shootFrom = right.position;
                                back = backRight.position;
                                arm = false;
                            }
                            else
                            {
                                shootFrom = left.position;
                                back = backLeft.position;
                                arm = true;
                            }


                            Vector3 dir = shootFrom - back;
                            dir = dir.normalized;
                            Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

                            GameObject newShot = Instantiate(shot, shootFrom, rotation);
                            newShot.GetComponent<Rigidbody>().AddForce(dir * shotSpeed, ForceMode.Impulse);
                        }

                        nextFire = 0;
                    }
                }
            }
            else
            {
                shooting = false;
                agent.isStopped = false;
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            GameObject mats = Instantiate(materials, transform.position, Quaternion.identity);
            mats.GetComponent<Material>().quantity = matDrop;
            print(mats.GetComponent<Material>().quantity);
            Destroy(this.gameObject);
        }
    }
}

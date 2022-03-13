using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int materials = 150;
    public static bool gameOver = false;
    public static int wave = 1;

    public Transform target;

    public GameObject bigEnemy;
    public GameObject smallEnemy;

    public Transform spawnPoint;
    int subCount = 0;
    subWave currentSub;
    public float waveDelay;
    float nextWave = 0;
    float nextSub = 0;

    [System.Serializable]
    public class subWave
    {
        [SerializeField]
        public int smalls;
        [SerializeField]
        public int bigs;
    }

    [System.Serializable]
    public class Wave
    {
        [SerializeField]
        public subWave[] subs;
        public float[] subDelays;
    }

    [SerializeField]
    public Wave[] waves;


    // Start is called before the first frame update
    void Start()
    {
        smallEnemy.GetComponent<Enemy>().target = target;
        bigEnemy.GetComponent<Enemy>().target = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextWave > waveDelay)
        {
            if (subCount == waves[wave - 1].subs.Length)
            {
                if (transform.childCount == 0)
                {
                    nextWave = 0;
                    subCount = 0;
                    if (wave < waves.Length)
                    {
                        wave++;
                    }
                    currentSub = waves[wave - 1].subs[0];
                }
            }
            else if (nextSub > waves[wave - 1].subDelays[subCount])
            {
                currentSub = waves[wave - 1].subs[subCount];

                for (int i = 0; i < currentSub.smalls; i++)
                {
                    GameObject newEn = Instantiate(smallEnemy, spawnPoint.position, Quaternion.identity);
                    newEn.transform.parent = this.transform;
                }
                for (int i = 0; i < currentSub.bigs; i++)
                {
                    GameObject newEn = Instantiate(bigEnemy, spawnPoint.position, Quaternion.identity);
                    newEn.transform.parent = this.transform;
                }

                subCount++;
                nextSub = 0;

                //if (subCount != waves[wave - 1].subs.Length)
                //{
                //    currentSub = waves[wave - 1].subs[subCount];


                //    nextSub = 0;
                //}
                //else
                //{
                //    if (transform.childCount == 0)
                //    {
                //        nextWave = 0;
                //        subCount = 0;
                //        if (wave < waves.Length)
                //        {
                //            wave++;
                //        }
                //        currentSub = waves[wave - 1].subs[0];
                //    }
                //}
            }
            else
            {
                nextSub += Time.deltaTime;
            }
        }
        else
        {
            nextWave += Time.deltaTime;
        }
    }
}

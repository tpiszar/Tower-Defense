using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int materials = 150;
    public static bool gameOver = false;
    public static bool win = false;
    public static int wave = 1;
    public static bool calm = true;

    public Transform target;

    public GameObject bigEnemy;
    public GameObject smallEnemy;

    public Transform spawnPoint;
    int subCount = 0;
    subWave currentSub;
    public float waveDelay;
    float nextWave = 0;
    float nextSub = 0;

    bool waveStart = true;

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
        public int smallHp;
        public int bigHp;
    }

    [SerializeField]
    public Wave[] waves;

    private void Awake()
    {
        materials = 150;
        gameOver = false;
        win = false;
        wave = 1;
    }

    void Start()
    {
        smallEnemy.GetComponent<Enemy>().target = target;
        bigEnemy.GetComponent<Enemy>().target = target;
    }

    void Update()
    {
        if (wave <= 10)
        {
            if (nextWave > waveDelay)
            {
                if (waveStart)
                {
                    Music.playAttk = true;
                    waveStart = false;
                }
                if (subCount == waves[wave - 1].subs.Length)
                {
                    if (transform.childCount == 0)
                    {
                        nextWave = 0;
                        subCount = 0;
                        wave++;
                        if (wave <= 10)
                        {
                            currentSub = waves[wave - 1].subs[0];
                        }
                        Music.playCalm = true;
                        calm = true;
                    }
                }
                else if (nextSub > waves[wave - 1].subDelays[subCount])
                {
                    currentSub = waves[wave - 1].subs[subCount];

                    for (int i = 0; i < currentSub.smalls; i++)
                    {
                        GameObject newEn = Instantiate(smallEnemy, spawnPoint.position, Quaternion.identity);
                        newEn.GetComponent<Enemy>().health = waves[wave - 1].smallHp;
                        newEn.transform.parent = this.transform;
                    }
                    for (int i = 0; i < currentSub.bigs; i++)
                    {
                        GameObject newEn = Instantiate(bigEnemy, spawnPoint.position, Quaternion.identity);
                        newEn.GetComponent<Enemy>().health = waves[wave - 1].bigHp;
                        newEn.transform.parent = this.transform;
                    }

                    subCount++;
                    nextSub = 0;
                }
                else if (subCount == 0 && nextSub <= waves[wave - 1].subDelays[0] && calm)
                {
                    waveStart = true;
                    calm = false;
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
        else
        {
            win = true;
            Music.playWin = true;
        }
    }
}

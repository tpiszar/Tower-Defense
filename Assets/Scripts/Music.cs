using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music music;

    public AudioSource calm;
    public float calmVol;
    public AudioSource attack;
    public float attkVol;
    public AudioSource victory;
    public float vicVol;
    public AudioSource loss;
    public float lossVol;

    public float fade;

    bool start = true;

    public static bool playAttk = false;
    public static bool playCalm = false;
    public static bool playWin = false;
    public static bool playLoss = false;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (music == null)
        {
            music = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (playAttk)
        {
            if (start)
            {
                attack.Play();
                start = false;
            }
            if (calm.volume > 0)
            {
                calm.volume -= fade * Time.deltaTime;
            }
            if (attack.volume < attkVol)
            {
                attack.volume += fade * Time.deltaTime;
            }
            else if (calm.volume <= 0)
            {
                playAttk = false;
                start = true;
                calm.Stop();
            }
        }
        else if (playCalm)
        {
            if (start)
            {
                calm.Play();
                start = false;
            }
            if (attack.volume > 0)
            {
                attack.volume -= fade * Time.deltaTime;
            }
            if (calm.volume < calmVol)
            {
                calm.volume += fade * Time.deltaTime;
            }
            else if (attack.volume <= 0)
            {
                playCalm = false;
                start = true;
                attack.Stop();
            }
        }
        else if (playWin)
        {
            if (start)
            {
                victory.Play();
                start = false;
            }
            if (calm.volume > 0)
            {
                calm.volume -= fade * Time.deltaTime;
            }
            if (victory.volume < vicVol)
            {
                victory.volume += fade * Time.deltaTime;
            }
            else if (calm.volume <= 0)
            {
                playWin = false;
                start = true;
                calm.Stop();
            }
        }
        else if (playLoss)
        {
            if (start)
            {
                loss.Play();
                start = false;
            }
            if (attack.volume > 0)
            {
                attack.volume -= fade;
            }
            if (loss.volume < lossVol)
            {
                loss.volume += fade;
            }
            else if (calm.volume <= 0)
            {
                playLoss = false;
                start = true;
                attack.Stop();
            }
        }
    }
}

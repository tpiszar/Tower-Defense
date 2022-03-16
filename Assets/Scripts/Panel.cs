using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public int mode = 0;
    public GameObject square;
    public GameObject circle;
    public GameObject rotate;
    public GameObject canvas;
    public Slider healthBar;

    public Transform spawnLoc;
    public GameObject cannon;
    public GameObject detectorBox;

    public GameObject single;
    public GameObject omni;

    public AudioSource create;
    public AudioSource destroy;
    public AudioSource click;
    public AudioSource error;

    public void spawnSingle()
    {
        if (Manager.materials >= 100)
        {
            click.Play();
            create.Play();
            Manager.materials -= 100;
            cannon = Instantiate(single, spawnLoc.position, Quaternion.identity);
            Cannon can = cannon.GetComponent<Cannon>();
            can.panel = this;
            can.healthBar = healthBar;
            healthBar.value = can.health;
            square.SetActive(false);
            rotate.SetActive(true);
            canvas.SetActive(true);
            detectorBox.SetActive(true);
            mode = 2;
        }
        else
        {
            if (!error.isPlaying)
            {
                error.Play();
            }
        }
    }

    public void spawnOmni()
    {
        if (Manager.materials >= 200)
        {
            click.Play();
            create.Play();
            Manager.materials -= 200;
            cannon = Instantiate(omni, spawnLoc.position, Quaternion.identity);
            Cannon can = cannon.GetComponent<Cannon>();
            can.panel = this;
            can.healthBar = healthBar;
            healthBar.value = can.health;
            circle.SetActive(false);
            canvas.SetActive(true);
            detectorBox.SetActive(true);
            mode = 3;
        }
        else
        {
            if (!error.isPlaying)
            {
                error.Play();
            }
        }
    }

    public void rBtn()
    {
        if (mode == 0)
        {
            click.Play();
            square.SetActive(false);
            circle.SetActive(true);
            mode = 1;
        }
        else if (mode == 1)
        {
            click.Play();
            square.SetActive(true);
            circle.SetActive(false);
            mode = 0;
        }
        else if (mode == 2)
        {
            click.Play();
            cannon.transform.Rotate(0, -45, 0);
        }
    }

    public void lBtn()
    {
        if (mode == 0)
        {
            click.Play();
            square.SetActive(false);
            circle.SetActive(true);
            mode = 1;
        }
        else if (mode == 1)
        {
            click.Play();
            square.SetActive(true);
            circle.SetActive(false);
            mode = 0;
        }
        else if (mode == 2)
        {
            click.Play();
            cannon.transform.Rotate(0, 45, 0);
        }
    }

    public void Reset()
    {
        destroy.Play();
        square.SetActive(true);
        circle.SetActive(false);
        canvas.SetActive(false);
        rotate.SetActive(false);
        detectorBox.SetActive(false);
        mode = 0;
    }
}

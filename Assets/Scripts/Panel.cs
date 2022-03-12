using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public int mode = 0;
    public GameObject square;
    public GameObject circle;
    public GameObject rotate;

    public Transform spawnLoc;
    public GameObject cannon;
    public GameObject detectorBox;

    public GameObject single;
    public GameObject omni;

    public void spawnSingle()
    {
        if (Manager.materials >= 100)
        {
            Manager.materials -= 100;
            cannon = Instantiate(single, spawnLoc.position, Quaternion.identity);
            cannon.GetComponent<Cannon>().panel = this;
            square.SetActive(false);
            rotate.SetActive(true);
            detectorBox.SetActive(true);
            mode = 2;
        }
    }

    public void spawnOmni()
    {
        if (Manager.materials >= 200)
        {
            Manager.materials -= 200;
            cannon = Instantiate(omni, spawnLoc.position, Quaternion.identity);
            cannon.GetComponent<Cannon>().panel = this;
            circle.SetActive(false);
            detectorBox.SetActive(true);
            mode = 3;
        }
    }

    public void rBtn()
    {
        if (mode == 0)
        {
            square.SetActive(false);
            circle.SetActive(true);
            mode = 1;
        }
        else if (mode == 1)
        {
            square.SetActive(true);
            circle.SetActive(false);
            mode = 0;
        }
        else if (mode == 2)
        {
            cannon.transform.Rotate(0, -45, 0);
        }
    }

    public void lBtn()
    {
        if (mode == 0)
        {
            square.SetActive(false);
            circle.SetActive(true);
            mode = 1;
        }
        else if (mode == 1)
        {
            square.SetActive(true);
            circle.SetActive(false);
            mode = 0;
        }
        else if (mode == 2)
        {
            cannon.transform.Rotate(0, 45, 0);
        }
    }

    public void Reset()
    {
        square.SetActive(true);
        circle.SetActive(false);
        rotate.SetActive(false);
        detectorBox.SetActive(false);
        mode = 0;
    }
}

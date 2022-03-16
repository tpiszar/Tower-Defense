using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cycle : MonoBehaviour
{
    Image image;
    [SerializeField]
    Sprite[] images;
    int index = 0;
    public float cycleTime;
    float nextCycle = 0;

    void Start()
    {
        image = this.GetComponent<Image>();
    }

    void Update()
    {
        if (nextCycle >= cycleTime)
        {
            if (index + 1 < images.Length)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            image.sprite = images[index];
            nextCycle = 0;
        }
        else
        {
            nextCycle += Time.deltaTime;
        }
    }
}

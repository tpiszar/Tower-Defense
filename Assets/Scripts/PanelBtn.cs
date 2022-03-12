using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBtn : MonoBehaviour
{
    public Panel panel;
    public int type;

    public void Click()
    {
        if (type == 0)
        {
            panel.rBtn();
        }
        else if (type == 1)
        {
            panel.lBtn();
        }
        else if (type == 2)
        {
            panel.spawnSingle();
        }
        else if (type == 3)
        {
            panel.spawnOmni();
        }
    }
}

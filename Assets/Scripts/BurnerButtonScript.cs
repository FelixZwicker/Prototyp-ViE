using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerButtonScript : MonoBehaviour
{
    public GameObject BurnerFlames;
    private bool active = false;

    public void ButtonPressed()
    {
        if(active == false)
        {
            BurnerFlames.SetActive(true);
            active = true;
        }
        else if(active == true)
        {
            BurnerFlames.SetActive(false);
            active = false;
        }
    }
}

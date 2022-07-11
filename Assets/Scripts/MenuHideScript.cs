using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHideScript : MonoBehaviour
{
    public GameObject Menu;
 
    public void HideMenu()
    {
        if(Menu.activeInHierarchy == true)
        {
            Menu.SetActive(false);
        }
        else
        {
            Menu.SetActive(true);
        }
    }
}

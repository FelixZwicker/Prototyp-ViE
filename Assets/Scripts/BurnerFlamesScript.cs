using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerFlamesScript : MonoBehaviour
{
    public GameObject flames;
    bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            if(active == false)
            {
                flames.SetActive(true);
                active = true;
            }
            else
            {
                flames.SetActive(false);
                active = false;
            }
        }
    }
    
}

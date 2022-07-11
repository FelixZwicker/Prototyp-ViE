using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPouringScript : MonoBehaviour
{
    private ParticleSystem waterPouring;
    void Start()
    {
        waterPouring = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            waterPouring.Play();
        }
        else
        {
            waterPouring.Stop();
        }
    }
}

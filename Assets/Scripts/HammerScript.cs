using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public ShakingScript shakingScript;
    public GameObject CheckmarkBeat;
    public GameObject[] Powders;
    public ParticleSystem Explosion;
    public AudioSource audioSource;
    public AudioClip explosionSound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void DestroyPowders()
    {
        for(int x = 0; x < Powders.Length; x++)
        {
            Destroy(Powders[x]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "powder" && shakingScript.mixed == true)
        {
            Explosion.Play();
            audioSource.PlayOneShot(explosionSound, 0.3f);
            DestroyPowders();
            CheckmarkBeat.SetActive(true);
        }
    }
}

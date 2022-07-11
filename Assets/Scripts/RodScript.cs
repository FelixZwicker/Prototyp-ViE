using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodScript : MonoBehaviour
{
    public ShakingScript shakingScript;
    public GameObject CheckmarkExplosion;
    public GameObject CheckmarkHeatUp;
    public GameObject[] Powders;
    public Material BurningMaterial;
    public Material Standart;
    public ParticleSystem Explosion;
    public AudioSource audioSource;
    public AudioClip explosionSound;

    private MeshRenderer meshRenderer;
    private bool glowing;
    private bool reactable;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        glowing = false;
        reactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(glowing == true)
        {
            glowing = false;
            StartCoroutine(CoolingDown());
        }
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
        if (other.gameObject.tag == "Burner" && glowing == false)
        {
            StartCoroutine(HeatUp());
        }

        if (other.gameObject.tag == "powder" && reactable == true && shakingScript.mixed == true)
        {
            Explosion.Play();
            audioSource.PlayOneShot(explosionSound, 0.3f);
            DestroyPowders();
            CheckmarkExplosion.SetActive(true);
        }
    }

    IEnumerator HeatUp()
    {
        yield return new WaitForSeconds(5);

        meshRenderer.material = BurningMaterial;
        CheckmarkHeatUp.SetActive(true);
        glowing = true;
        reactable = true;
    }

    IEnumerator CoolingDown()
    {
        yield return new WaitForSeconds(10);

        meshRenderer.material = Standart;
        reactable = false;
    }
}

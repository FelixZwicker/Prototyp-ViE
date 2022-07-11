using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStickScript : MonoBehaviour
{
    public Material BurningMaterial;
    public Material BurnedDown;
    public GameObject Flames;
    public GameObject CheckmarkHeatUp;
    public GameObject CheckmarkCooledDown;

    private MeshRenderer meshRenderer;
    private bool reactable;
    private bool heatUpRunning;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        reactable = false;
        heatUpRunning = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Burner" && heatUpRunning == false)
        {
            StartCoroutine(HeatUp());
        }

        if(other.gameObject.tag == "Tube" && reactable == true)
        {
            StartCoroutine(TubeInteraction());
        }
    }

    private void ActivateFlames()
    {
        Flames.SetActive(true);
    }

    private void DeactivateFlames()
    {
        Flames.SetActive(false);
    }

    IEnumerator HeatUp()
    {
        heatUpRunning = true;
        yield return new WaitForSeconds(5);

        meshRenderer.material = BurningMaterial;
        ActivateFlames();
        CheckmarkHeatUp.SetActive(true);

        yield return new WaitForSeconds(10);

        DeactivateFlames();
        CheckmarkCooledDown.SetActive(true);
        reactable = true;
        heatUpRunning = false;

        StartCoroutine(CooledDown());
    }

    IEnumerator CooledDown()
    {
        yield return new WaitForSeconds(20);

        if (heatUpRunning == false)
        {
            meshRenderer.material = BurnedDown;
            reactable = false;
        }
    }

    IEnumerator TubeInteraction()
    {
        ActivateFlames();
        yield return new WaitForSeconds(3);
        DeactivateFlames();
    }
}

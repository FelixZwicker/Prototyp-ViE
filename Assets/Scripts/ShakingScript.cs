using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingScript : MonoBehaviour
{
    public GameObject Interactable;
    public GameObject SecondChem;
    public GameObject WrongChem;
    public GameObject CheckmarkGlassFilled;
    public GameObject CheckmarkMixed;
    public GameObject CheckmarkGlassEmpty;
    public bool mixed;
    private float xOld;
    private float xNew;
    private float zOld;
    private float zNew;
    private float currentXPos;
    private float currentZPos;
    private int countSwivel;
    public Material newChemicalMaterial;
    MeshRenderer meshRenderer;
    MeshRenderer secondMeshRenderer;

    void Start()
    {
        xOld = Interactable.transform.position.x;
        zOld = Interactable.transform.position.z;
        meshRenderer = GetComponent<MeshRenderer>();
        secondMeshRenderer = SecondChem.GetComponent<MeshRenderer>();
        mixed = false;
        countSwivel = 0;
    }

    void Update()
    {
        currentXPos = Interactable.transform.position.x;
        currentZPos = Interactable.transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        //chemicals are colliding
        if(other.gameObject.name == SecondChem.name)
        {
            CheckSwivel(currentXPos, currentZPos);

            if (countSwivel == 3)
            {
                meshRenderer.material = newChemicalMaterial;
                secondMeshRenderer.material = newChemicalMaterial;
                CheckmarkMixed.SetActive(true);
                //used by RodScript
                mixed = true;
            }
        }

        if(other.gameObject.name == WrongChem.name)
        {
            Debug.Log("Wrong Chem, start again");
        }

        //chemicals in glass
        if(other.gameObject.tag == "Glass")
        {
            CheckmarkGlassFilled.SetActive(true);
        }

        //Chemical on plate
        if(other.gameObject.tag == "Plate" && mixed == true)
        {
            CheckmarkGlassEmpty.SetActive(true);
        }
    }

    public int CheckSwivel(float xNewPosition, float xOldPosition)
    {
        xNew = xNewPosition;
        zNew = xOldPosition;

        float xCompare = Mathf.Abs(xOld) - Mathf.Abs(xNew);
        float zCompare = Mathf.Abs(zOld) - Mathf.Abs(zNew);

        if (Mathf.Abs(xCompare) > 0.01f || Mathf.Abs(zCompare) > 0.01f)
        {
            countSwivel++;
        }

        xOld = xNew;
        zOld = zNew;

        return countSwivel;
    }
}

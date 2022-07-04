using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodScript : MonoBehaviour
{
    public GameObject Rod;

    private Material BurningMaterial;
    private MeshRenderer MeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        BurningMaterial = Resources.Load<Material>("BurningRed");
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Burner")
        {
            StartCoroutine(Counter());
        }
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(5);

        MeshRenderer.material = BurningMaterial;
    }
}

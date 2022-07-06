using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodScript : MonoBehaviour
{
    public GameObject Rod;
    public Material BurningMaterial;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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

        meshRenderer.material = BurningMaterial;
    }
}

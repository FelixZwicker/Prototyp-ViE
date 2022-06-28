using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingScript : MonoBehaviour
{
    public GameObject interactable;
    private float xOld;
    private float xNew;
    private float zOld;
    private float zNew;
    private int countSwivel;

    // Start is called before the first frame update
    void Start()
    {
        xOld = interactable.transform.position.x;
        zOld = interactable.transform.position.z;
        countSwivel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentXPos = interactable.transform.position.x;
        float currentZPos = interactable.transform.position.z;
        CheckSwivel(currentXPos, currentZPos);

        if(countSwivel == 3)
        {
            Debug.Log("done");
        }
    }

    int CheckSwivel(float xNewPosition, float xOldPosition)
    {
        xNew = xNewPosition;
        zNew = xOldPosition;

        float xCompare = Mathf.Abs(xOld) - Mathf.Abs(xNew);
        float zCompare = Mathf.Abs(zOld) - Mathf.Abs(zNew);

        if (Mathf.Abs(xCompare) > 0.08f || Mathf.Abs(zCompare) > 0.08f)
        {
            countSwivel++;
        }

        xOld = xNew;
        zOld = zNew;

        return countSwivel;
    }
}

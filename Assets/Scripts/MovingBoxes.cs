using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxes : MonoBehaviour
{
    public GameObject presentBox;
    // Start is called before the first frame update
    private Vector3 currentPos;
    private float yDiff;

    private void Start()
    {
        currentPos = gameObject.transform.position;
        yDiff = presentBox.transform.position.y - gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != currentPos)
        {
            presentBox.transform.position = new Vector3(transform.position.x, transform.localPosition.y, transform.position.z);
        }
        currentPos = gameObject.transform.position;
    }
}

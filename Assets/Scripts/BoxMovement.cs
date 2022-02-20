using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(box.transform.position.x, 1.5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(box.transform.position.x, 1.5f, 10f);
    }
}

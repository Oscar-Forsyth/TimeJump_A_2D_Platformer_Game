using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject box;
    private float length;

    // Start is called before the first frame update
    void Start()
    {
       
        float length = box.GetComponent<Collider2D>().bounds.size.y;
        this.transform.position = new Vector3(box.transform.position.x, 1.0f + length, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(box.transform.position.x, 1.0f + length, 10f);
    }
}

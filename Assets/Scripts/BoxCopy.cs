using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCopy : MonoBehaviour
{

    [SerializeField]
    GameObject futureBox;


    // Update is called once per frame
    void Update()
    {
        var tempVec = new Vector3(this.transform.position.x, this.transform.position.y+90, this.transform.position.z);
        futureBox.transform.position = tempVec;
    }
}

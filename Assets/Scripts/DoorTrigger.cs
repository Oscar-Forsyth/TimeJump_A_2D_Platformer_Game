using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject door;
    bool isTriggered = false;
    float doorY;
    float origY;
    Vector3 origDoor;
    ArrayList numberCheck = new ArrayList();

    private void Start()
    {
        doorY = door.transform.position.y;
        origY = doorY;
        origDoor = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        numberCheck.Add(1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isTriggered = true;
        ChangeYValue(isTriggered);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        numberCheck.Remove(1);

        if(!(numberCheck.Count > 0))
        {
            isTriggered = false;
            ChangeYValue(isTriggered);
        }

    }

    private void ChangeYValue(bool isTrigg)
    {
        if (isTrigg && door.transform.position.y < origY + 1)
        {
            door.transform.position += new Vector3(0, doorY + 2, 0);
            //this.transform.position += new Vector3(0, -0.1f, 0.1f);
            
        }
        if(!isTrigg)
        {
            door.transform.position = origDoor;
            //this.transform.position += new Vector3(0, 0.1f, -0.1f);
        }
    }


}

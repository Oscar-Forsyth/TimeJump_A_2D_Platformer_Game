using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedScript : MonoBehaviour 
{
    public GameObject tree;
    public GameObject seed;
 


    public void OnTriggerStay2D(Collider2D col)
    {
      
        if (col.CompareTag("Seed"))
        {
           
            Destroy(GameObject.FindWithTag("Tree"));
            Vector3 treePos = new Vector3(0f, 24.25f, 10f);
            Instantiate(tree, col.transform.position + treePos, Quaternion.identity);
        }
        
    }
    public void OnTriggerExit2D(Collider2D col)
    {

        if (col.CompareTag("Seed"))
        {
            Destroy(GameObject.FindWithTag("Tree"));
        }

    }

}

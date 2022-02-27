using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3TextHints : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject textBox;

    void Start()
    {
        textBox.SetActive(false);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public WallBehaviour wallBehaviour;
    

    void Start()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        wallBehaviour.go();
       
    }



}

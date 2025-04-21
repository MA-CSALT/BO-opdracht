using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    Vector3 originalPos;

    //public timer Timer; 

    // Update is called once per frame
    void Update()
    {
        
    }

    //public class timer : MonoBehaviour 

 
    

    void OnTriggerEnter(Collider other)
    {
        //GetComponent<timer>().targetTime();

        //targetTime = 0.0f; kan er niet uitkomen hoe je een function aanroept uit een ander script. dus krijg ik dit niet werkend

        gameObject.transform.position = originalPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    Light light;
   
    private GameObject goFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        goFollow = Camera.main.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            light.enabled = !light.enabled; 
        }
      
    }

}

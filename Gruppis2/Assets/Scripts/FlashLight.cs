using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    new Light light; // skapar light
    private GameObject goFollow; // följer efter

    public AudioSource ljud; // ljud / av och på ljud. 
     
     void Start()
    {
        light = GetComponent<Light>(); // skapar light
        goFollow = Camera.main.gameObject; // följer efter camera movementet
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) // stänger av och på, på F. 
        {
            ljud.Play(); // spelar av o på ljudet
            light.enabled = !light.enabled; // stänger av / på ljuset beroende på vad den är. 
        }
      
    }

}

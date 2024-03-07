using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    new Light light; // skapar light
    private GameObject goFollow; // f�ljer efter

    public AudioSource ljud; // ljud / av och p� ljud. 
     
     void Start()
    {
        light = GetComponent<Light>(); // skapar light
        goFollow = Camera.main.gameObject; // f�ljer efter camera movementet
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) // st�nger av och p�, p� F. 
        {
            ljud.Play(); // spelar av o p� ljudet
            light.enabled = !light.enabled; // st�nger av / p� ljuset beroende p� vad den �r. 
        }
      
    }

}

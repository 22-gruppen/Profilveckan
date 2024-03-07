using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutSystem : MonoBehaviour
{
    public GameObject hideText, stopHideText; // text
    public GameObject normalPlayer, hidingPlayer; // spelaren och hideing spelaren (n�r den g�mmer sig) 
    
   
    bool interactable, hiding; // kollar om man kan trycka E f�r att g�mma sig och om du g�mmer dig
    public float loseDistance; // hur l�ngt du �r ifr�n objektet om du �r tex. 2 m ifr�n kan du inte g�mma dig. Kolla avst�ndet och om du kan g�mma dig. 

    void Start() // s�tter dem till falskt direkt. 
    {
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other) // g�r in i trigger f�ltet
    {
        if (other.CompareTag("MainCamera")) // om den har taggen MainCamera s� den inte g�r de p� alla objekt.
        {
            hideText.SetActive(true); // d� visar den text och den blir interactable. 
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) // samma sak fast tv�rtom. G�r utan f�r f�ltet s� f�rsvinner allt. 
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true) // kollar om du kan trycka E
        {
            if (Input.GetKeyDown(KeyCode.E)) // Om trycker E. S� f�rsvinner hideText och en annan kamera blir aktiv och normala kameran blir inaktiv. 
            {
                hideText.SetActive(false);
                hidingPlayer.SetActive(true);
               
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if (hiding == true) // om du g�mmer dig 
        {
            if (Input.GetKeyDown(KeyCode.Q)) // tryck Q f�r att sluta g�mma dig och allt blir till normalt igen. 
            {
                stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}



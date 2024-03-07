using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutSystem : MonoBehaviour
{
    public GameObject hideText, stopHideText; // text
    public GameObject normalPlayer, hidingPlayer; // spelaren och hideing spelaren (när den gömmer sig) 
    
   
    bool interactable, hiding; // kollar om man kan trycka E för att gömma sig och om du gömmer dig
    public float loseDistance; // hur långt du är ifrån objektet om du är tex. 2 m ifrån kan du inte gömma dig. Kolla avståndet och om du kan gömma dig. 

    void Start() // sätter dem till falskt direkt. 
    {
        interactable = false;
        hiding = false;
    }
    void OnTriggerStay(Collider other) // går in i trigger fältet
    {
        if (other.CompareTag("MainCamera")) // om den har taggen MainCamera så den inte gör de på alla objekt.
        {
            hideText.SetActive(true); // då visar den text och den blir interactable. 
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) // samma sak fast tvärtom. Går utan för fältet så försvinner allt. 
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
            if (Input.GetKeyDown(KeyCode.E)) // Om trycker E. Så försvinner hideText och en annan kamera blir aktiv och normala kameran blir inaktiv. 
            {
                hideText.SetActive(false);
                hidingPlayer.SetActive(true);
               
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if (hiding == true) // om du gömmer dig 
        {
            if (Input.GetKeyDown(KeyCode.Q)) // tryck Q för att sluta gömma dig och allt blir till normalt igen. 
            {
                stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}



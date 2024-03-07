using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTicket : MonoBehaviour
{

    private bool isMouseOver = false;
    private bool canPickUp = false;
    public GameObject pickText;
    public GameObject FakeText;


    private void Start() // g�r all text osynlig direkt
    {
        pickText.SetActive(false);
        FakeText.SetActive(false); 
    }

    private void OnGUI()
    {
     
        if (isMouseOver && canPickUp && Input.GetKeyDown(KeyCode.E))  // om jag trycker E p� en falskt biljett s�� visas det en text att det �r en fake ticket. 
        {
            pickText.SetActive(false);
            FakeText.SetActive(true);
        }

    }

    private void Update()
    {
       
    }

    private void OnMouseEnter() // om musen g�r �ver objectet s� s�tts dessa till true aka dem syns. 
    {
        isMouseOver = true;
        pickText.SetActive(true); 
        
        canPickUp = true; 
    }

    private void OnMouseExit() // n�r musen g�r bort fr�n objektet s� fr�svinner allt nedanf�r. 
    {
        isMouseOver = false;
        pickText.SetActive(false);
        FakeText.SetActive(false);
        canPickUp = false; 
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTicket : MonoBehaviour
{

    private bool isMouseOver = false;
    private bool canPickUp = false;
    public GameObject pickText;
    public GameObject FakeText;


    private void Start() // gör all text osynlig direkt
    {
        pickText.SetActive(false);
        FakeText.SetActive(false); 
    }

    private void OnGUI()
    {
     
        if (isMouseOver && canPickUp && Input.GetKeyDown(KeyCode.E))  // om jag trycker E på en falskt biljett såå visas det en text att det är en fake ticket. 
        {
            pickText.SetActive(false);
            FakeText.SetActive(true);
        }

    }

    private void Update()
    {
       
    }

    private void OnMouseEnter() // om musen går över objectet så sätts dessa till true aka dem syns. 
    {
        isMouseOver = true;
        pickText.SetActive(true); 
        
        canPickUp = true; 
    }

    private void OnMouseExit() // när musen går bort från objektet så frösvinner allt nedanför. 
    {
        isMouseOver = false;
        pickText.SetActive(false);
        FakeText.SetActive(false);
        canPickUp = false; 
    }

    
}

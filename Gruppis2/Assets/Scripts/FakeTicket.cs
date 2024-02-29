using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTicket : MonoBehaviour
{

    private bool isMouseOver = false;
    private bool canPickUp = false;
    public GameObject pickText;
    public GameObject FakeText;


    private void Start()
    {
        pickText.SetActive(false);
        FakeText.SetActive(false); 
    }

    private void OnGUI()
    {
     
        if (isMouseOver && canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            pickText.SetActive(false);
            FakeText.SetActive(true);
        }

    }

    private void Update()
    {
       
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        pickText.SetActive(true); 
        
        canPickUp = true; // Set canPickUp to true when mouse is over the object
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        pickText.SetActive(false);
        FakeText.SetActive(false);
        canPickUp = false; // Reset canPickUp when mouse exits the object
    }

    
}

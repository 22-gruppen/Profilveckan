using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTicket : MonoBehaviour
{

    private bool isMouseOver = false;
    private bool canPickUp = false;
    public GameObject pickText;
    public GameObject Count; 


    private int objectCount = 0; // Variable to keep track of the object count

    private void OnGUI()
    {
        if (isMouseOver)
        {

            pickText.SetActive(true); 

        }
        if (isMouseOver && canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            
            UpdateObjectCount(); // Update object count
        }
    }

    private void Update()
    {
        if (isMouseOver && canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            UpdateObjectCount(); // Update object count
        }
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
        canPickUp = false; // Reset canPickUp when mouse exits the object
    }

    private void UpdateObjectCount()
    {
        // Increment the count and update the text
        objectCount++; // Increment the count
        objectCount = Mathf.Clamp(objectCount, 0, 5); // Ensure the count stays between 0 and 5


    }
}

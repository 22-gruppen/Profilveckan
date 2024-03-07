using TMPro;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickText;
    
    private bool isMouseOver = false; // om mus �r �ver

    public bool hasTicket = false; // kollar om du en ticket.

    public TextMeshProUGUI foundtickettext;

    private void Start()
    {
        pickText.SetActive(false);
    }

    private void Update()
    {
        if (isMouseOver && Input.GetKeyDown(KeyCode.E)) // om du har musen �ver och du trycker E s� tar du upp den. / g�r till Pick up metoden
        {
            PickUp();
        }

        if (hasTicket == true) // om du har en ticket d� visas denna text. 
        {
            foundtickettext.text = "Looks like I found the right ticket. I need to go sit down in the train!";
        }
    }

    private void OnMouseEnter() // n�r musen �r vid objektets hitbox s� visas Pick up text. 
    {
        isMouseOver = true;
        pickText.SetActive(true);
    }

    private void OnMouseExit() // n�r du �r utanf�r hitboxen s� f�rsvinner texten
    {
        isMouseOver = false;
        pickText.SetActive(false);
    }

    private void PickUp() // pick up metoden som g�r att objektet f�rsvinner, texten f�rsvinner som s�ger "pick up" och texten visas som s�ger att du har en biljett. 
    {
     
        gameObject.SetActive(false);
        pickText.SetActive(false);
        hasTicket = true;
    }
}


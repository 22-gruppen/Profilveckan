using TMPro;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickText;
    
    private bool isMouseOver = false; // om mus är över

    public bool hasTicket = false; // kollar om du en ticket.

    public TextMeshProUGUI foundtickettext;

    private void Start()
    {
        pickText.SetActive(false);
    }

    private void Update()
    {
        if (isMouseOver && Input.GetKeyDown(KeyCode.E)) // om du har musen över och du trycker E så tar du upp den. / går till Pick up metoden
        {
            PickUp();
        }

        if (hasTicket == true) // om du har en ticket då visas denna text. 
        {
            foundtickettext.text = "Looks like I found the right ticket. I need to go sit down in the train!";
        }
    }

    private void OnMouseEnter() // när musen är vid objektets hitbox så visas Pick up text. 
    {
        isMouseOver = true;
        pickText.SetActive(true);
    }

    private void OnMouseExit() // när du är utanför hitboxen så försvinner texten
    {
        isMouseOver = false;
        pickText.SetActive(false);
    }

    private void PickUp() // pick up metoden som gör att objektet försvinner, texten försvinner som säger "pick up" och texten visas som säger att du har en biljett. 
    {
     
        gameObject.SetActive(false);
        pickText.SetActive(false);
        hasTicket = true;
    }
}


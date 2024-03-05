using TMPro;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickText;
    
    private bool isMouseOver = false;

    public bool hasTicket = false;

    public TextMeshProUGUI foundtickettext;

    private void Start()
    {
        pickText.SetActive(false);
    }

    private void Update()
    {
        if (isMouseOver && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        if (hasTicket == true)
        {
            foundtickettext.text = "Looks like I found the right ticket. I need to go sit down in the train!";
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        pickText.SetActive(true);
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        pickText.SetActive(false);
    }

    private void PickUp()
    {
        // Perform pickup action
        // For now, let's just deactivate the pickup object
        gameObject.SetActive(false);
        pickText.SetActive(false);
        hasTicket = true;
    }
}


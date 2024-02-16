using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public GameObject pickText;
    public int scoreValue = 10;

    private bool isMouseOver = false;

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

        // Update player's score or perform other actions


        // Optionally, you can play a sound, show an animation, etc.
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sit : MonoBehaviour
{
    // Variabler
    public GameObject stand, sit, intText, standText;
    public bool interactable, isSitting;
    public GameObject pickup;
    private PickupScript pick;
    public bool sitting = false;
    private int nästaScene;

    // Start metod
    private void Start()
    {
        pick = pickup.GetComponent<PickupScript>();
        nästaScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Interactable blir sant om man tittar på sättenas hitbox (hitboxen för att sätta sig är sträckt över hela tågets golv)
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    // Interactable blir falskt om man slutar titta på sättenas hitbox
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Man kan sätta sig ner om interactable är sant
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                intText.SetActive(false);
                standText.SetActive(true);
                sit.SetActive(true);
                stand.SetActive(false);
                interactable = false;
                sitting = true;
            }
        }

        // Gör så att man kan ställa sig upp om man sitter ner
        if (sit == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                sit.SetActive(false);
                standText.SetActive(false);
                stand.SetActive(true);
                isSitting = false;
                sitting = false;
            }
        }

        // Åker vidare om man har biljet
        if (sitting == true)
        {
            if (pick.hasTicket)
            {
                SceneManager.LoadScene(nästaScene);
            }
        }
    }
}

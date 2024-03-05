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
    private int n�staScene;

    // Start metod
    private void Start()
    {
        pick = pickup.GetComponent<PickupScript>();
        n�staScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Interactable blir sant om man tittar p� s�ttenas hitbox (hitboxen f�r att s�tta sig �r str�ckt �ver hela t�gets golv)
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    // Interactable blir falskt om man slutar titta p� s�ttenas hitbox
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
        // Man kan s�tta sig ner om interactable �r sant
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

        // G�r s� att man kan st�lla sig upp om man sitter ner
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

        // �ker vidare om man har biljet
        if (sitting == true)
        {
            if (pick.hasTicket)
            {
                SceneManager.LoadScene(n�staScene);
            }
        }
    }
}

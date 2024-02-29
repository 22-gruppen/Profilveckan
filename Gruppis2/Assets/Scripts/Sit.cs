using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    public GameObject stand, sit, intText, standText;
    public bool interactable, isSitting;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                intText.SetActive(false);
                standText.SetActive(true);
                sit.SetActive(true);
                stand.SetActive(false);
                interactable = false;
            }
        }
        if (sit == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                sit.SetActive(false);
                standText.SetActive(false);
                stand.SetActive(true);
                isSitting = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText, findtickettext; // En variabel för att hitta texten i spelet.
    public int timemin, timesec;
    string timeTypemin, timeTypesec;
    private bool timesup = false;

    void Start()
    {
        timesup = false;
        StartCoroutine(timer()); // Startar cooldown metoden för tid.
        StartCoroutine(texttimer()); // Startar cooldown metoden för text.
    }

    // Update is called once per frame
    void Update()
    {
        timeTypesec = timesec.ToString(); // Gör om sekund variabeln till en string

        timeTypemin = timemin.ToString(); // Gör om minut variabeln till en string

        timeText.text = timeTypemin + ":" + timeTypesec; // Skriver ut minuter och sekunder i spelet. 


        if (timesup == false)
        {
            if (timesec <= 0 && timemin > 0) // Efter sekunder har nått noll så subtraheras minuter med ett Sålänge inte minuter är noll.
            {
                timesec = 59;
                timemin -= 1;
            }
        }

        if (timesec == 0 && timemin == 0) // Om timern når noll sätts times up till true och man åker tillbaka till main menu.
        {
            timesup = true;
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    private IEnumerator timer() //Cooldown metod
    {
        WaitForSeconds waitsec = new WaitForSeconds(1.0f);

        

        while (timesec >= 0)
        {
            yield return waitsec;
            timesec -= 1; //minskar sekund variabeln med ett varje sekund.
        }

    }

    private IEnumerator texttimer() // Cooldown metod för text.
    {
        WaitForSeconds textwait = new WaitForSeconds(5.0f);

        yield return textwait;
        findtickettext.text = " "; //Text som hintar vad du ska göra försvinner efter 10 sekunder
    }

}

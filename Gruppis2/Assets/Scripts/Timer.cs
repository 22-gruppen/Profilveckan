using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public int timemin, timesec;
    string timeTypemin, timeTypesec;
    private bool timesup = false;

    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        timeTypesec = timesec.ToString();

        timeTypemin = timemin.ToString();

        timeText.text = timeTypemin + ":" + timeTypesec;


        if (timesup == false)
        {
            if (timesec <= 0 && timemin > 0)
            {
                timesec = 59;
                timemin -= 1;
            }
        }

        if (timesec == 0 && timemin == 0)
        {
            timesup = true;
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    private IEnumerator timer()
    {
        WaitForSeconds waitsec = new WaitForSeconds(1.0f);

        while (timesec >= 0)
        {
            yield return waitsec;
            timesec -= 1;
        }
    }

}

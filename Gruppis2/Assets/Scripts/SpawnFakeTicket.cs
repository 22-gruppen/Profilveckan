using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] fakeTickets;
    // Start is called before the first frame update
    void Start()
    {

        int randomNumber88 = 0;

        List<Vector3> SpawnPoints = new List<Vector3>();
        List<int> randomnumbersbruben2024 = new List<int>();

        SpawnPoints.Add(new Vector3(0,3,2));
        SpawnPoints.Add(new Vector3(-20, 3, -13));
        SpawnPoints.Add(new Vector3(-3, 3, 2)    );
        SpawnPoints.Add(new Vector3(-5, 2, 4));
        SpawnPoints.Add(new Vector3(-5, 7, 2));



        bool add = true;

        foreach (GameObject ticket in fakeTickets)
        {

            randomNumber88 = Random.Range(0, 10);

            

            for (int i = 0; i < randomnumbersbruben2024.Count; i++)
            {
                if(randomNumber88 == randomnumbersbruben2024[i])
                {
                    add = false;

                }
            }

            randomnumbersbruben2024.Add(randomNumber88);
            if (add == true)
                ticket.transform.position = SpawnPoints[randomNumber88];


            add = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using
    System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRealTicket : MonoBehaviour
{
    public GameObject[] realTicket;
    // Start is called before the first frame update
    void Start()
    {
        float z = 8;
        float x = -4;
        foreach (GameObject ticket in realTicket)
        {
            x = Random.Range(-20, 20);
            z = Random.Range(-13, 12);

            ticket.transform.position = new Vector3(x, 2, z);
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Draw()
    {
       
    }
}

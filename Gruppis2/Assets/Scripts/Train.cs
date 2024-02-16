using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // public AudioSource tågkör;

    public List<GameObject> dörrar;

    // Variables
    public float smoothTime = 0.5f;
    public Vector3 target = new Vector3(0f, -0.1f, -6f);
    public Vector3 currentVelocity;
    public bool moving = true;

    float velocity = 15f;

    Vector3 nextpos;

    private void Update()
    {
        if (moving == true)
        {

         /*   if (tågkör.isPlaying == false)
            {
                tågkör.Play();
            } */

            nextpos = Vector3.MoveTowards(transform.position, new Vector3(0f, -0.1f, transform.position.z), velocity * Time.deltaTime);

            transform.position = nextpos;
        }

        if (transform.position == target)
        {
            moving = false;
        }

        else
            moving = true;
        
        if (moving == false)
        {
            //tågkör.Stop();
            dörrar[0].transform.position = Vector3.MoveTowards(dörrar[0].transform.position, new Vector3(2.1f, dörrar[0].transform.position.y, dörrar[0].transform.position.z), 0.1f * Time.deltaTime);
            dörrar[1].transform.position = Vector3.MoveTowards(dörrar[1].transform.position, new Vector3(1.15f, dörrar[1].transform.position.y, dörrar[1].transform.position.z), 0.1f * Time.deltaTime);
            dörrar[2].transform.position = Vector3.MoveTowards(dörrar[2].transform.position, new Vector3(-1.7025f, dörrar[2].transform.position.y, dörrar[2].transform.position.z), 0.1f * Time.deltaTime);
            dörrar[3].transform.position = Vector3.MoveTowards(dörrar[3].transform.position, new Vector3(-2.69f, dörrar[3].transform.position.y, dörrar[3].transform.position.z), 0.1f * Time.deltaTime);
        }
    }
}
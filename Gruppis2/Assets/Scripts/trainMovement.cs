using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainMovement : MonoBehaviour
{
    public List<GameObject> d�rrar;

    // Variables
    public float smoothTime = 0.5f;
    public Vector3 target = new Vector3(0f, -0.1f, -6f);
    Vector3 currentVelocity;
    public bool moving = true;

    float velocity = 50f;

    Vector3 nextpos;

    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
        if (moving == true)
        {
            nextpos = Vector3.MoveTowards(transform.position, new Vector3(0f, -0.1f, transform.position.z), velocity * Time.deltaTime);

            transform.position = nextpos;
        }

        if (transform.position == target)
        {
            moving = false;
        }
        
        if (moving == false)
        {
            d�rrar[0].transform.position = Vector3.MoveTowards(d�rrar[0].transform.position, new Vector3(2.1f, d�rrar[0].transform.position.y, d�rrar[0].transform.position.z), 0.1f * Time.deltaTime);
            d�rrar[1].transform.position = Vector3.MoveTowards(d�rrar[1].transform.position, new Vector3(1.15f, d�rrar[1].transform.position.y, d�rrar[1].transform.position.z), 0.1f * Time.deltaTime);
            d�rrar[2].transform.position = Vector3.MoveTowards(d�rrar[2].transform.position, new Vector3(-1.7025f, d�rrar[2].transform.position.y, d�rrar[2].transform.position.z), 0.1f * Time.deltaTime);
            d�rrar[3].transform.position = Vector3.MoveTowards(d�rrar[3].transform.position, new Vector3(-2.69f, d�rrar[3].transform.position.y, d�rrar[3].transform.position.z), 0.1f * Time.deltaTime);
        }
    }
}
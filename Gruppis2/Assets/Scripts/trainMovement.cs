using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainMovement : MonoBehaviour
{
    // Variables
    public float smoothTime = 0.5f;
    public Vector3 target = new Vector3(0, 0, 0);
    Vector3 currentVelocity;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}
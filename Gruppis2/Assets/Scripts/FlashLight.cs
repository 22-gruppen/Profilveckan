using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    Light light;
    private Vector3 v3Offset;
    private GameObject goFollow;
    private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        goFollow = Camera.main.gameObject;
        v3Offset = transform.position - goFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            light.enabled = !light.enabled; 
        }
        transform.position = goFollow.transform.position + v3Offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }

}

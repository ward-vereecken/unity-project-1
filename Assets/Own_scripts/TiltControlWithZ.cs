using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControlWithZ : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0F, Input.acceleration.y);
        Debug.Log(movement);
        rb.velocity = movement * 5;
    }
}

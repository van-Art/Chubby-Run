using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float shootSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, -shootSpeed * Time.deltaTime);
    }
}

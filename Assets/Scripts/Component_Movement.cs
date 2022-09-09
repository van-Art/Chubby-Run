using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component_Movement : MonoBehaviour
{
    Rigidbody rb;

    public float force;

    public float speed;
    public float row;
    public float xValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;

        rb.position = rb.position + movement;
        rb.position = Vector3.Lerp(rb.position, new Vector3((row - 1) * xValue, rb.position.y, rb.position.z), 10 * Time.deltaTime);
        if (Random.value < 0.01f)
        {
            row = Random.Range(0, 3);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        float row1 = row;
        if (col.gameObject.tag == "obs")
        {
            rb.AddForce(Vector3.up * force);
        }
    }
    IEnumerator GoBack(float row1)
    {
        yield return new WaitForSeconds(3f);
        row = row1;
    }
}

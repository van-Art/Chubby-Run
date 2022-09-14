using UnityEngine;
using System.Collections;

public class ShootDemo : MonoBehaviour
{
    public Rigidbody projectile;

    public float speed = 20;

    void Update()
    {
        if (Input.GetButtonDown("fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}

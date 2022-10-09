using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectSystem : MonoBehaviour
{
    public GameObject redEffect;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(redEffect, col.gameObject.transform.position, Quaternion.identity);
        }
    }
}

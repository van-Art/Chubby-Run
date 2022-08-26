using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public Vector3 rotAngel;
    public float speed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(rotAngel * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform shootPoint;

    public GameObject bullet;
    public float shootTime;
    void Start()
    {
        StartCoroutine(shoot());
    }
    void Update()
    {
            
    }
    IEnumerator shoot()
    {
        GameObject obj = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(shootTime);
        StartCoroutine(shoot());
    }
}

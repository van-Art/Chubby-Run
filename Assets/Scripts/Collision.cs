using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "refrigeratorObs" || col.gameObject.tag == "gas" || col.gameObject.tag == "sink" || col.gameObject.tag == "cooler" || col.gameObject.tag == "washingmachine")
        {
            Debug.Log("Collide");
            GameManager.instance.GameOver_Panel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_system : MonoBehaviour
{
    public float itemsize;
    public Transform top;
    void Start()
    {
        
    }
    void Update()
    {
        StackChildren();
    }
    public void StackChildren()
    {
        top.SetAsLastSibling();
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.localRotation = Quaternion.Lerp(child.localRotation, Quaternion.Euler(-90, 0, 0), Time.deltaTime * 10);
            Vector3 pos = new Vector3(0, 0, 0);
            int row = i;
            int col = i;
            pos.y = itemsize * i;
            pos.x = 0;
            child.localPosition = Vector3.Lerp(child.localPosition, pos, Time.deltaTime * 10);
        }
    }
}

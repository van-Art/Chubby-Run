using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    Vector3 Offset;

    float y;
    public float speedFollow;
    void Start()
    {
        Offset = transform.position;
    }
    void LateUpdate()
    {
        Vector3 followPos = Target.position + Offset;
        RaycastHit hit;
        if (Physics.Raycast(Target.position, Vector3.down, out hit, 2.5f))
        {
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * speedFollow);
        }
        else
            y = Mathf.Lerp(y, Target.position.y, Time.deltaTime * speedFollow);
        followPos.y = Offset.y + y;
        transform.position = followPos;
    }
}

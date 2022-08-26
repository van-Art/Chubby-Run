using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    Vector3 startGamePosition;
    Quaternion startGameRotation;
    Coroutine movingCoroutine;

    bool isMoving = false;
    bool isJumping = false;

    public float laneChangeSpeed = 15;
    public float jumpPower = 15;
    public float jumpGravity = -40;

    float laneOffset = 2.5f;
    float realGravity = -9.8f;
    float pointStart;
    float pointFinish;
    float lastVectorX;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        startGamePosition = transform.position;
        startGameRotation = transform.rotation;
    }
    void MovePlayer()
    {
         
    }
}

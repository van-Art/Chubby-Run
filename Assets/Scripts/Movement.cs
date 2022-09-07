using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right}
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    [Header("Player States", order = 1)]
    public SIDE m_side = SIDE.Mid;

    public bool swipeLeft;
    public bool swipeRight;
    public bool swipeUp;
    public bool swipeDown;
    public bool InJump;
    public bool InRoll;

    [Header("Player Settings")]
    public float speed = 0;
    public float dodgeSpeed;
    public float jumpForce;
    public float xValue;

    float row = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        MoveControl();
    }
    void MoveControl()
    {
        #region Moving
        //if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && row > -1)
        //{
        //    row--;
        //}

        //if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && row < 1)
        //{
        //    row++;
        //}
        #endregion
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
        if (swipeLeft)
        {
            if (m_side == SIDE.Mid)
            {
                row = -xValue;
                m_side = SIDE.Left;
            }
            else if (m_side == SIDE.Right)
            {
                row = 0;
                m_side = SIDE.Mid;
            }
        }
        else if(swipeRight)
        {
            if (m_side == SIDE.Mid)
            {
                row = xValue;
                m_side = SIDE.Right;
            }
            else if (m_side == SIDE.Left)
            {
                row = 0;
                m_side = SIDE.Mid;
            }
        }
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;

        rb.position = rb.position + movement;
        rb.position = Vector3.Lerp(rb.position, new Vector3(row, rb.position.y, rb.position.z), 10 * Time.deltaTime);
        Jump();
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && InJump == true)
        {
            anim.SetBool("jump", true);
            rb.AddForce(Vector3.up * jumpForce);
            InJump = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            InJump = true;

            anim.SetBool("jump", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ramp")
        {
            rb.velocity = new Vector3(0, 3, 3);
        }
    }
}

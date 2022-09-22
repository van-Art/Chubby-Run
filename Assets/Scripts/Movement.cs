using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SIDE { Left, Mid, Right}
public class Movement : MonoBehaviour
{
    public static Movement mInstance;

    public Transform stackParent;
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
    public bool isTaken;
    public bool isTakenTomato;
    public bool isTakenMorol;
    public bool isTakeOnion;
    public bool isDead;
    public bool isDone;
    public bool isFinished;

    [Header("Player Settings")]
    public float speed = 0;
    public float jumpForce;
    public float xValue;

    float row = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        mInstance = this;
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            InJump = true;

            anim.SetBool("jump", false);
        }
        if (col.gameObject.tag == "obs")
        {
            isDead = true;
            //Destroy(stackParent.GetChild(0).gameObject);
            //Debug.Log("Stack 0 obj:" + stackParent.GetChild(0).gameObject);
            if (stackParent.childCount < 0 || isDead == true)
            {
                //Destroy(this.gameObject);
                GameManager.instance.GameOver_Panel.SetActive(true);
                GameManager.instance.CollectableImg.SetActive(false);
                GameManager.instance.pauseButton.SetActive(false);
                GameManager.instance.resumeButton.SetActive(false);

                this.gameObject.SetActive(false);
            }

            //this.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "component")
        {
            isTaken = true;
            //Destroy(col.gameObject);
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(24, 24, 7.3f);
            col.transform.GetChild(0).gameObject.SetActive(false);
            col.gameObject.GetComponent<Component_Movement>().enabled = false;
            col.gameObject.GetComponent<CoinRotate>().enabled = false;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(col.gameObject.GetComponent<Rigidbody>());
            GameManager.instance.addComponentCount();
        }
        if(col.gameObject.tag == "exit")
        {
            isDone = true;
            GameManager.instance.Win_Panel.SetActive(true);
            GameManager.instance.CollectableImg.SetActive(false);
            Time.timeScale = 0;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lettuce")
        {
            isTakenMorol = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(20, 20, 6);
            col.GetComponent<CoinRotate>().enabled = false;
            col.GetComponent<BoxCollider>().enabled = false;
            GameManager.instance.addLettuceCount();
        }
        if(col.gameObject.tag == "onion")
        {
            isTakeOnion = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(26, 26, 2.7f);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            GameManager.instance.addOnionCount();
        }
        if (col.gameObject.tag == "tomato")
        {
            isTakenTomato = true;
            col.transform.parent = stackParent;
            GameManager.instance.addTomatoCount();
        }
    }
}

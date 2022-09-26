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
    public bool isTakenCheese;
    public bool isTakenCucumber;
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
        isDone = false;
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

        if (swipeUp)
            Jump();
        
    }
    public void SwipeLeft()
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
    public void SwipeRight()
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
    public void Jump()
    {
        if(InJump == true)
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
            if (stackParent.childCount > 5)
                TakeDamage(5);
            else
            {
                Destroy(gameObject);
                GameManager.instance.GameOver_Panel.SetActive(true);
                GameManager.instance.CollectableImg.SetActive(false);
                Destroy(GameManager.instance.pauseButton);
                Destroy(GameManager.instance.resumeButton);
            }
            col.gameObject.GetComponent<Collider>().isTrigger = true;
        }
        if (col.gameObject.tag == "patty")
        {
            isTaken = true;

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
            //SceneManager.LoadScene("Level_Selector");
            GameManager.instance.Win_Panel.SetActive(true);
            GameManager.instance.CollectableImg.SetActive(false);
            Destroy(GameManager.instance.pauseButton);
            Destroy(GameManager.instance.resumeButton);
            Time.timeScale = 0;
        }
    }
    void TakeDamage(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if(stackParent.GetChild(0).gameObject.tag == "lettuce")
            {
                GameManager.instance.morolScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "onion")
            {
                GameManager.instance.onionScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "tomato")
            {
                GameManager.instance.tomatoScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "patty")
            {
                GameManager.instance.pattScore--;
            }
            if(stackParent.GetChild(0).gameObject.tag == "cheese")
            {
                GameManager.instance.cheeseScore--;
            }
            if(stackParent.GetChild(0).gameObject.tag == "cucumber")
            {
                GameManager.instance.cucumberScore--;
            }
            stackParent.GetChild(0).parent = null;
        }
    }
    //void TurnOnCollider()
    //{
    //    hitobject.GetComponent<Collider>().isTrigger = false;
    //}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lettuce")
        {
            isTakenMorol = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(18, 18, 6);
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
            col.transform.localScale = new Vector3(.7f, .7f, .2f);
            col.transform.Rotate(0, 0, 0);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            GameManager.instance.addTomatoCount();
        }
        if(col.gameObject.tag == "cheese")
        {
            isTakenCheese = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(.5f, .5f, .5f);
            col.GetComponent<Collider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            //GameManager.instance.addCheeseCount();
        }
        if(col.gameObject.tag == "cucumber")
        {
            isTakenCucumber = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(.7f, .7f, .2f);
            col.transform.Rotate(0, 0, 0);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            //GameManager.instance.addCucumberCount();
        }
    }
}

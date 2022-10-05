using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum SIDE { Left, Mid, Right}
public class Movement : MonoBehaviour
{
    public static Movement mInstance;

    public GameObject effect;

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
    //public bool InRoll;
    public bool isComponent;
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
        isComponent = false;

        isDone = false;
        isDead = false;
        isTaken = false;
        isTakenCheese = false;
        isTakenCucumber = false;
        isTakenTomato = false;
        isTakenMorol = false;
        isTakeOnion = false;
        isFinished = false;

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
            {
                TakeDamage(5);
            }
            else if(isDead == true)
            {
                Destroy(gameObject);
                GameOver();
            }
            col.gameObject.GetComponent<Collider>().isTrigger = true;
        }
        if (col.gameObject.tag == "patty")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            isTaken = true;

            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(24, 24, 4f);
            col.transform.GetChild(0).gameObject.SetActive(false);
            col.gameObject.GetComponent<Component_Movement>().enabled = false;
            col.gameObject.GetComponent<CoinRotate>().enabled = false;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(col.gameObject.GetComponent<Rigidbody>());

            FindObjectOfType<UIGameManager>().addPattyCount();

            if(FindObjectOfType<UIGameManager>().pattScore >= 1)
            {
                isComponent = true;
            }
        }
        if (col.gameObject.tag == "tomatoObj")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            isTakenTomato = true;

            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(24, 24, 4f);
            col.gameObject.GetComponent<Component_Movement>().enabled = false;
            col.gameObject.GetComponent<CoinRotate>().enabled = false;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(col.gameObject.GetComponent<Rigidbody>());

            FindObjectOfType<UIGameManager>().addTomatoCount();

            if (FindObjectOfType<UIGameManager>().tomatoScore >= 1)
            {
                isComponent = true;
            }
        }
        if (col.gameObject.tag == "exit" && isComponent)
        {
            isDone = true;
            FindObjectOfType<UIGameManager>().WinPanelText();

            SoundManager.instance.musicSrc.clip = SoundManager.instance.clips[Random.Range(0, SoundManager.instance.clips.Length)];
            SoundManager.instance.musicSrc.Play();

            GameManager.instance.Win_Panel.SetActive(true);
            GameManager.instance.CollectableImg.SetActive(false);

            Destroy(GameManager.instance.pauseButton);
            Destroy(GameManager.instance.resumeButton);
            Time.timeScale = 0;
        }
        else if(col.gameObject.tag == "exit" && !isComponent)
        {
            FindObjectOfType<UIGameManager>().OverPanelText();

            Destroy(gameObject);

            GameManager.instance.GameOver_Panel.SetActive(true);
            GameManager.instance.CollectableImg.SetActive(false);

            Destroy(GameManager.instance.pauseButton);
            Destroy(GameManager.instance.resumeButton);
        }
    }
    void GameOver()
    {
        FindObjectOfType<UIGameManager>().OverPanelText();
        
        GameManager.instance.GameOver_Panel.SetActive(true);
        GameManager.instance.CollectableImg.SetActive(false);

        Destroy(GameManager.instance.pauseButton);
        Destroy(GameManager.instance.resumeButton);
    }
    void TakeDamage(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if(stackParent.GetChild(0).gameObject.tag == "lettuce")
            {
                FindObjectOfType<UIGameManager>().morolScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "onion")
            {
                FindObjectOfType<UIGameManager>().onionScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "tomato")
            {
                FindObjectOfType<UIGameManager>().tomatoScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "patty")
            {
                FindObjectOfType<UIGameManager>().pattScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "cheese")
            {
                FindObjectOfType<UIGameManager>().cheeseScore--;
            }
            if(stackParent.GetChild(0).gameObject.tag == "cucumber")
            {
                FindObjectOfType<UIGameManager>().cucumberScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "pattyObj")
            {
                FindObjectOfType<UIGameManager>().pattScore--;
            }
            if (stackParent.GetChild(0).gameObject.tag == "tomatoObj")
            {
                FindObjectOfType<UIGameManager>().tomatoScore--;
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
        if(col.gameObject.tag == "pattyObj")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            
            isTaken = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(24, 24, 4f);
            col.gameObject.GetComponent<CoinRotate>().enabled = false;
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<UIGameManager>().addPattyCount();
        }
        if (col.gameObject.tag == "lettuce")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            
            isTakenMorol = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(18, 18, 6);
            col.GetComponent<CoinRotate>().enabled = false;
            col.GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<UIGameManager>().addLettuceCount();
        }
        if(col.gameObject.tag == "onion")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            
            isTakeOnion = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(26, 26, 2.7f);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            FindObjectOfType<UIGameManager>().addOnionCount();
        }
        if (col.gameObject.tag == "tomato")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();
            
            isTakenTomato = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(.7f, .7f, .2f);
            col.transform.Rotate(0, 0, 0);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            FindObjectOfType<UIGameManager>().addTomatoCount();
        }
        if(col.gameObject.tag == "cheese")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();

            isTakenCheese = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(.5f, .5f, .5f);
            col.transform.Rotate(0, 0, 0);
            col.GetComponent<Collider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            FindObjectOfType<UIGameManager>().addCheeseCount();
        }
        if(col.gameObject.tag == "cucumber")
        {
            Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
            SoundManager.instance.soundEffect();

            isTakenCucumber = true;
            col.transform.parent = stackParent;
            col.transform.localScale = new Vector3(.7f, .7f, .2f);
            col.transform.Rotate(0, 0, 0);
            col.GetComponent<BoxCollider>().enabled = false;
            col.GetComponent<CoinRotate>().enabled = false;
            //FindObjectOfType<UIGameManager>().addCucumberCount();
        }
    }
}

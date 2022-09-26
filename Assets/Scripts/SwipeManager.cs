using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Movement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                //FindObjectOfType<Movement>().Jump();
                Movement.mInstance.Jump();
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                //gm.swipeDown();
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Movement.mInstance.SwipeLeft();
                Debug.Log("left swipe");
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Movement.mInstance.SwipeRight();
                Debug.Log("right swipe");
            }
        }
    }

    public void arrows()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Movement.mInstance.SwipeRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Movement.mInstance.SwipeLeft();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Movement.mInstance.Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //gm.swipeDown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        arrows();
        Swipe();
    }
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public AudioClip fxLetra;
    [SerializeField]
    private Transform place;
    [SerializeField]
    private Transform place2;
    private Vector2 initialPosition;

    public GameController gameController;
    private float deltaX, deltaY;

    public static bool locked;
    public static bool antigo;


    //efeito quando arrasta pega aumenta.
    float x;
    float y;
    //float z;
    float xN;
    float yN;


    void Start()
    {

        gameController = FindObjectOfType(typeof(GameController)) as GameController;


        initialPosition = transform.position;
        x = transform.localScale.x;
        y = transform.localScale.y;
        //z = transform.localScale.z;

        xN = x * 1.3f;
        yN = y * 1.3f;

        locked = false;
    }


    void Update()
    {
        //if (Input.touchCount > 0 && !locked) //SEM SIMULADOR
        if (!locked)
        {
            
            if (transform.position.x != initialPosition.x && initialPosition.y != transform.position.y)
            {
                transform.localScale = new Vector3(xN, yN);
            } else
            {
                transform.localScale = new Vector2(x, y);
            }
            //Touch touch = Input.GetTouch(0);//simulatess();//Input.GetTouch(0); SEM SIMULADOR
            Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        //Debug.Log(slider);
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:

                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    } 
                    break;

                case TouchPhase.Ended:
                    if (place!= null && (Mathf.Abs(transform.position.x - place.position.x) <= 1.0f &&
                       Mathf.Abs(transform.position.y - place.position.y) <= 1.0f))
                    {
                        transform.position = new Vector2(place.position.x, place.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        gameController.addRight();
                        gameController.playFx(fxLetra);
                        place = null;
                    } else if (place2 != null && (Mathf.Abs(transform.position.x - place2.position.x) <= 1.0f &&
                       Mathf.Abs(transform.position.y - place2.position.y) <= 1.0f))
                    {
                        transform.position = new Vector2(place2.position.x, place2.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        gameController.addRight();
                        gameController.playFx(fxLetra);
                        place2 = null;
                    }
                    else
                    {
                        if(initialPosition.x != transform.position.x)
                        {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                            
                            gameController.addError();
                        }
                    }
                    break;

            }
        }
    }
    private Touch simulatess()
    {
        Touch touch = new Touch();
        if (Input.GetMouseButtonDown(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Began;
            touch.position = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Moved;
            touch.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touch = new Touch();
            touch.phase = TouchPhase.Ended;
            touch.position = Input.mousePosition;
        }
        return touch;
    }
}

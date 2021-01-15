using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectDinamico : MonoBehaviour
{
    public AudioClip fxLetra;
    [SerializeField]
    private Transform place;
    [SerializeField]
    private Transform place2;
    public Vector2 initialPosition;
    private IEnumerator coroutine;
    public GameControllerBase gameController;
    private float deltaX, deltaY;
    public string tipoDinamico;

    public static bool locked;


    //efeito quando arrasta pega aumenta.
    float x;
    float y;
    //float z;
    float xN;
    float yN;

    public Transform Place { get => place; set => place = value; }
    public Transform Place2 { get => place2; set => place2 = value; }

    void Start()
    {
        //gameController = FindObjectOfType(typeof(GameControllerDinamicoAnimais)) as GameControllerDinamicoAnimais;
        //Debug.Log(tipoDinamico);
        if (tipoDinamico.Equals("Cores"))
        {
            //Debug.Log("Cores");
            gameController = FindObjectOfType(typeof(GameControllerDinamicoCores)) as GameControllerDinamicoCores;
        } else if (tipoDinamico.Equals("Sons"))
        {
            //Debug.Log("Sons");
            gameController = FindObjectOfType(typeof(GameControllerDinamicoAnimais)) as GameControllerDinamicoAnimais;
        } else if (tipoDinamico.Equals("Objetos"))
        {
            //Debug.Log("Objetos");
            gameController = FindObjectOfType(typeof(GameControllerDinamicoObjetos)) as GameControllerDinamicoObjetos;
        }
        coroutine = waith();
        StartCoroutine("waith");
        x = transform.localScale.x;
        y = transform.localScale.y;
        //z = transform.localScale.z;

        xN = x * 1.3f;
        yN = y * 1.3f;

        locked = false;
        
    }
    //esta se perdendo na hora de guarda posição inicial, com esse metodo aguarda definir para depois guardar.
    IEnumerator waith()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        initialPosition = transform.position;
    }

    void Update()
    {
        //if (Input.touchCount > 0 && !locked) //SEM SIMULADOR
        if (!locked)
        {
        //Debug.Log("Opaaa");
            
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
                    
                    if (Place!= null && (Mathf.Abs(transform.position.x - Place.position.x) <= 1.0f &&
                       Mathf.Abs(transform.position.y - Place.position.y) <= 1.0f))
                    {
                        transform.position = new Vector2(Place.position.x, Place.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        gameController.addRight();
                        gameController.playFx(fxLetra);
                        //place = null;
                    } else if (Place2 != null && (Mathf.Abs(transform.position.x - Place2.position.x) <= 1.0f &&
                       Mathf.Abs(transform.position.y - Place2.position.y) <= 1.0f))
                    {
                        transform.position = new Vector2(Place2.position.x, Place2.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        gameController.addRight();
                        gameController.playFx(fxLetra);
                        //place2 = null;
                    }
                    else
                    {
                        //Debug.Log(initialPosition.x + "-" + initialPosition.y);
                        if (initialPosition.x != transform.position.x)
                        {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                            
                            gameController.addError();
                        }
                    }
                    break;

            }
        } else //adicionado para sempre mater a posição inicial atualizada. 
        {
            initialPosition = transform.position;
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

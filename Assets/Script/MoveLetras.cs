using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLetras : MonoBehaviour
{
    public GameObject letraPlace;
    public string letraMove;
    public AudioClip fxLetra;
    [SerializeField]
    public Vector2 initialPosition;
    private IEnumerator coroutine;
    public GameControllerBase gameController;
    private float deltaX, deltaY;
    public string tipoDinamico;

    public bool locked;
    public static bool estaArrastando;


    //efeito quando arrasta pega aumenta.
    float x;
    float y;
    //float z;
    float xN;
    float yN;


    void Start()
    {

        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        coroutine = waith();
        StartCoroutine("waith");
        x = transform.localScale.x;
        y = transform.localScale.y;
        //z = transform.localScale.z;

        xN = x * 2f;
        yN = y * 2f;

        locked = false;
        estaArrastando = false;
        
    }
    //esta se perdendo na hora de guarda posição inicial, com esse metodo aguarda definir para depois guardar.
    IEnumerator waith()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        initialPosition = transform.position;
    }
    IEnumerator waith2S()
    {
        yield return new WaitForSecondsRealtime(2f);
        estaArrastando = false;
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
                this.GetComponent<SpriteRenderer>().sortingOrder = 11;
            } else
            {
                this.GetComponent<Renderer>().sortingOrder = 10;
                transform.localScale = new Vector2(x, y);
            } 
            //Touch touch = Input.GetTouch(0);//simulatess();//Input.GetTouch(0); SEM SIMULADOR
            Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(!estaArrastando) {
                        //StartCoroutine("waith2S");
                        estaArrastando = true;
                        //print("COMEÇO ESTATA ARRASTANDO O "+ letraMove);
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            //Debug.Log(slider);
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                

                    //print("COMEÇO ESTATA ARRASTANDO O "+ letraMove);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    } 
                    break;

                case TouchPhase.Ended:
                    estaArrastando = false;
                    if (letraPlace !=null && (Mathf.Abs(transform.position.x - letraPlace.transform.position.x) <= 2.0f &&
                       Mathf.Abs(transform.position.y - letraPlace.transform.position.y) <= 2.0f))
                    {
                        transform.position = new Vector2(letraPlace.transform.position.x, letraPlace.transform.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        letraPlace.SetActive(false);
                        this.GetComponent<Renderer>().sortingOrder = 10;
                        this.GetComponent<BoxCollider2D>().enabled =false;
                        gameController.addRight();
                        //gameController.playFx(fxLetra);
                        print("DESATIVAR O PLACE "+ letraMove);
                    } else if (letraPlace != null && (Mathf.Abs(transform.position.x - letraPlace.transform.position.x) <= 2.0f &&
                       Mathf.Abs(transform.position.y - letraPlace.transform.position.y) <= 2.0f))
                    {
                        transform.position = new Vector2(letraPlace.transform.position.x, letraPlace.transform.position.y);
                        locked = true;
                        transform.localScale = new Vector2(x, y);
                        letraPlace.SetActive(false);
                        this.GetComponent<Renderer>().sortingOrder = 10;
                        this.GetComponent<BoxCollider2D>().enabled =false;
                        gameController.addRight();
                        //gameController.playFx(fxLetra);
                    }
                    else
                    {
                        //Debug.Log(initialPosition.x + "-" + initialPosition.y);
                        if (initialPosition.x != transform.position.x)
                        {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                            
                            //gameController.addError();
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
    void OnTriggerEnter2D(Collider2D collision2d) {
        Debug.Log(collision2d.gameObject.tag);
        switch (collision2d.gameObject.tag)
        {
            case "Place":
            Debug.Log(collision2d.gameObject.GetComponent<Place>().letraPace);
                if(collision2d.gameObject.GetComponent<Place>().letraPace == letraMove ){
                    letraPlace = collision2d.gameObject;
                }
                //collision2d.gameObject.SendMessage("removeInteracao", SendMessageOptions.DontRequireReceiver);
                break;
            default:
            {
                break;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D collision2d) {
        Debug.Log(collision2d.gameObject.tag);
         switch (collision2d.gameObject.tag)
        {
            case "Place":
                if(collision2d.gameObject.GetComponent<Place>().letraPace == letraMove ){
                    letraPlace = null;
                }
                //collision2d.gameObject.SendMessage("removeInteracao", SendMessageOptions.DontRequireReceiver);
                break;
            default:
            {
                break;
            }
            
        }
    }
}

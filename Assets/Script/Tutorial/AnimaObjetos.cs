using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaObjetos : MonoBehaviour
{
    private IEnumerator coroutine;
    private Animator animator;
    public bool semClick;
    public bool escrever;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio "+ BancoPlayerprefs.instance.LerInformacoesInt(BancoPlayerprefs.CONST_TUTORIAL));
        if (BancoPlayerprefs.instance.LerInformacoesInt(BancoPlayerprefs.CONST_TUTORIAL) == 1)
        {
            Debug.Log("IF DENTRO");
            this.gameObject.SetActive(false);
            Debug.Log("FIM IF");
        }
        animator = GetComponent<Animator>();
        if (escrever)
        {
            //coroutine = waithMoveEnum();
            //StartCoroutine("waithMoveEnum");
            animator.SetBool("cimaBaxo", true);
            Debug.Log("FIM START");
        } else if(semClick) 
        {
            animator.SetBool("arrasta", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        touchPlay();
    }

    private void touchPlay()
    {
        //Touch touch = Input.GetTouch(0);//simulatess();//Input.GetTouch(0); SEM SIMULADOR
        Touch touch = simulatess();//Input.GetTouch(0); SEM SIMULADOR

        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    Debug.Log("TOCO NO PORCO");
                    this.gameObject.SetActive(false);
                }
                break;
            case TouchPhase.Ended:
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    desativar();
                }
                break;
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
   
    IEnumerator waithMoveEnum()
    {
        Debug.Log("Setando mão False");
        this.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(3f);
        Debug.Log("Setando mão TRUE");
        this.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
    }
    public void desativar()
    {
        if (escrever)
        {
            BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.CONST_TUTORIAL, 1);
            this.gameObject.SetActive(false);
        } else
        {
            if (animator.GetBool("arrasta"))
            {
                BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.CONST_TUTORIAL, 1);
                this.gameObject.SetActive(false);
            }
            animator.SetBool("arrasta", true);
        }
    }
}

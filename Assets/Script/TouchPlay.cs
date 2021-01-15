using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlay : MonoBehaviour
{
    private AudioController audioController;
    private GameController gameController;
    public bool playinicial;
    public float xSize;
    public float ySize;
    public float tempoInciarPalavra;
    private IEnumerator coroutine;
    public AudioClip fxPalavra;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        if (playinicial)
        {
            //coroutine = playAudioEnumSon();
            //StartCoroutine("playAudioEnumSon");
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
                   
                }
                break;

            case TouchPhase.Moved:
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    if (gameController != null)
                    {

                        if (gameController.lockKK == 0)
                        {
                            gameController.lockKK = 11;
                        }
                        else if (gameController.lockKK == 11)
                        {
                            this.GetComponent<SpriteRenderer>().sortingOrder = 7;
                        }
                        else
                        {
                            gameController.resizeColiderMin(this.GetComponent<BoxCollider2D>());
                        }
                    }
                }
                break;

            case TouchPhase.Ended:
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {

                    audioController.playFx(fxPalavra, 1);

                }
                if (gameController != null)
                {
                    gameController.lockKK = 0;
                    gameController.resizeColiderMaxPalavra(this.GetComponent<BoxCollider2D>(), this.GetComponent<SpriteRenderer>(), xSize, ySize);
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

    IEnumerator playAudioEnum()
    {
        yield return new WaitForSecondsRealtime(tempoInciarPalavra);
        audioController.playFx(audioController.fxFrase, 1);
    }
    IEnumerator playAudioEnumSon()
    {
        yield return new WaitForSecondsRealtime(tempoInciarPalavra);
        audioController.playFx(fxPalavra, 1);
    }

}

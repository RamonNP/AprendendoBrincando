using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GCEscreverDinamicoObjetos : GameControllerBase
{
    public String cena;
    //public bool proximaFaseLetras;
    public Transform place1;
    public Transform place2;
    public Transform place3;
    public Transform place4;
    public Transform place5;
    public Transform place6;
    public string[] palavras = new String[3];
    public AudioClip[] audioItem= new AudioClip[3];
    private bool travaError = false;
    public override int lockKK { get; set; }
    public Sprite letraA;
    public Sprite letraB;
    public Sprite letraC;
    public Sprite letraD;
    public Sprite letraE;
    public Sprite letraF;
    public Sprite letraG;
    public Sprite letraH;
    public Sprite letraI;
    public Sprite letraJ;
    public Sprite letraK;
    public Sprite letraL;
    public Sprite letraM;
    public Sprite letraN;
    public Sprite letraO;
    public Sprite letraP;
    public Sprite letraQ;
    public Sprite letraR;
    public Sprite letraS;
    public Sprite letraT;
    public Sprite letraU;
    public Sprite letraV;
    public Sprite letraX;
    public Sprite letraW;
    public Sprite letraY;
    public Sprite letraZ;



    public Sprite[] spriteItem = new Sprite[3];

    [Header("OBJETOS")]
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    private string palavra;
    [Header("PALAVRAS")]
    public GameObject ok1;
    public GameObject ok2;
    public GameObject ok3;
    public GameObject ok4;
    public GameObject ok5;
    public GameObject ok6;
    public GameObject fundo1;
    public GameObject fundo2;
    public GameObject fundo3;
    public GameObject fundo4;
    public GameObject fundo5;
    public GameObject fundo6;
    private int posicao = 1;
    private AudioController audioController;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    public static int faseAtual;
    public int right;
    public int error;
    public int pontos;
    public GameObject hudGameOver;
    private float x1;
    private float x2;
    private float x3;

    public MODinamicoEscrever m1;
    public MODinamicoEscrever m2;
    public MODinamicoEscrever m3;
    public MODinamicoEscrever m4;
    public MODinamicoEscrever m5;
    public MODinamicoEscrever m6;

    void Start()
    {
        //AdmobManager.instance.RequestBanner();
        RewardedAdsScript.getInstance().ShowBanner();
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        audioController.fxFrase = audioItem[faseAtual];
        palavra = palavras[faseAtual];
        tamanhoPalavra();
        montarPalavra();
        obj3.GetComponent<SpriteRenderer>().sprite = spriteItem[faseAtual];
        atualizarPontos(false);
    }
   
    // Update is called once per frame
    void Update()
    {
    }
    public void reiniciarPosicao()
    {
        ok2.transform.position = new Vector2(place2.position.x, place2.position.y);
    }
    public void playPalavra()
    {
        audioController.playPalavra();
    }
    public void proximaFase()
    {
        SceneManager.LoadScene(cena);

        //reiniciarPosicao();
        travaError = true;
        //posicaoAleatoria(new Random().Next(0, 3));
        posicao = 1;
        faseAtual++;
        faseAtual = faseAtual % palavras.Length;
        palavra = palavras[faseAtual];
        //voltarIncialPalavras();
        //Debug.Log(palavra);
        reiniciarParametros();
        audioController.fxFrase = audioItem[faseAtual];
        tamanhoPalavra();
        montarPalavra();
        playPalavra();
        hudGameOver.SetActive(false);
        obj3.GetComponent<SpriteRenderer>().sprite = spriteItem[faseAtual];
        StartCoroutine("waith");
        RewardedAdsScript.getInstance().RegraInterstitial();
    }
    IEnumerator waith()
    {
        yield return new WaitForSecondsRealtime(1f);
        MoveObjectDinamico.locked = false;
        travaError = false;
    }
    private void reiniciarParametros()
    {
        ok1.SetActive(true);
        fundo1.SetActive(true);
        ok2.SetActive(true);
        fundo2.SetActive(true);
        ok3.SetActive(true);
        fundo3.SetActive(true);
        ok4.SetActive(true);
        fundo4.SetActive(true);
        ok5.SetActive(true);
        fundo5.SetActive(true);
        ok6.SetActive(true);
        fundo6.SetActive(true);

    }
    public override void playFx(AudioClip fxAudio)
    {
        audioController.playFx(fxAudio, 1);
    }
   
    private void tamanhoPalavra()
    {
        int qtd = palavra.Length;
        switch (qtd)

        {
            case 3:
                posicao = 3;
                ok1.SetActive(false);
                fundo1.SetActive(false);
                ok2.SetActive(false);
                fundo2.SetActive(false);
                ok6.SetActive(false);
                fundo6.SetActive(false);
                mudarDestino(3);
                break;
            case 4:
                posicao = 2;
                ok1.SetActive(false);
                fundo1.SetActive(false);
                ok6.SetActive(false);
                fundo6.SetActive(false);
                mudarDestino(4);
                break;
            case 5:
                ok6.SetActive(false);
                fundo6.SetActive(false);
                mudarDestino(5);
                break;
            case 6:
                mudarDestino(6);
                break;
            case 7:
                break;
            case 8:
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    private void mudarDestino(int script)
    {
        if (script == 4)
        {
            m2.xDest = -1.17f;
            m3.xDest = -3.18f;
            m4.xDest = 3.12f;
            m5.xDest = 1.02f;
        }
        else if (script == 3)
        {
            m4.xDest = -1.17f;
            //m3.xDest = -3.18f;
            m3.xDest = 3.12f;
            m5.xDest = 1.02f;
        }
        else if (script == 5)
        {
            m1.xDest = -3.18f;
            m2.xDest = -1.18f;
            m3.xDest = -5.18f;
            m4.xDest = 2.80f;
            m5.xDest = 0.80f;
        }
        else if (script == 6)
        {
            m1.xDest = -3.18f;
            m2.xDest = 4.5f;
            m3.xDest = -5.18f;
            m4.xDest = 2.80f;
            m5.xDest = 0.80f;
            m6.xDest = -1.18f;
        }
    }

    public GameObject getOk(char c)
    {
        //Debug.Log(posicao);
        if(posicao == 1)
        {
            ok1.GetComponentInChildren<MODinamicoEscrever>().place = place1;
            posicao++;
            c1 = c;
            return ok1;
        } else if(posicao == 2) {
            ok2.GetComponentInChildren<MODinamicoEscrever>().place = place2;
            posicao++;
            c2 = c;
            return ok2;
        } else if(posicao == 3) {
            ok3.GetComponentInChildren<MODinamicoEscrever>().place = place3;
            posicao++;
            c3 = c;
            return ok3;
        } else if(posicao == 4) {
            ok4.GetComponentInChildren<MODinamicoEscrever>().place = place4;
            posicao++;
            c4 = c;
            return ok4;
        } else if(posicao == 5) {
            ok5.GetComponentInChildren<MODinamicoEscrever>().place = place5;
            posicao++;
            c5 = c;
            return ok5;
        } else if(posicao == 6) {
            c6 = c;
            ok6.GetComponentInChildren<MODinamicoEscrever>().place = place6;
            posicao++;
            return ok6;
        }
        return null;

    }
    char c1;
    char c2;
    char c3;
    char c4;
    char c5;
    char c6;

    private void repeteCaracter(char c, GameObject ok)
    {
        if (c1.Equals(c))
        {
            ok1.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok1.GetComponentInChildren<MODinamicoEscrever>().place;
        } else if(c2.Equals(c))
        {
            ok2.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok2.GetComponentInChildren<MODinamicoEscrever>().place;
        } else if(c3.Equals(c))
        {
            ok3.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok3.GetComponentInChildren<MODinamicoEscrever>().place;
        } else if(c4.Equals(c))
        {
            ok4.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok4.GetComponentInChildren<MODinamicoEscrever>().place;
        } else if(c5.Equals(c))
        {
            ok5.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok5.GetComponentInChildren<MODinamicoEscrever>().place;
        } else if(c6.Equals(c))
        {
            ok6.GetComponentInChildren<MODinamicoEscrever>().place2 = ok.GetComponentInChildren<MODinamicoEscrever>().place;
            ok.GetComponentInChildren<MODinamicoEscrever>().place2 = ok6.GetComponentInChildren<MODinamicoEscrever>().place;
        } 
    }
    private void montarPalavra()
    {
        GameObject ok = null;
        foreach (char c in palavra)
        {
                
            switch (c)

            {
                case 'A':
                    //Debug.Log(c);
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraA;
                    break;
                case 'B':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraB;
                    break;
                case 'C':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraC;
                    break;
                case 'D':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraD;
                    break;
                case 'E':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraE;
                    break;
                case 'F':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraF;
                    break;
                case 'G':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraG;
                    break;
                case 'H':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraH;
                    break;
                case 'I':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraI;
                    break;
                case 'J':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraJ;
                    break;
                case 'K':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraK;
                    break;
                case 'L':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraL;
                    break;
                case 'M':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraM;
                    break;
                case 'N':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraN;
                    break;
                case 'O':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraO;
                    break;
                case 'P':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraP;
                    break;
                case 'Q':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraQ;
                    break;
                case 'R':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraR;
                    break;
                case 'S':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraS;
                    break;
                case 'T':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraT;
                    break;
                case 'U':
                    //Debug.Log(c);
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraU;
                    break;
                case 'V':
                    //Debug.Log(c);
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraV;
                    break;
                case 'W':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraW;
                    break;
                case 'X':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraX;
                    break;
                case 'Y':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraY;
                    break;
                case 'Z':
                    ok = getOk(c);
                    ok.GetComponent<SpriteRenderer>().sprite = letraZ;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
            repeteCaracter(c, ok);
        }
    }
    public override void addRight()
    {
        right++;
        //gravarConquista(GooglePlayServiceConquistas.achievement_uma_linda_historia, palavra, );
        if (right >= palavra.Length)
        {
            atualizarPontos(true);
            atualizarConquistaPontos();
            audioController.playFx(audioController.fxClick, 1);
            victory();
            coroutine = playVictoryEnum();
            StartCoroutine("playVictoryEnum");
        }
        else
        {
            audioController.playFx(audioController.fxClick, 1);
        }

    }

    public override void addError()
    {
        if(!travaError)
        {
            CameraController.instance.shake();
            error++;
            audioController.playFx(audioController.fxError, 1);
        }
        
    }

    IEnumerator playVictoryEnum()
    {
        yield return new WaitForSecondsRealtime(1f);
        audioController.playFx(audioController.fxPalavra, 1);
        //yield return new WaitForSecondsRealtime(0.5f);
        audioController.playFx(audioController.fxVictory, 1);

    }
    public void victory()
    {
        hudGameOver.SetActive(true);
        //Debug.Log(" victory ");
        audioController.pauseMusic();
    }

    public override AudioClip GetAudioSelecionado()
    {
        throw new NotImplementedException();
    }
   

}

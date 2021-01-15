using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
//using GoogleMobileAds.Api;

public class GameControllerDinamicoObjetos : GameControllerBase
{
    //private InterstitialAd interstitial;
    public string[] palavras = new String[3];
    public AudioClip[] audioItem= new AudioClip[3];
    private bool travaError = false;

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
    public override int lockKK { get => lockKK; set => lockKK = value; }
    void Start()
    {
        //Debug.Log("INICIO CARREGANDO");
        //RequestInterstitial();
        //Debug.Log("FIM CARREGANDO");
        posicaoAleatoria(new Random().Next(0, 3));
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        audioController.fxFrase = audioItem[faseAtual];
        palavra = palavras[faseAtual];
        tamanhoPalavra();
        montarPalavra();
        montarObjeto();
        //AdmobManager.instance.RequestBanner();
        RewardedAdsScript.getInstance().ShowBanner();
        atualizarPontos(false);
    }
    public void posicaoAleatoria(int posicaoAnimais)
    {
        if (posicaoAnimais == 0)
        {
            x1 = 0;
            x2 = 4;
            x3 = -4;
        }
        else if (posicaoAnimais == 1)
        {
            x1 = 4;
            x2 = -4;
            x3 = 0;
        }
        else if (posicaoAnimais == 2)
        {
            x1 = -4;
            x2 = 0;
            x3 = 4;
        }

        obj1.transform.position = new Vector2(x3, -2.45f);
        obj2.transform.position = new Vector2(x2, -2.45f);
        obj3.transform.position = new Vector2(x1, -2.45f);
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void playPalavra()
    {audioController.playPalavra();
}
    public void proximaFase()
    {
        
        travaError = true;
        posicaoAleatoria(new Random().Next(0, 3));
        posicao = 1;
        faseAtual++;
        faseAtual = faseAtual % palavras.Length;
        palavra = palavras[faseAtual];
        //Debug.Log(palavra);
        reiniciarParametros();
        audioController.fxFrase = audioItem[faseAtual];
        tamanhoPalavra();
        montarPalavra();
        playPalavra();
        hudGameOver.SetActive(false);
        montarObjeto();
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
                //mudarDestino(3);
                break;
            case 4:
                posicao = 2;
                ok1.SetActive(false);
                fundo1.SetActive(false);
                ok6.SetActive(false);
                fundo6.SetActive(false);
                break;
            case 5:
                ok6.SetActive(false);
                fundo6.SetActive(false);
                break;
            case 6:
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

    public GameObject getOk()
    {
        if(posicao == 1)
        {
            posicao++;
            return ok1;
        } else if(posicao == 2) {
            posicao++;
            return ok2;
        } else if(posicao == 3) {
            posicao++;
            return ok3;
        } else if(posicao == 4) {
            posicao++;
            return ok4;
        } else if(posicao == 5) {
            posicao++;
            return ok5;
        } else if(posicao == 6) {
            posicao++;
            return ok6;
        }
        return null;

    }
    private void montarObjeto()
    {

        obj3.GetComponent<SpriteRenderer>().sprite = spriteItem[faseAtual];
        obj2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
        obj1.GetComponent<SpriteRenderer>().sprite = PopularSprite();

    }

    int animalSpriteAnt;
    public Sprite PopularSprite()
    {
        Sprite s1;
        int animalSprite = new Random().Next(0, spriteItem.Length);
        while (animalSprite == animalSpriteAnt || animalSprite == (faseAtual))
        {
            animalSprite = new Random().Next(0, spriteItem.Length);
        }

        //Debug.Log(animalSprite);
        s1 = spriteItem[animalSprite];
        
        animalSpriteAnt = animalSprite;
        return s1;
    }



    private void montarPalavra()
    {
        foreach (char c in palavra)
        {
            switch (c)

            {
                case 'A':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraA;
                    break;
                case 'B':
                    //Debug.Log(letraB);

                    getOk().GetComponent<SpriteRenderer>().sprite = letraB;
                    break;
                case 'C':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraC;
                    break;
                case 'D':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraD;
                    break;
                case 'E':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraE;
                    break;
                case 'F':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraF;
                    break;
                case 'G':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraG;
                    break;
                case 'H':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraH;
                    break;
                case 'I':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraI;
                    break;
                case 'J':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraJ;
                    break;
                case 'K':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraK;
                    break;
                case 'L':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraL;
                    break;
                case 'M':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraM;
                    break;
                case 'N':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraN;
                    break;
                case 'O':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraO;
                    break;
                case 'P':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraP;
                    break;
                case 'Q':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraQ;
                    break;
                case 'R':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraR;
                    break;
                case 'S':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraS;
                    break;
                case 'T':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraT;
                    break;
                case 'U':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraU;
                    break;
                case 'V':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraV;
                    break;
                case 'W':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraW;
                    break;
                case 'X':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraX;
                    break;
                case 'Y':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraY;
                    break;
                case 'Z':
                    getOk().GetComponent<SpriteRenderer>().sprite = letraZ;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
        }
    }
    public override void addRight()
    {
        right++;
        if (right >= pontos)
        {
            victory();
            atualizarPontos(true);
            atualizarConquistaPontos();
            coroutine = playVictoryEnum();
            StartCoroutine("playVictoryEnum");
        }
        else
        {
            // audioController.playFx(audioController.fx, 1);
        }
        //Debug.Log(" right" + right);
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
        yield return new WaitForSecondsRealtime(0f);
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
   //private void RequestInterstitial()
   //{
   //    string adUnitId = "ca-app-pub-3940256099942544/1033173712";
   //
   //
   //    // Initialize an InterstitialAd.
   //    this.interstitial = new InterstitialAd(adUnitId);
   //}
   //private void GameOver()
   //{
   //    if (this.interstitial.IsLoaded())
   //    {
   //        this.interstitial.Show();
   //    }
   //}
}

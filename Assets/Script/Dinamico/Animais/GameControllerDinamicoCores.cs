using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class GameControllerDinamicoCores : GameControllerBase
{
    public override int lockKK { get => lockKK; set => lockKK = value; }
    private float x1;
    private float x2;
    private float x3;

    public string[] palavras = new String[3];
    public AudioClip audioFase1;
    public AudioClip audioFase2;
    public AudioClip audioFase3;
    public AudioClip audioFase4;
    public AudioClip audioFase5;

    public AudioClip audioSelecionado;
    public AudioClip audioBranco;
    public AudioClip audioAmarelo;
    public AudioClip audioAzul;
    public AudioClip audioVerde;
    public AudioClip audioLaranja;
    public AudioClip audioPink;
    public AudioClip audioPreto;
    public AudioClip audioRocho;
    public AudioClip audioVermelho;
    public AudioClip audioLeao;
    public AudioClip audioLobo;
    public AudioClip audioMacaco;
    public AudioClip audioOvelha;
    public AudioClip audioPato;
    public AudioClip audioPomba;
    public AudioClip audioPorco;
    public AudioClip audioRato;
    public AudioClip audioSapo;
    public AudioClip audioVaca;
    public AudioClip audioAbelha;
    public AudioClip audioQ;
    public AudioClip audioR;
    public AudioClip audioS;
    public AudioClip audioT;
    public AudioClip audioU;
    public AudioClip audioV;
    public AudioClip audioX;
    public AudioClip audioY;
    public AudioClip audioZ;
    public AudioClip audioW;
   
   

    //public Sprite letraA;
    public Sprite branco;
    public Sprite azul;
    public Sprite amarelo;
    public Sprite verde;
    public Sprite laranja;
    public Sprite pink;
    public Sprite preto;
    public Sprite rocho;
    public Sprite vermelho;
    public Sprite leao;
    public Sprite lobo;
    public Sprite macaco;
    public Sprite ovelha;
    public Sprite pato;
    public Sprite pomba;
    public Sprite porco;
    public Sprite rato;
    public Sprite sapo;
    public Sprite vaca;
    public Sprite abelha;
    public Sprite letraV;
    public Sprite letraX;
    public Sprite letraW;
    public Sprite letraY;
    public Sprite letraZ;



    private string palavra;
    public GameObject ok1;
    public GameObject ok2;
    public GameObject ok3;
    public GameObject fundo1;
    public GameObject fundo2;
    public GameObject fundo3;
    public GameObject fundo4;
    public GameObject fundo5;
    public GameObject fundo6;
    private AudioController audioController;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    public static int faseAtual;
    public int right;
    public int error;
    public int pontos;
    public GameObject hudGameOver;
    void Start()
    {
        posicaoAleatoria(new Random().Next(0, 3));
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        if(faseAtual == 0)
        {
            audioController.fxFrase = audioFase1;
            palavra = palavras[0];
        } else if (faseAtual == 1)
        {
            audioController.fxFrase = audioFase2;
            palavra = palavras[1];
        } else if (faseAtual == 2)
        {
            audioController.fxFrase = audioFase3;
            palavra = palavras[2];
        }
        //tamanhoPalavra();
        montarPalavra();
        atualizarPontos(false);
        //AdmobManager.instance.RequestBanner();
        //RewardedAdsScript.getInstance().ShowBanner();
        AdmobManager.instance.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playPalavra()
    {
        audioController.playPalavra();
    }
    int animalSpriteAnt;
    public Sprite PopularSprite()
    {
        Sprite s1 ;
        int animalSprite = new Random().Next(0, palavras.Length);
        while(animalSprite == animalSpriteAnt || animalSprite == (faseAtual) || animalSpriteAnt == animalSprite)
        {
            animalSprite = new Random().Next(0, palavras.Length);
        }
        //Debug.Log(" animalSpriteAnt " + animalSpriteAnt + " faseAtual " + faseAtual + " animalSprite " + animalSprite);
        switch (animalSprite)
        {
            case 0:
                s1 = branco;
                break;
            case 1:
                s1 = amarelo;
                break;
            case 2:
                s1 = azul;
                break;
            case 3:
                s1 = verde;
                break;
            case 4:
                s1 = laranja;
                break;
            case 5:
                s1 = pink;
                break;
            case 6:
                s1 = preto;
                break;
            case 7:
                s1 = rocho;
                break;
            case 8:
                s1 = vermelho;
                break;
            case 9:
                s1 = leao;
                break;
            case 10:
                s1 = lobo;
                break;
            case 11:
                s1 = macaco;
                break;
            case 12:
                s1 = ovelha;
                break;
            case 13:
                s1 = pato;
                break;
            case 14:
                s1 = pomba;
                break;
            case 15:
                s1 = porco;
                break;
            case 16:
                s1 = laranja;
                break;
            case 17:
                s1 = rato;
                break;
            case 18:
                s1 = sapo;
                break;
            case 19:
                s1 = vaca;
                break;

            default:
                s1 = abelha;
                break;
        }
        animalSpriteAnt = animalSprite;
        return s1;
        /*
        int num = new Random().Next(0, 3);
        if(num == 0)
        {
            ok2.GetComponent<SpriteRenderer>().sprite = s1;
            ok1.GetComponent<SpriteRenderer>().sprite = s2;
        } else if (num == 1)
        {
            ok1.GetComponent<SpriteRenderer>().sprite = s2;
            ok2.GetComponent<SpriteRenderer>().sprite = s3;
        }
        else if (num == 2)
        {
            ok1.GetComponent<SpriteRenderer>().sprite = s1;
            ok2.GetComponent<SpriteRenderer>().sprite = s3;
        }

    */
    }
    
    public void proximaFase()
    {
        MoveObjectDinamico.locked = true;
        posicaoAleatoria(new Random().Next(0, 3));
        faseAtual++;
        faseAtual = faseAtual % palavras.Length;
        palavra = palavras[faseAtual];
        //Debug.Log("faseAtual "+faseAtual + "palavra" + palavra);
        //reiniciarParametros();
        //escolherAudio(faseAtual);
        //tamanhoPalavra();
        montarPalavra();
        playPalavra();
        hudGameOver.SetActive(false);
        StartCoroutine("waith");
        //RewardedAdsScript.getInstance().RegraInterstitial();
        AdmobManager.instance.ShowInterstitial();
    }
    IEnumerator waith()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        MoveObjectDinamico.locked = false;
    }
    public void posicaoAleatoria(int posicaoAnimais)
    {
        if(posicaoAnimais == 0)
        {
            x1 = 0;
            x2 = 4;
            x3 = -4;
        } else if (posicaoAnimais == 1)
        {
            x1 = 4;
            x2 = -4;
            x3 = 0;
        } else if (posicaoAnimais == 2)
        {
            x1 = -4;
            x2 = 0;
            x3 = 4;
        }
        
        ok3.transform.position = new Vector2(x3, -2.45f);
        ok2.transform.position = new Vector2(x2, -2.45f);
        ok1.transform.position = new Vector2(x1, -2.45f);
    }

    public void Menu()
    {

        //audioController.changeMusic(audioController.musicTitle, "Menu2", true, slider);
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Reentry()
    {
        this.hudGameOver.SetActive(false);
        //audioController.changeMusic(audioController.musicFase1, "Fase_" + audioController.faseAtual, true, slider);
        SceneManager.LoadScene("cores_dinamico");
    }
    private void reiniciarParametros()
    {
        ok1.SetActive(true);
        fundo1.SetActive(true);
        ok2.SetActive(true);
        fundo2.SetActive(true);
        ok3.SetActive(true);
        fundo3.SetActive(true);

    }
    public override void playFx(AudioClip fxAudio)
    {
        audioController.playFx(fxAudio, 1);
    }
    private void escolherAudio(int faseAtual)
    {
        switch (faseAtual+1)
        {
            case 1:
                audioController.fxFrase = audioFase1;
                break;
            case 2:
                audioController.fxFrase = audioFase2;
                break;
            case 3:
                audioController.fxFrase = audioFase3;
                break;
            case 4:
                audioController.fxFrase = audioFase4;
                break;
            case 5:
                audioController.fxFrase = audioFase5;
                break;
            default:
                break;
        }
    }
   

   
    private void montarPalavra()
    {
        //Debug.Log(palavra);
        switch (palavra)
        {
            case "Branco":
                ok3.GetComponent<SpriteRenderer>().sprite = branco;
                //popularSprite(galo, girafa, gato);
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                //ok2.GetComponent<SpriteRenderer>().sprite = cavalo;
                //ok1.GetComponent<SpriteRenderer>().sprite = cavalo;

                audioSelecionado = audioBranco;
                break;
            case "Verde":
                ok3.GetComponent<SpriteRenderer>().sprite = verde;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioVerde;
                break;
            case "Amarelo":
                ok3.GetComponent<SpriteRenderer>().sprite = amarelo;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioAmarelo;
                break;
            case "Azul":
                ok3.GetComponent<SpriteRenderer>().sprite = azul;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioAzul;
                break;
            case "Laranja":
                ok3.GetComponent<SpriteRenderer>().sprite = laranja;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioLaranja;
                break;
            case "Pink":
                ok3.GetComponent<SpriteRenderer>().sprite = pink;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioPink;
                break;
            case "Preto":
                ok3.GetComponent<SpriteRenderer>().sprite = preto;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioPreto;
                break;
            case "Rocho":
                ok3.GetComponent<SpriteRenderer>().sprite = rocho;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioRocho;
                break;
            case "Vermelho":
                ok3.GetComponent<SpriteRenderer>().sprite = vermelho;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioVermelho;
                break;
            case "Leao":
                ok3.GetComponent<SpriteRenderer>().sprite = leao;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioLeao;
                break;
            case "Lobo":
                ok3.GetComponent<SpriteRenderer>().sprite = lobo;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioLobo;
                break;
            case "Macaco":
                ok3.GetComponent<SpriteRenderer>().sprite = macaco;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioMacaco;
                break;
            case "Ovelha":
                ok3.GetComponent<SpriteRenderer>().sprite = ovelha;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioOvelha;
                break;
            case "Pato":
                ok3.GetComponent<SpriteRenderer>().sprite = pato;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioPato;
                break;
            case "Pomba":
                ok3.GetComponent<SpriteRenderer>().sprite = pomba;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioPomba;
                break;
            case "Porco":
                ok3.GetComponent<SpriteRenderer>().sprite = porco;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioPorco;
                break;
            case "Rato":
                ok3.GetComponent<SpriteRenderer>().sprite = rato;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioRato;
                break;
            case "Sapo":
                ok3.GetComponent<SpriteRenderer>().sprite = sapo;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioSapo;
                break;
            case "Vaca":
                ok3.GetComponent<SpriteRenderer>().sprite = vaca;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioVaca;
                break;
            case "Abelha":
                ok3.GetComponent<SpriteRenderer>().sprite = abelha;
                ok2.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                ok1.GetComponent<SpriteRenderer>().sprite = PopularSprite();
                audioSelecionado = audioAbelha;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
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
        CameraController.instance.shake();
        error++;
        audioController.playFx(audioController.fxError, 1);
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
        return audioSelecionado;
    }
}

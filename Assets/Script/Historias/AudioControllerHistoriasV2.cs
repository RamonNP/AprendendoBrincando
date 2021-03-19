using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControllerHistoriasV2 : MonoBehaviour
{
    
    [Header("Cenas")]
    public AudioClip[] cenasAudio = new AudioClip[3];
    public GameObject[] cenasImagens = new GameObject[3];
    public GameObject  cenasTitulo;

    private int faseAtual = 0;
    private AudioClip audioAutual;
    private GameObject imagemAutual;
    private GameObject TituloAutual;
    public AudioSource sFX;
    public float maxVol;
    public float minVol;
    // Start is called before the first frame update
    void Start()
    {
        playFx(cenasAudio[0], 4);
        AbrirBackground(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!sFX.isPlaying)
        {
            proximaCena();
        }
    }

    public void proximaCena()
    {
        //PlayServices.UnlockAnchievment(GooglePlayServiceConquistas.achievement_uma_linda_historia);
        faseAtual++;
        faseAtual = faseAtual % cenasAudio.Length;
        audioAutual = cenasAudio[faseAtual];
        playFx(audioAutual, 2);
        Debug.Log(faseAtual);
        AbrirBackground(faseAtual);
    }
    public void anteriorCena()
    {
        Debug.Log(faseAtual);
        faseAtual--;
        if (faseAtual <= 0)
        {
            faseAtual=0;
        }
        faseAtual = faseAtual % cenasAudio.Length;
        audioAutual = cenasAudio[faseAtual];
        playFx(audioAutual, 2);
        AbrirBackground(faseAtual);
    }
    public void playFx(AudioClip fx, float volume)
    {
        sFX.Stop();
        float tempVolume = volume;
        if (volume > maxVol)
        {
            tempVolume = maxVol;
        }
        sFX.volume = tempVolume;
        if (fx != null)
        {
            sFX.PlayOneShot(fx);
        }
    }
    public void AbrirBackground(int fase){
       for (int i = 0; i < cenasImagens.Length; i++)
       {
           if(fase == i){
                cenasImagens[i].SetActive(true);
           } else {
                cenasImagens[i].SetActive(false);
           }
       }
    }
    public void MenuFaseSelect() => SceneManager.LoadScene("MenuPrincipal");
}

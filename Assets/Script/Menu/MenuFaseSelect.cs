using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameController;

public class MenuFaseSelect : MonoBehaviour
{
    public static CATEGORIA cat;
    public TIPO TIPO;
    
    public Slider slider;
    private AudioController audioController;
    AsyncOperation async;

    public int maxFase;
    public int fase;
    public bool principal;
    //Fases
    public GameObject animalEscrever;
    public GameObject abjetosEscrever;
    public GameObject outrosEscrever;
    public GameObject sonsAnimaisDinamico;
    public GameObject coresDinamico;
    public GameObject outrosDinamico;
    public GameObject meninaDoLeite;
    public GameObject cruzadinha;


    private List<String> fases = new List<string>();

    void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.CONST_TUTORIAL, 0);
        if (!principal)
        {
            if (cat.Equals(CATEGORIA.DINAMICO))
            {
                sonsAnimaisDinamico.SetActive(true);
                coresDinamico.SetActive(true);

                animalEscrever.SetActive(false);
                abjetosEscrever.SetActive(false);
                meninaDoLeite.SetActive(false);
            } else if (cat.Equals(CATEGORIA.HISTORIAS))
            {
                meninaDoLeite.SetActive(true);

                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);

                animalEscrever.SetActive(false);
                abjetosEscrever.SetActive(false);
            } else if (cat.Equals(CATEGORIA.CRUZADINHA))
            {
                cruzadinha.SetActive(true);
                meninaDoLeite.SetActive(false);

                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);

                animalEscrever.SetActive(false);
                abjetosEscrever.SetActive(false);
            } else
            {
                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);
                meninaDoLeite.SetActive(false);

                animalEscrever.SetActive(true);
                abjetosEscrever.SetActive(true);
                outrosEscrever.SetActive(true);
            }

        }
        
    }
    public void GoToScene(string Scena)
    {
      audioController.changeMusic(audioController.musicFase1, Scena, true, slider);
    }

    IEnumerator LoadScreen(string scena)
    {
        
        if (async == null )
        {
            slider.gameObject.SetActive(true);
            async = SceneManager.LoadSceneAsync(scena);
            async.allowSceneActivation = false;
            while (async.isDone == false) {
                slider.value = async.progress;
                if (async.progress == 0.9f)
                {
                    slider.value = 1f;
                    async.allowSceneActivation = true;
                }
                yield return null;          
            }

        }
    }

    public void selectScene()
    {
        audioController.changeMusic(audioController.musicFase2, this.gameObject.name, true, slider);
    }
    public void selectMenu()
    {
        audioController.changeMusic(audioController.musicFase2, "Menu", true, slider);
    }
    public void clickSom()
    {
        audioController.playFx(audioController.fxClick, 1);
    }
    public void Reentry()
    {

        audioController.changeMusic(audioController.musicFase1, "MenuPrincipal", true, slider);
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void setCategoria(String categoria)
    {
        if(categoria.Equals("LER"))
        {
            cat = CATEGORIA.LER;
        } else if(categoria.Equals("ESCREVER"))
        {
            cat = CATEGORIA.ESCREVER;
        } else if(categoria.Equals("CONTAR"))
        {
            cat = CATEGORIA.CONTAR;
        } else if(categoria.Equals("DINAMICO"))
        {
            cat = CATEGORIA.DINAMICO;
        }else if(categoria.Equals("HISTORIAS"))
        {
            cat = CATEGORIA.HISTORIAS;
        }else if(categoria.Equals("CRUZADINHA"))
        {
            cat = CATEGORIA.CRUZADINHA;
        }
        audioController.changeMusic(audioController.musicFase1, "Menu2", true, slider);
    }
    public void setTipo(String fase)
    {

        if (cat.Equals(CATEGORIA.LER))
        {
        //Debug.Log(cat);
            audioController.changeMusic(audioController.musicFase1, "Ler"+fase, true, slider);
        }
        if (cat.Equals(CATEGORIA.ESCREVER))
        {
        //Debug.Log(cat);
            audioController.changeMusic(audioController.musicFase1, "Escrever" + fase, true, slider);
        }
        if (cat.Equals(CATEGORIA.CRUZADINHA))
        {
        //Debug.Log(cat);
            audioController.changeMusic(audioController.musicFase1, fase, true, slider);
        }
    }

    public void ShowAchievmentsUi()
    {
        //Debug.Log("TesteMenu");
        //PlayServices.ShowAchievments();
    }

    public void mostrarRanking()
    {
        //PlayServices.ShowLeaderboard(GooglePlayServiceConquistas.leaderboard_ranking_principal);
    }
}

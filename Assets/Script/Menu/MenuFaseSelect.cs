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
    public GameObject LeopardoJaboti;
    public GameObject VisitaDaVovo;
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
                LeopardoJaboti.SetActive(false);
                VisitaDaVovo.SetActive(false);
            } else if (cat.Equals(CATEGORIA.HISTORIAS))
            {
                LeopardoJaboti.SetActive(true);
                VisitaDaVovo.SetActive(true);

                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);

                animalEscrever.SetActive(false);
                abjetosEscrever.SetActive(false);
            } else if (cat.Equals(CATEGORIA.CRUZADINHA))
            {
                cruzadinha.SetActive(true);
                LeopardoJaboti.SetActive(false);
                VisitaDaVovo.SetActive(false);

                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);

                animalEscrever.SetActive(false);
                abjetosEscrever.SetActive(false);
            } else
            {
                sonsAnimaisDinamico.SetActive(false);
                coresDinamico.SetActive(false);
                LeopardoJaboti.SetActive(false);
                VisitaDaVovo.SetActive(false);

                animalEscrever.SetActive(true);
                abjetosEscrever.SetActive(true);
                outrosEscrever.SetActive(true);
            }

        }
        
    }
    public void GoToScene(string Scena)
    {
        if(Scena == "Historias1"){
            BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.HISTORIA_ATUAL, 0);
            audioController.changeMusic(audioController.musicFase1, "Historias", true, slider);
        } else if(Scena == "Historias2"){
            BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.HISTORIA_ATUAL, 1);
            audioController.changeMusic(audioController.musicFase1, "Historias", true, slider);
        } else if(Scena == "cores_dinamico"){
            //grana a fase para ser usada na proxima fase
            BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_CORES);
            //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
            BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_CORES);
            audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);

        } else if(Scena == "Fase_Sons"){
            //grana a fase para ser usada na proxima fase
            BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_SONS);
            //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
            BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_SONS);
            audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
        } else {
            audioController.changeMusic(audioController.musicFase1, Scena, true, slider);
        }
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
        //metodo duplicado com GoToScene
        public void setTipo(String fase)
    {

        if (cat.Equals(CATEGORIA.LER))
        {
        //Debug.Log(cat);
            //audioController.changeMusic(audioController.musicFase1, "Ler"+fase, true, slider);
            if("Ler"+fase == BancoPlayerprefs.ABRIR_LER_FRUTAS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_LER_FRUTAS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_LER_FRUTAS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            } else if("Ler"+fase == BancoPlayerprefs.ABRIR_LER_ANIMAIS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_LER_ANIMAIS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_LER_ANIMAIS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            } else if("Ler"+fase == BancoPlayerprefs.ABRIR_LER_OBJETOS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_LER_OBJETOS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_LER_OBJETOS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            }
        }
        if (cat.Equals(CATEGORIA.ESCREVER))
        {   
            if("Escrever"+fase == BancoPlayerprefs.ABRIR_ESCREVER_FRUTAS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_ESCREVER_FRUTAS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_ESCREVER_FRUTAS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            } else if("Escrever"+fase == BancoPlayerprefs.ABRIR_ESCREVER_ANIMAIS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_ESCREVER_ANIMAIS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_ESCREVER_ANIMAIS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            } else if("Escrever"+fase == BancoPlayerprefs.ABRIR_ESCREVER_OBJETOS) {
                //grana a fase para ser usada na proxima fase
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL, BancoPlayerprefs.ABRIR_ESCREVER_OBJETOS);
                //grava A pagina para ser usada na procima fase, pagina1 1 ate 30
                BancoPlayerprefs.instance.GravarInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL, BancoPlayerprefs.PAGINA_ESCREVER_OBJETOS);
                audioController.changeMusic(audioController.musicFase1, BancoPlayerprefs.ABRIR_FASE_SELECT, true, slider);
            }
            //audioController.changeMusic(audioController.musicFase1, "Escrever" + fase, true, slider);
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

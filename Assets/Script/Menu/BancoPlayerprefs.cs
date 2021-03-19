using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPlayerprefs : MonoBehaviour
{
    public const string MENU_PAGINA_ATUAL = "MenuPaginaAtual";
    public const string MENU_FASE_ATUAL = "MenuFaseAtual";
    public const string ESTRELAS_FASES = "Estrelas Fases";
    public const string FASE_LER_FRUTAS = "FaseLerFrutas";
    public const string ABRIR_SONS = "Fase_Sons";
    public const string ABRIR_CORES = "cores_dinamico";
    public const string ABRIR_LER_FRUTAS = "Ler_dinamico_Frutas";
    public const string ABRIR_LER_ANIMAIS = "Ler_dinamico_Animais";
    public const string ABRIR_LER_OBJETOS = "Ler_dinamico_Objeto";
    public const string ABRIR_ESCREVER_FRUTAS = "Escrever_dinamico_Frutas";
    public const string ABRIR_ESCREVER_ANIMAIS = "Escrever_dinamico_Animais";
    public const string ABRIR_ESCREVER_OBJETOS = "Escrever_dinamico_Objeto";
    public const string PAGINA_LER_FRUTAS = "PaginaLerFrutas";
    public const string PAGINA_LER_ANIMAIS = "PaginaLerAnimais";
    public const string PAGINA_LER_OBJETOS = "PaginaLerObjeto";
    public const string PAGINA_ESCREVER_FRUTAS = "PaginaEscreverFrutas";
    public const string PAGINA_ESCREVER_ANIMAIS = "PaginaEscreverAnimais";
    public const string PAGINA_ESCREVER_OBJETOS = "PaginaEscreverObjeto";
    public const string PAGINA_CORES = "PaginaCores";
    public const string PAGINA_SONS = "PaginaSons";
    public const string ABRIR_FASE_SELECT = "FaseSelect";
    public const string FASE_ATUAL = "FaseAtual";
    public const string PAGINA_LER = "PaginaLer";
    public const string CONST_PONTOS = "AB_PONTOS";
    public const string CONST_TUTORIAL = "AB_TUTORIAL";
    public const string HISTORIA_ATUAL = "HistoriaAtual";
    public int intPontos;

    public static BancoPlayerprefs instance;

    public static string CONST_TUTORIAL1 => CONST_TUTORIAL;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        intPontos = LerInformacoesInt(BancoPlayerprefs.CONST_PONTOS);
    }

    public int LerInformacoesInt(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        } else
        {
            return 0;
        }
    }

    public string LerInformacoesString(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            //Debug.Log(key+": "+ PlayerPrefs.GetString(key));
            return PlayerPrefs.GetString(key);
        }
        else
        {
            return null;
        }
    }

    public void GravarInformacoesInt(string key, int valor)
    {
        PlayerPrefs.SetInt(key, valor);
    }

    public void GravarInformacoesString(string key, string valor)
    {
        //Debug.Log(key+" : "+ valor);
        PlayerPrefs.SetString(key, valor);
    }

    internal void gravarPontos()
    {
        intPontos++;
        //Debug.Log("Gravando Pontos : "+ intPontos);
        GravarInformacoesInt(BancoPlayerprefs.CONST_PONTOS, intPontos);
    }
}

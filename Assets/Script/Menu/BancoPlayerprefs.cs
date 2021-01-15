using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPlayerprefs : MonoBehaviour
{
    public const string CONST_PONTOS = "AB_PONTOS";
    public const string CONST_TUTORIAL = "AB_TUTORIAL";
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
        PlayerPrefs.SetString(key, valor);
    }

    internal void gravarPontos()
    {
        intPontos++;
        Debug.Log("Gravando Pontos : "+ intPontos);
        GravarInformacoesInt(BancoPlayerprefs.CONST_PONTOS, intPontos);
    }
}

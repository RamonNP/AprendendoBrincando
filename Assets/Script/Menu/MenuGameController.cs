    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameController : MonoBehaviour
{


    public bool isPause = false;

    // Start is called before the first frame update
    public void FinishGame(int fase)
    {
        //AudioListener.volume = 0;
        
        fase++;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Fase_"+ fase, 1);
        isPause = false;
        SceneManager.LoadScene("Menu");
        //FinishCanvasGroup.interactable = true;
        //StartCoroutine(Fade(FinishCanvasGroup, 0f, 1f, 2f));
    }

    void Start()
    {
       

    }

    
}

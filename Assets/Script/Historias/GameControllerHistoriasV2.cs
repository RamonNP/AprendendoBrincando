using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerHistoriasV2 : MonoBehaviour
{
    AudioControllerHistoriasV2 audioControllerHistoriasV2;
    public List<GameObject> historias;
    void Start()
    {
        GameObject historiaAtual =  historias[BancoPlayerprefs.instance.LerInformacoesInt(BancoPlayerprefs.HISTORIA_ATUAL)];
        Instantiate (historiaAtual, new Vector3(0,0,1), this.gameObject.transform.rotation);
        audioControllerHistoriasV2 = FindObjectOfType(typeof(AudioControllerHistoriasV2)) as AudioControllerHistoriasV2;
        AdmobManager.instance.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProximaCena()
    {
        audioControllerHistoriasV2.proximaCena();
    }
    public void CenaAnterior()
    {
        audioControllerHistoriasV2.anteriorCena();
    }

    public void MenuFaseSelect() => SceneManager.LoadScene("MenuPrincipal");
}

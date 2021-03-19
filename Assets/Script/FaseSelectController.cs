using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseSelectController : MonoBehaviour
{
    public List<GameObject> paginas;
    public int paginaAtual;
    //private const string FASE_DAO = "Fase";
    private const string BTN_ABERTO = "BtnAberto";
    private const string BTN_ABERTO_1 = "BtnAbertto1";
    private const string BTN_ABERTO_2 = "BtnAbertto2";
    private const string BTN_ABERTO_3 = "BtnAbertto3";
    public List <GameObject> listaFases;
    public string menuFaseAtual;
    public string menuPaginaAtual;
    // Start is called before the first frame update
    void Start()
    {
        //carrega o menu atual baseado na escolha da tela anterior
        menuPaginaAtual = BancoPlayerprefs.instance.LerInformacoesString(BancoPlayerprefs.MENU_PAGINA_ATUAL);
        //Debug.Log("menuPaginaAtual"+menuPaginaAtual);
        //carrega a pagina baseada na escolha anterior
        menuFaseAtual = BancoPlayerprefs.instance.LerInformacoesString(BancoPlayerprefs.MENU_FASE_ATUAL);
        //Debug.Log("menuFaseAtual"+menuFaseAtual);
        //inicializa a pagina que esta no banco, depende da variavel pagina atual estar iniciada
        inicializaPagina();
        BancoPlayerprefs.instance.GravarInformacoesInt(menuFaseAtual+1,1);
        int indice = 1;
        //percorre as fases para abrir 
        foreach (var item in listaFases)
        {
            AbrirFase(item, indice);
            indice++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbrirFase(GameObject obj, int indice) {
        //verifica se a fase ja foi aberta: 1 aberto, 0 fechado
        int fase = BancoPlayerprefs.instance.LerInformacoesInt(menuFaseAtual+indice);
        //print(indice + " = "+fase);
        if(fase == 1){
            //abre a imagem com a quantidade de estrelas correspondentes
            int QtdEstrelas = BancoPlayerprefs.instance.LerInformacoesInt(BancoPlayerprefs.ESTRELAS_FASES+indice);
            for (int i = 0; i < obj.transform.childCount; i++){
                GameObject child = obj.transform.GetChild(i).gameObject;

                if(QtdEstrelas == 0){
                    if(child.name == BTN_ABERTO) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 1){
                    if(child.name == BTN_ABERTO_1) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 2){
                    if(child.name == BTN_ABERTO_2) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(QtdEstrelas == 3){
                    if(child.name == BTN_ABERTO_3) {
                        child.SetActive(true);
                    } else {
                        child.SetActive(false);
                    }
                }
                if(child.name == "Text") {
                    child.SetActive(true);
                }
                
            }
        }

    }

    public void btnAbrirFase(int fase) {
         //salva no formato para abrir a proxima fase
        BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.FASE_ATUAL,fase);
        SceneManager.LoadScene(menuFaseAtual);
    }

    private void inicializaPagina() {
        GameObject pagina = paginas[paginaAtual];
        foreach (var item in paginas)
        {
            item.SetActive(false);
        }
        pagina.SetActive(true);
    }
    public void proximaPagina(){
        if(paginaAtual < (paginas.Count-1)){
            paginaAtual +=1;
            BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.PAGINA_LER,paginaAtual);
            GameObject pagina = paginas[paginaAtual];
            foreach (var item in paginas)
            {
                item.SetActive(false);
            }
            pagina.SetActive(true);
        }
    }
    public void anteriorPagina(){
        if(paginaAtual > 0){
            paginaAtual -=1;
            BancoPlayerprefs.instance.GravarInformacoesInt(BancoPlayerprefs.PAGINA_LER,paginaAtual);
            GameObject pagina = paginas[paginaAtual];
            foreach (var item in paginas)
            {
                item.SetActive(false);
            }
            pagina.SetActive(true);
        }
    }
}

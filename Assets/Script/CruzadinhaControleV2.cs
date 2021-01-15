using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzadinhaControleV2 : MonoBehaviour
{
    private GameController gameController;
    public GameObject alfabeto;
    private LerXml xmlLerDados;
    private List<Objeto> objetos;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        //if(xmlLerDados !=null){
            //xmlLerDados.LoadDialogoData(gameController.idiomaFolder[gameController.idioma] + "/" + gameController.nomeArquivoXml); //ler o arquivo interação com itens;
        //}
        Debug.Log("INICIO CARREGANDO");
        xmlLerDados = LerXml.getInstance();
        Debug.Log("INSTANCIADO");
        objetos = xmlLerDados.LoadDialogoData("fases");
        Debug.Log("FIM CARREGANDO");
        preencherPlace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  preencherPlace() {
        gameController.pontos = 0;
        //variavel que guarda letras que sera apresentado na tela para usuario selecionar e montar palavras
        List<string> ListaLetrasControle = xmlLerDados.pularletrasControle;
        int y = 2;
        int x = -7;
        foreach (var item in objetos)
        {
            string palavra = item.nome;
            //calcula o destino do x do proximo quadrado
            float proximaCasa = float.Parse(item.pontos);
            foreach (var letra in palavra)
            {
                int inicio;
                int.TryParse(item.inicio, out inicio);
                //casas para pular linha, pois a coluna horizontal vai preencher,Definido no XML.
                if(!item.pular.Contains((proximaCasa.ToString()))) {
                    string  letraString = letra.ToString();
                //caso a palavra seja vertical tratamento especial para pular as casas
                    if(item.vertical == "S"){
                        GameObject place = Instantiate (GameObject.Find("O1l1"), new Vector3(inicio, proximaCasa, 0), this.transform.localRotation);
                        place.gameObject.GetComponent<Place>().letraPace = letraString.ToUpper();
                    //caso a palavra seja horizontal, apenas adiciona no lugar certo com a letra no place.
                    } else {
                        GameObject place = Instantiate (GameObject.Find("O1l1"), new Vector3(proximaCasa, inicio, 0), this.transform.localRotation);
                        place.gameObject.GetComponent<Place>().letraPace = letraString.ToUpper();
                    }
                    //adiciona pontos para ser comparado quando terminar a cruzadinha, pontosa x acertos
                    gameController.pontos++;
                    if(x == -7) {
                        x = -6;
                    } else if(x == -6){
                        x = -7;
                    } else if(x == -5){
                        x = 5;
                    } else if(x == 5){
                        x = -5;
                    } else if(x == 6){
                        x = 7;
                    } else if(x == 7){
                        x = 6;
                    }
                    y --;
                    if(y < -3) {
                        y = 2;
                        if(x == -7 || x == -6) {
                            x = -5;
                        } else  if(x == -5 || x == 4) {
                            x = 6;
                        }
                    }
                }
                 if(item.vertical == "S"){
                    proximaCasa--;
                 } else {
                    proximaCasa++;
                 }
            }
            
        }

        print(ListaLetrasControle.Count);
        switch (ListaLetrasControle.Count)
        {
            case 3:
                GameObject.Find("3Letras").SetActive(true);
                
                GameObject.Find("4Letras").SetActive(false);
                GameObject.Find("5Letras").SetActive(false);
               

            break;
            case 4:
                GameObject.Find("4Letras").SetActive(true);

                GameObject.Find("3Letras").SetActive(false);
                GameObject.Find("5Letras").SetActive(false);
            break;
            case 5:
                GameObject.Find("5Letras").SetActive(true);

                GameObject.Find("3Letras").SetActive(false);
                GameObject.Find("4Letras").SetActive(false);
            break;
        }
        int i = 1;

        foreach (string item in ListaLetrasControle)
        {
            print(item.ToUpper());
             switch(i)
             {
                case 1:
                    Transform pp1 = GameObject.Find("CL1").gameObject.transform;
                    GameObject letra1 =  Instantiate (GameObject.Find(item.ToUpper()));
                    letra1.gameObject.transform.localPosition = pp1.transform.position;
                    GameObject.Find("CL1").SetActive(false);
                break; 
                case 2:
                    Transform pp2 = GameObject.Find("CL2").gameObject.transform;
                    GameObject letra2 =  Instantiate (GameObject.Find(item.ToUpper()));
                    letra2.gameObject.transform.localPosition = pp2.transform.position;
                    GameObject.Find("CL2").SetActive(false);
                break; 
                case 3:
                    Transform pp3 = GameObject.Find("CL3").gameObject.transform;
                    GameObject letra3 =  Instantiate (GameObject.Find(item.ToUpper()));
                    letra3.gameObject.transform.localPosition = pp3.transform.position;
                    GameObject.Find("CL3").SetActive(false);
                break; 
                case 4:
                    Transform pp4 = GameObject.Find("CL4").gameObject.transform;
                    GameObject letra4 =  Instantiate (GameObject.Find(item.ToUpper()));
                    letra4.gameObject.transform.localPosition = pp4.transform.position;
                    GameObject.Find("CL4").SetActive(false);
                break; 
                case 5:
                    Transform pp5 = GameObject.Find("CL5").gameObject.transform;
                    GameObject letra5 =  Instantiate (GameObject.Find(item.ToUpper()));
                    letra5.gameObject.transform.localPosition = pp5.transform.position;
                    GameObject.Find("CL5").SetActive(false);
                break; 

             }
             i++;

        }
        alfabeto.SetActive(false);
    }
}

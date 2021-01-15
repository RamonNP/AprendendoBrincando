using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzadinhaControle : MonoBehaviour
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
                //casas para pular linha, pois a coluna horizontal vai preencher
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
                    GameObject prefabLetra = Instantiate (GameObject.Find(letraString.ToUpper()), new Vector3(float.Parse(x.ToString()), float.Parse(y.ToString()), 0), this.transform.localRotation);
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
        alfabeto.SetActive(false);
    }
}

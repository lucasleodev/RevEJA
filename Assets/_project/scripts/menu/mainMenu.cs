using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

    //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    //Logos do menu inicial
    public GameObject logoCreatura;
    public GameObject logoReveja;
    //Botoes do menu
    public GameObject botaoJogar;
    public GameObject botaoConfig;
    public GameObject botaoSair;
    //Botoes dos modos de jogo
    public GameObject btIntensivo;
    public GameObject btAmpulheta;
    public GameObject btNormal;
    //Botao para voltar ao menu anterior
    public GameObject btVoltar;
    //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

	// Use this for initialization
	public void Start () {
        //Exibe elementos iniciais da tela
        logoCreatura.SetActive(true);
        logoReveja.SetActive(true);
        botaoJogar.SetActive(true);
        botaoConfig.SetActive(true);
        botaoSair.SetActive(true);
        //Esconde modos de jogo e botao voltar
        btVoltar.SetActive(false);
        btAmpulheta.SetActive(false);
        btIntensivo.SetActive(false);
        btNormal.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Fecha o jogo
    public void Sair()
    {
        Application.Quit();
    }

    //Abre os modos de jogo, escondendo o menu anterior
    public void JogarInicial()
    {
        //Esconder elementos iniciais da tela
        logoCreatura.SetActive(false);
        logoReveja.SetActive(false);
        botaoJogar.SetActive(false);
        botaoConfig.SetActive(false);
        botaoSair.SetActive(false);
        //Exibe modos de jogo e botao voltar
        btVoltar.SetActive(true);
        btAmpulheta.SetActive(true);
        btIntensivo.SetActive(true);
        btNormal.SetActive(true);
    }

    //Abre as configurações de tela e som
    public void AbrirConfiguracoes()
    {

    }
}

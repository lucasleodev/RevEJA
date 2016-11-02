using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour {

    //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    //Logos do menu inicial
    public GameObject logoCreatura;
    public GameObject logoReveja;
    public GameObject textModosDeJogo;
    //Botoes do menu
    public GameObject botaoJogar;
    public GameObject botaoConfig;
    public GameObject botaoSair;
    //Botoes dos modos de jogo
    public GameObject btNiveis;
    public GameObject btAmpulheta;
    //Botao para voltar ao menu anterior
    public GameObject btVoltar;
    //Botao do modo de jogo ampulheta
    public GameObject btAmpulhetaIniciar;
    public GameObject textModoJogoAmpulheta;
    public GameObject textDescricaoAmpulheta;
    //Botao do modo de jogo niveis
    public GameObject textModoJogoNiveis;
    public GameObject textDescricaoNiveis;
    public GameObject btNivelBasico;
    public GameObject btNivelAvancado;  
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
        btNiveis.SetActive(false);
        textModosDeJogo.SetActive(false);
        btAmpulhetaIniciar.SetActive(false);
        textModoJogoAmpulheta.SetActive(false);
        textDescricaoAmpulheta.SetActive(false);
        textModoJogoNiveis.SetActive(false);
        btAmpulhetaIniciar.SetActive(false);
        textDescricaoNiveis.SetActive(false);
        btNivelBasico.SetActive(false);
        btNivelAvancado.SetActive(false);
        //UI de configurações
        

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
        btNiveis.SetActive(true);
        textModosDeJogo.SetActive(true);
    }

    //Abre as configurações de tela e som
    public void AbrirConfiguracoes()
    {
        SceneManager.LoadScene("config");
    }

    public void ModoAmpulheta()
    {
        btAmpulhetaIniciar.SetActive(true);
        btVoltar.SetActive(true);
        textModoJogoAmpulheta.SetActive(true);
        textDescricaoAmpulheta.SetActive(true);
        //Desliga o menu anterior, deixando só o botao Voltar
        btVoltar.SetActive(true);
        btAmpulheta.SetActive(false);
        btNiveis.SetActive(false);
        textModosDeJogo.SetActive(false);


    }

    public void ModoNiveis()
    {
        btVoltar.SetActive(true);
        textModoJogoNiveis.SetActive(true);
        textDescricaoNiveis.SetActive(true);
        btNivelBasico.SetActive(true);
        btNivelAvancado.SetActive(true);
        //Desliga o menu anterior, deixando só o botao Voltar       
        btAmpulheta.SetActive(false);
        btNiveis.SetActive(false);
        textModosDeJogo.SetActive(false);
    }

    public void ampulhetaStart()
    {
        SceneManager.LoadScene("jogo");
        logicaJogo.comecaJogo(0);
    }

    public void mathBasicStart()
    {
        SceneManager.LoadScene("jogo");
        logicaJogo.comecaJogo(1);
    }

    public void mathAvancStart()
    {
        SceneManager.LoadScene("jogo");
        logicaJogo.comecaJogo(2);
    }

    public void portBasicStart()
    {
        SceneManager.LoadScene("jogo");
        logicaJogo.comecaJogo(3);
    }

    public void portAvancStart()
    {
        SceneManager.LoadScene("jogo");
        logicaJogo.comecaJogo(4);
    }
}

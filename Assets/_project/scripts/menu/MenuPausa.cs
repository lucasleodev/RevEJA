using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //parar usar o método de desativar os botoes
    private corBotoes botoes;
    //UI do Menu de Pausa
    public GameObject bgTelaPausa;
    public GameObject btSair;
    public GameObject btContinuar;
    public GameObject btSairSim;
    public GameObject btSairNao;
    public Text labelPausa;

    void Start()
    {
        //instancia o corBotoes
        botoes = GetComponent<corBotoes>();
        //inicia o jogo com o menu escondido
        bgTelaPausa.SetActive(false);
        btSair.SetActive(false);
        btContinuar.SetActive(false);
        btSairSim.SetActive(false);
        btSairNao.SetActive(false);
        labelPausa.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0.0f;
            PausarJogo();
        }
    }

    //Quando ESC for pressionado    
    public void PausarJogo()
    {
        botoes.DesabilitarBotoes();        
        bgTelaPausa.SetActive(true);
        btSair.SetActive(true);
        btContinuar.SetActive(true);
        labelPausa.text = "Jogo Pausado";
    }

    public void CertezaSair()
    {
        labelPausa.text = "Deseja mesmo sair?";
        btSairSim.SetActive(true);
        btSairNao.SetActive(true);
        btSair.SetActive(false);
        btContinuar.SetActive(false);
    }

    public void SairJogo()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void NaoSairJogo()
    {
        bgTelaPausa.SetActive(false);
        btSair.SetActive(false);
        btContinuar.SetActive(false);
        btSairSim.SetActive(false);
        btSairNao.SetActive(false);
        labelPausa.text = "";
        botoes.HabilitarBotoes();
        Time.timeScale = 1.0f;
    }
}
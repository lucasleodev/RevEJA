using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public AudioClip somGO;
    public AudioClip sombotao;
    public AudioSource sourcebotao;
    public AudioSource audioSourceGO;

    public Text lbModoJogo;
    public Text lbAcertos;
    public Text lbErros;
    public Text lbMedia;   

    public double media = 0.0f;
    public int modo, totalQuestoes;

    logicaJogo loJogo;

    // Use this for initialization
    void Start () {
        SomGameOver();
        loJogo = GetComponent<logicaJogo>();
        DefinirModoJogo();
        DefinirEstatisticas();
        lbAcertos.text = "Você acertou "+ logicaJogo.qtdAcerto+" de "+ totalQuestoes;
        lbErros.text = "Você errou "+logicaJogo.qtdErro;
        lbMedia.text = "Sua média de acerto foi de " + media + "%";        
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void DefinirModoJogo()
    {
        modo = logicaJogo.modoJogo;
        switch (modo)
        {
            case 0:
                lbModoJogo.text = "Modo Ampulheta";
                totalQuestoes = 40;
                break;
            case 1:
                lbModoJogo.text = "Matemática - Nível Básico";
                totalQuestoes = 10;
                break;
            case 2:
                lbModoJogo.text = "Matemática - Nível Avançado";
                totalQuestoes = 10;
                break;
            case 3:
                lbModoJogo.text = "Português - Nível Básico";
                totalQuestoes = 10;
                break;
            case 4:
                lbModoJogo.text = "Português - Nível Avançado";
                totalQuestoes = 10;
                break;
            default:
                break;
        }

    }    
    public void DefinirEstatisticas()
    {
        if(modo==0)
        {
            media = (logicaJogo.qtdAcerto / 40.0f) * 100.0f;
        }
        else
        {
            media = (logicaJogo.qtdAcerto / 10.0f) * 100.0f;
        }
    }

    public void SairGameOver()
    {
        SceneManager.LoadScene("mainMenu");  
    }

    public void SomGameOver()
    {
        audioSourceGO.clip = somGO;
        audioSourceGO.Play();
    }

    public void SomButton()
    {
        sourcebotao.clip = sombotao;
        sourcebotao.Play();
    }
}

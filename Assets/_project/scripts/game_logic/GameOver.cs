using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text lbModoJogo;
    public Text lbAcertos;
    public Text lbErros;
    public Text lbEstatisticas;

    float media;
    int modoJogo;
    int acertos;
    int erros;

    logicaJogo loJogo;

    // Use this for initialization
    void Start () {
        modoJogo = logicaJogo.modoJogo;
        acertos = loJogo.acertos;
        erros = loJogo.erros;
        //
        loJogo = GetComponent<logicaJogo>();
        DefinirModoJogo();
        DefinirEstatisticas();
        lbAcertos.text = ("Você acertou " + acertos + " de 10");
        lbErros.text = ("Você errou " + erros);
        lbEstatisticas.text = ("Sua média de acertos foi de " + media + "%");
        
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void DefinirEstatisticas()
    {        
        if(modoJogo==0)
        {
            media = (acertos / 40)*100;
        }
        else
        {
            media = (acertos / 10)*100;
        }
    }

    public void DefinirModoJogo()
    {
        int mJogo = logicaJogo.modoJogo;
        switch (mJogo)
        {
            case 0:
                lbModoJogo.text = "Modo Ampulheta";
                break;
            case 1:
                lbModoJogo.text = "Matemática - Nível Básico";
                break;
            case 2:
                lbModoJogo.text = "Matemática - Nível Avançado";
                break;
            case 3:
                lbModoJogo.text = "Português - Nível Básico";
                break;
            case 4:
                lbModoJogo.text = "Português - Nível Avançado";
                break;
            default:
                break;
        }

    }

    public void SairGameOver()
    {
        SceneManager.LoadScene("mainMenu");  
    }
}

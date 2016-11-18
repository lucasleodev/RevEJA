using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text lbModoJogo;
    public Text lbAcertos;
    public Text lbErros;
    public Text lbEstatisticas;    

    logicaJogo loJogo;

    // Use this for initialization
    void Start () {
        loJogo = GetComponent<logicaJogo>();
        DefinirModoJogo();
        lbAcertos.text = ("Você acertou " + loJogo.acertos + " de 10");
        lbAcertos.text = ("Você errou " + loJogo.acertos);


    }

    // Update is called once per frame
    void Update () {
	
	}

    public void DefinirEstatisticas()
    {
        float media = loJogo.acertos / 10;
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

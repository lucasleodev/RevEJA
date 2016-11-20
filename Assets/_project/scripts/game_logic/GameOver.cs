using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public AudioClip somGO;
    public AudioSource audioSourceGO;

    public Text lbModoJogo;
    public Text lbAcertos;
    public Text lbErros;   

    public double media = 0.0f;
    public int modo;

    logicaJogo loJogo;

    // Use this for initialization
    void Start () {
        SomGameOver();
        loJogo = GetComponent<logicaJogo>();
        DefinirModoJogo();
       // DefinirEstatisticas();
        lbAcertos.text = "Você acertou "+ logicaJogo.qtdAcerto+" de 10";
        lbErros.text = "Você errou "+logicaJogo.qtdErro;        
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

    public void SomGameOver()
    {
        audioSourceGO.clip = somGO;
        audioSourceGO.Play();
    }
}

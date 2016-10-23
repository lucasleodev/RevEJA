using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configsGame : MonoBehaviour {

    public GameObject botaoVoltarMenu;
    public Toggle botaoTelaCheia;


	// Use this for initialization
	void Start () {

        //se o jogo iniciar em tela cheia, o toggle fica ativado, se não fica desativado
	if(Screen.fullScreen == true)
        {
            botaoTelaCheia.isOn = true;
        }
    else
        {
            botaoTelaCheia.isOn = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Resolucao()
    {

    }

    public void TelaCheia()
    {
        
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}

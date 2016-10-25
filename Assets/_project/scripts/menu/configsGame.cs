using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configsGame : MonoBehaviour {

    //o toggle da cena "Config"
   public Toggle botaoTelaCheia; 


    // Use this for initialization
    void Start() {

        //se a tela estiver fullscren, o toggle está marcado
        //senão, estará desmarcado
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

    public void AlterarResolucao()
    {       
                   
    }

    public void TelaCheia()
    {
        //se o toggle estiver marcado, o jogo fica em tela cheia,
        //senão, fica em modo janela
        if (botaoTelaCheia.isOn == true)
        {
            Screen.fullScreen = true;            
        }
        else
        {
            Screen.fullScreen = false;            
        }
    }

    public void VoltarAoMenu()
    {
        //volta para a cena "Menu principal"
        SceneManager.LoadScene("mainMenu");
    }
}

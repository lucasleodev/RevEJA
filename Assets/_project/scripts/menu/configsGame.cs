using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configsGame : MonoBehaviour {

    //o toggle da cena "Config"
   public Toggle botaoTelaCheia;
    //seleção de resolução
   public Dropdown selecaoResolucao;
    //temporário para armazenar a posição
   public static int posicaoResolucao;
    //salva a resolução máxima nativa do monitor
    public static int resolucaoNativaWidth, resolucaoNativaheight; 


    // Use this for initialization
    void Start() {


        //deixa o dropdown marcado
        //com a resolução atual
        selecaoResolucao.value = posicaoResolucao;

        resolucaoNativaWidth = Screen.currentResolution.width;
        resolucaoNativaheight = Screen.currentResolution.height;


        //se a tela estiver fullscren, o toggle está marcado
        //senão, estará desmarcado
     if (Screen.fullScreen == true)
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

    //identifica a resolução selecionada no menu Dropdown
    //e a seta, o campo botaoTelaCheia.isOn automaticamente
    //coloca a resolução junto com a tela cheia caso esteja ativada
    public void AlterarResolucao()
    {
        switch (selecaoResolucao.value)
        {
            case 0:
                Screen.SetResolution(320, 240, botaoTelaCheia.isOn);
                posicaoResolucao = 0;
                break;
            case 1:
                Screen.SetResolution(640, 480, botaoTelaCheia.isOn);
                posicaoResolucao = 1;
                break;
            case 2:
                Screen.SetResolution(800, 600, botaoTelaCheia.isOn);
                posicaoResolucao = 2;
                break;
            case 3:
                Screen.SetResolution(1280, 720, botaoTelaCheia.isOn);
                posicaoResolucao = 3;
                break;
            case 4:
                Screen.SetResolution(resolucaoNativaWidth, resolucaoNativaheight, botaoTelaCheia.isOn);
                posicaoResolucao = 4;
                break;
            default:                
                break;
        }
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

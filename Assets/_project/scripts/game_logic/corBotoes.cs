using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class corBotoes : MonoBehaviour {
    //para pegar as variaveis e funcoes do codigo logicaJogo.cs
    public logicaJogo logicJogo;
    //referencia os botões
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoD;

    //para exibir ou esconder a ampulhete dependendo do modo de jogo
    public GameObject corpoAmpuCima;
    public GameObject corpoAmpuBaixo;
    public GameObject areiaAmpuCima;
    public GameObject areiaAmpuBaixo;

    //referencia a cor a ser utilizada  
    public ColorBlock corRespostaCerta;
    public ColorBlock corRespostaErrada;
    public ColorBlock corNormal;

    //mostrtar a explicação da resposta
    public GameObject explicacaoResposta;
    

    //as cores dos botoes a serem alteradas
    public Color respCerta = new Color(0.2F, 0.3F, 0.4F);
    public Color respErrada = new Color(0.2F, 0.3F, 0.4F);
    public Color corPadrao = new Color(0.2F, 0.3F, 0.4F);

    //variaveis para tocar os sons de certo, errado
    public AudioSource audioSourceSonsBotao;
    public AudioClip somCerto;
    public AudioClip somErrado;

    //para uso no MenuPausa
    public bool corotinaLigada = false;


    public int tempoEspera = 5;

    // Use this for initialization
    void Start () {
        explicacaoResposta.SetActive(false);
        //cria a instancia de logicaJogo.cs
        logicJogo = GetComponent<logicaJogo>();
        //cor dos botoes no estado normal
        corNormal.normalColor = corPadrao;
        corRespostaCerta.normalColor = respCerta;
        corRespostaErrada.normalColor = respErrada;

        //cor quando clicados
        corNormal.pressedColor = corPadrao;
        corRespostaCerta.pressedColor = respCerta;
        corRespostaErrada.pressedColor = respErrada;

        AmpulhetaOnOuOff();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void iniciarCorBotoes()
    {
        botaoA.colors = corNormal;
        botaoB.colors = corNormal;
        botaoC.colors = corNormal;
        botaoD.colors = corNormal;
    }
    
    public void RespostaCorretaA()
    {
        botaoA.colors = corRespostaCerta;
        botaoB.colors = corRespostaErrada;
        botaoC.colors = corRespostaErrada;
        botaoD.colors = corRespostaErrada;        
    }

    public void RespostaCorretaB()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaCerta;
        botaoC.colors = corRespostaErrada;
        botaoD.colors = corRespostaErrada;       
    }

    public void RespostaCorretaC()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaErrada;
        botaoC.colors = corRespostaCerta;
        botaoD.colors = corRespostaErrada;        
    }

    public void RespostaCorretaD()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaErrada;
        botaoC.colors = corRespostaErrada;
        botaoD.colors = corRespostaCerta;        
    }

    public void MudancaCorBotoes(int opcaoEscolhida)
    {
        switch (opcaoEscolhida)
        {
            case 0:
                RespostaCorretaA();
                break;
            case 1:
                RespostaCorretaB();
                break;
            case 2:
                RespostaCorretaC();
                break;
            case 3:
                RespostaCorretaD();
                break;
            default:
                break;
        }
    }
    //Destrava os botões para o jogador poder voltar a jogar
    public void HabilitarBotoes()
    {
        botaoA.interactable = true;
        botaoB.interactable = true;
        botaoC.interactable = true;
        botaoD.interactable = true;
    }
    //Trava os botões para o jogador poder ler a explicação
    public void DesabilitarBotoes()
    {
        botaoA.interactable = false;
        botaoB.interactable = false;
        botaoC.interactable = false;
        botaoD.interactable = false;
    }
    //deixa ela ligada ou desligada
    public void AmpulhetaOnOuOff()
    {
        if(logicaJogo.modoJogo==0)
        {
            corpoAmpuCima.SetActive(true);
            corpoAmpuBaixo.SetActive(true);
            areiaAmpuCima.SetActive(true);
            areiaAmpuBaixo.SetActive(true);
        }
        else
        {
            corpoAmpuCima.SetActive(false);
            corpoAmpuBaixo.SetActive(false);
            areiaAmpuCima.SetActive(false);
            areiaAmpuBaixo.SetActive(false);
        }
    }

    public void SomCerto()
    {
        audioSourceSonsBotao.clip = somCerto;
        audioSourceSonsBotao.Play();
    }

    public void SomErrado()
    {
        audioSourceSonsBotao.clip = somErrado;
        audioSourceSonsBotao.Play();
    }
    //Chama a corotina para que o jogo "pare" para que o player leia a explicação
    public void AguardarTempoResposta()
    {
        StartCoroutine(PausaResposta());
    }

    //corotina para fazer o jogo esperar certo tempo para mostrar a resposta
    IEnumerator PausaResposta()
    {
        corotinaLigada = true;
        logicJogo.tempoPausado = true;
        explicacaoResposta.SetActive(true);
        DesabilitarBotoes();        
        yield return new WaitForSeconds(tempoEspera);
        logicJogo.ModoDeJogo();
        logicJogo.tempoPausado = false;
        explicacaoResposta.SetActive(false);
        HabilitarBotoes();
        corotinaLigada = false;
    }
}

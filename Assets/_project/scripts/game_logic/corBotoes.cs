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

    //referencia a cor a ser utilizada  
    public ColorBlock corRespostaCerta;
    public ColorBlock corRespostaErrada;
    public ColorBlock corNormal;  
    

    //as cores dos botoes a serem alteradas
    public Color respCerta = new Color(0.2F, 0.3F, 0.4F);
    public Color respErrada = new Color(0.2F, 0.3F, 0.4F);
    public Color corPadrao = new Color(0.2F, 0.3F, 0.4F);

    public int tempoEspera = 5;

    // Use this for initialization
    void Start () {
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
        PausaResposta();
    }

    public void RespostaCorretaB()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaCerta;
        botaoC.colors = corRespostaErrada;
        botaoD.colors = corRespostaErrada;
        PausaResposta();
    }

    public void RespostaCorretaC()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaErrada;
        botaoC.colors = corRespostaCerta;
        botaoD.colors = corRespostaErrada;
        PausaResposta();
    }

    public void RespostaCorretaD()
    {
        botaoA.colors = corRespostaErrada;
        botaoB.colors = corRespostaErrada;
        botaoC.colors = corRespostaErrada;
        botaoD.colors = corRespostaCerta;
        PausaResposta();
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
    //Chama a corotina para que o jogo "pare" para que o player leia a explicação
    public void AguardarTempoResposta()
    {
        StartCoroutine(PausaResposta());
    }

    //corotina para fazer o jogo esperar certo tempo para mostrar a resposta
    IEnumerator PausaResposta()
    {
        logicJogo.tempoPausado = true;
        DesabilitarBotoes();        
        yield return new WaitForSeconds(tempoEspera);
        logicJogo.ModoDeJogo();
        logicJogo.tempoPausado = false;
        HabilitarBotoes();        
    }
}

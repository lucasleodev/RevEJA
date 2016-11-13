using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class corBotoes : MonoBehaviour {

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

    public void AguardarTempoResposta()
    {

    }

    //corotina para fazer o jogo esperar certo tempo para mostrar a resposta
    IEnumerator PausaResposta()
    {
        yield return new WaitForSeconds(tempoEspera);
    }
}

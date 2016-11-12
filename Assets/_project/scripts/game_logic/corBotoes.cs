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

    public int valor = 5;

    // Use this for initialization
    void Start () {
        corNormal.normalColor = corPadrao;
        corRespostaCerta.normalColor = respCerta;
        corRespostaErrada.normalColor = respErrada;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void RespostaCorreta()
    {
        if (valor != 0)
        {
           botaoA.colors = corNormal;
        }
        
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class corBotoes : MonoBehaviour {

    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoD;

    public Color corNormal;
    public Color corRespostaCerta;
    public Color corRespostaErrada;

    public int valor = 5;   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void RespostaCorreta()
    {
        if (valor != 0)
        {
            ColorBlock temp = botaoA.colors;
            temp.normalColor = corNormal;
            botaoA.colors = temp;
        }
        
    }
}

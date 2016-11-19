using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hourglass : MonoBehaviour {
    //para as imagens da ampulheta
    public GameObject ampulhetaCima;
    public GameObject ampulhetaBaixo;
    public GameObject corpoAmpulhetaCima;
    public GameObject corpoAmpulhetaBaixo;
    // public GameObject ampulhetaCorpo;
    public Image ampulCima;
    public Image ampulBaixo;
    float qtdTempo;
    float timer;

    logicaJogo logicJogo;

    // Use this for initialization
    void Start () {
        CopiarValorTempo();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            ampulCima.fillAmount = timer / qtdTempo;
            ampulBaixo.fillAmount = 1-(timer / qtdTempo);
        }    
    }

    public void CopiarValorTempo()
    {
        //cria a instancia de logicaJogo.cs
        logicJogo = GetComponent<logicaJogo>();
        qtdTempo = logicJogo.tempo;
        timer = qtdTempo;

        if (logicaJogo.modoJogo == 0)
        {
            ampulhetaBaixo.SetActive(true);
            ampulhetaCima.SetActive(true);
            corpoAmpulhetaBaixo.SetActive(true);
            corpoAmpulhetaCima.SetActive(true);
        }
        else
        {
            ampulhetaBaixo.SetActive(false);
            ampulhetaCima.SetActive(false);
            corpoAmpulhetaBaixo.SetActive(false);
            corpoAmpulhetaCima.SetActive(false);
        }
    }
}

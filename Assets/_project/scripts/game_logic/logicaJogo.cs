﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicaJogo : MonoBehaviour {
    //cria um booleano pra pausar o timeDelta
    public bool tempoPausado = false;
    //cria a instância para usar os métodos da classe Corbotoes.cs
    private corBotoes cores;
    private Hourglass ampulheta;
    //-------------FIM DESSE TRECHO---------------------
    public string[] pMathBasic;
    public string[] eMathBasic;
    public string[,] rMathBasic;
    public string[] pPortBasic;
    public string[] ePortBasic;
    public string[,] rPortBasic;
    public string[] pMathAvanc;
    public string[] eMathAvanc;
    public string[,] rMathAvanc;
    public string[] pPortAvanc;
    public string[] ePortAvanc;
    public string[,] rPortAvanc;
    public int[] cMathBasic;
    public int[] cMathAvanc;
    public int[] cPortBasic;
    public int[] cPortAvanc;
    public bool[] pRespondidas;
    public bool[,] pRespondidasAmp;
    public static int modoJogo;
    //Ingame Variables
    public Text lbPergunta;
    public Text lbRespA;
    public Text lbRespB;
    public Text lbRespC;
    public Text lbRespD;
    public Text lbExp;
    public Text lbNv;
    public Text lbDisc;
    public float tempo;
    public int respostaUsuario;
    public int acertos;
    public int erros;
    public int quest, disc;
    //para receber a media
    public static float media;


    // Use this for initialization
    void Start() {
        //corrige um bug de setar o tempo em 0 após sair pelo pause
        Time.timeScale = 1.0f;
        //cria instância e deixa botões com a cor definida como default
        cores = GetComponent<corBotoes>();
        cores.iniciarCorBotoes();
        //----------FIM DO TRECHO DE INICIAR AS CORES--------------
        // Perguntas de Matemática Básica
        pMathBasic = new string[10] { "Quanto é 2+2?", "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
        // Respostas de Matemática Básica
        rMathBasic = new string[10, 4] { { "4", "2", "3", "1" }, { "r1a", "r1b", "r1c", "r1d" }, { "r2a", "r2b", "r2c", "r2d" }, { "r3a", "r3b", "r3c", "r3d" }, { "r4a", "r4b", "r4c", "r4d" }, { "r5a", "r5b", "r5c", "r5d" }, { "r6a", "r6b", "r6c", "r6d" }, { "r7a", "r7b", "r7c", "r7d" }, { "r8a", "r8b", "r8c", "r8d" }, { "r9a", "r9b", "r9c", "r9d" } };
        // Perguntas de Português Básico
        pPortBasic = new string[10] { "p0", "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
        // Respostas de Português Básico
        rPortBasic = new string[10, 4] { { "r0a", "r0b", "r0c", "r0d" }, { "r1a", "r1b", "r1c", "r1d" }, { "r2a", "r2b", "r2c", "r2d" }, { "r3a", "r3b", "r3c", "r3d" }, { "r4a", "r4b", "r4c", "r4d" }, { "r5a", "r5b", "r5c", "r5d" }, { "r6a", "r6b", "r6c", "r6d" }, { "r7a", "r7b", "r7c", "r7d" }, { "r8a", "r8b", "r8c", "r8d" }, { "r9a", "r9b", "r9c", "r9d" } };
        // Perguntas de Matemática Avançada
        pMathAvanc = new string[10] { "p0", "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
        // Respostas de Matemática Avançada
        rMathAvanc = new string[10, 4] { { "r0a", "r0b", "r0c", "r0d" }, { "r1a", "r1b", "r1c", "r1d" }, { "r2a", "r2b", "r2c", "r2d" }, { "r3a", "r3b", "r3c", "r3d" }, { "r4a", "r4b", "r4c", "r4d" }, { "r5a", "r5b", "r5c", "r5d" }, { "r6a", "r6b", "r6c", "r6d" }, { "r7a", "r7b", "r7c", "r7d" }, { "r8a", "r8b", "r8c", "r8d" }, { "r9a", "r9b", "r9c", "r9d" } };
        // Perguntas de Português Avançado
        pPortAvanc = new string[10] { "p0", "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
        // Respostas de Português Avançado
        rPortAvanc = new string[10, 4] { { "r0a", "r0b", "r0c", "r0d" }, { "r1a", "r1b", "r1c", "r1d" }, { "r2a", "r2b", "r2c", "r2d" }, { "r3a", "r3b", "r3c", "r3d" }, { "r4a", "r4b", "r4c", "r4d" }, { "r5a", "r5b", "r5c", "r5d" }, { "r6a", "r6b", "r6c", "r6d" }, { "r7a", "r7b", "r7c", "r7d" }, { "r8a", "r8b", "r8c", "r8d" }, { "r9a", "r9b", "r9c", "r9d" } };
        // Explicações de Matemática Básica
        eMathBasic = new string[10] { "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9" };
        // Explicações de Matemática Avançada
        eMathAvanc = new string[10] { "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9" };
        // Explicações de Português Básico
        ePortBasic = new string[10] { "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9" };
        // Explicações de Português Avançado
        ePortAvanc = new string[10] { "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9" };
        /* Respostas Corretas [A = 0, B = 1, C = 2, D = 3] */
        // Matemática Básica
        cMathBasic = new int[10] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1 };
        // Matemática Avançada
        cMathAvanc = new int[10] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1 };
        // Português Básico
        cPortBasic = new int[10] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1 };
        // Português Avançado
        cPortAvanc = new int[10] { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1 };
        // Colocar vetores e matrizes
        pRespondidasAmp = new bool[4, 10] { { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false } };
        pRespondidas = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        respostaUsuario = -1;
        acertos = 0;
        erros = 0;
        tempo = 180.0f;

        switch (modoJogo)
        {
            case 0: ampulMode(); break;
            case 1: mathBasic(); break;
            case 2: mathAvanc(); break;
            case 3: portBasic(); break;
            case 4: portAvanc(); break;
        }
    }

    // Update is called once per frame
    void Update() {
        if (modoJogo == 0 && tempo > 0)
        {
            //inicia cronometro
            CronometroModoAmpulheta();
        }
        else if(modoJogo == 0)
        {
            // GAME OVER]
            SceneManager.LoadScene("gameOver");
        }
    }

    public void ampulMode()
    {
        //iniciar com cor default
        cores.iniciarCorBotoes();
        //esconder outros labels da cena
        lbExp.text = "";
        lbNv.text = "";
       
        if(respostaUsuario == -1 && acertos+erros < 40)
        {
            quest = Random.Range(0, 9);
            disc = Random.Range(0, 3);

            for (int i = 0;i < 65535;i++)
            {
                if(pRespondidasAmp[disc, quest] == true)
                {
                    quest = Random.Range(0, 9);
                    disc = Random.Range(0, 3);
                }
            }

            if (disc == 0)
            {
                lbPergunta.text = pMathBasic[quest];
                lbRespA.text = rMathBasic[quest, 0];
                lbRespB.text = rMathBasic[quest, 1];
                lbRespC.text = rMathBasic[quest, 2];
                lbRespD.text = rMathBasic[quest, 3];
 
            }
            else if(disc == 1)
            {
                lbPergunta.text = pMathAvanc[quest];
                lbRespA.text = rMathAvanc[quest, 0];
                lbRespB.text = rMathAvanc[quest, 1];
                lbRespC.text = rMathAvanc[quest, 2];
                lbRespD.text = rMathAvanc[quest, 3];

            }
            else if(disc == 2)
            {
                lbPergunta.text = pPortBasic[quest];
                lbRespA.text = rPortBasic[quest, 0];
                lbRespB.text = rPortBasic[quest, 1];
                lbRespC.text = rPortBasic[quest, 2];
                lbRespD.text = rPortBasic[quest, 3];

            }
            else if(disc == 3)
            {
                lbPergunta.text = pPortAvanc[quest];
                lbRespA.text = rPortAvanc[quest, 0];
                lbRespB.text = rPortAvanc[quest, 1];
                lbRespC.text = rPortAvanc[quest, 2];
                lbRespD.text = rPortAvanc[quest, 3];

            }
        }
        else if(acertos+erros < 40)
        {
            if(disc == 0)
            {
                if(respostaUsuario == cMathBasic[quest])
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }
            }
            else if(disc == 1)
            {
                if (respostaUsuario == cMathAvanc[quest])
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }
            }
            else if (disc == 2)
            {
                if (respostaUsuario == cPortBasic[quest])
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }
            }
            else if(disc == 3)
            {
                if (respostaUsuario == cPortAvanc[quest])
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }
            }
            respostaUsuario = -1;
            pRespondidasAmp[disc, quest] = true;
            ampulMode();
        }
        else
        {
            //GAME OVER
            SceneManager.LoadScene("gameOver");
        }



        
    }

    public void mathBasic()
    {
        //iniciar com cor default
        cores.iniciarCorBotoes();
        //jogo em si
        lbNv.text = "Básico";
        lbDisc.text = "Matemática";
        quest = Random.Range(0, 9);

        if (respostaUsuario == -1 && acertos + erros < 10 && erros < 3)
        {

            for (int i = 0; i < 65535; i++)
            {
                if (pRespondidas[quest] == true)
                {
                    quest = Random.Range(0, 9);
                }
            }

            lbPergunta.text = pMathBasic[quest];
            lbRespA.text = rMathBasic[quest, 0];
            lbRespB.text = rMathBasic[quest, 1];
            lbRespC.text = rMathBasic[quest, 2];
            lbRespD.text = rMathBasic[quest, 3];
        }
        else if( acertos + erros < 10 && erros < 3)
        {
            if (respostaUsuario == cMathBasic[quest])
            {
                acertos++;
            }
            else
            {
                erros++;
            }
            respostaUsuario = -1;
            pRespondidas[quest] = true;
            mathBasic();
        }
        else
        {
            //GAME OVER
            SceneManager.LoadScene("gameOver");
        }
    }

    public void portBasic()
    {
        //iniciar com cor default
        cores.iniciarCorBotoes();
        //jogo em si
        lbNv.text = "Básico";
        lbDisc.text = "Português";

        quest = Random.Range(0, 9);

        if (respostaUsuario == -1 && acertos + erros < 10 && erros < 3)
        {

            for (int i = 0; i < 65535; i++)
            {
                if (pRespondidas[quest] == true)
                {
                    quest = Random.Range(0, 9);
                }
            }

            lbPergunta.text = pPortBasic[quest];
            lbRespA.text = rPortBasic[quest, 0];
            lbRespB.text = rPortBasic[quest, 1];
            lbRespC.text = rPortBasic[quest, 2];
            lbRespD.text = rPortBasic[quest, 3];
        }
        else if (acertos + erros < 10 && erros < 3)
        {
            if (respostaUsuario == cPortBasic[quest])
            {
                acertos++;
            }
            else
            {
                erros++;
            }
            respostaUsuario = -1;
            pRespondidas[quest] = true;
            portBasic();
        }
        else
        {
            //GAME OVER
            SceneManager.LoadScene("gameOver");
        }
    }

    public void mathAvanc()
    {
        //iniciar com cor default
        cores.iniciarCorBotoes();
        //jogo em si
        lbDisc.text = "Matemática";
        lbNv.text = "Avançado";

        quest = Random.Range(0, 9);

        if (respostaUsuario == -1 && acertos + erros < 10 && erros < 3)
        {

            for (int i = 0; i < 65535; i++)
            {
                if (pRespondidas[quest] == true)
                {
                    quest = Random.Range(0, 9);
                }
            }

            lbPergunta.text = pMathAvanc[quest];
            lbRespA.text = rMathAvanc[quest, 0];
            lbRespB.text = rMathAvanc[quest, 1];
            lbRespC.text = rMathAvanc[quest, 2];
            lbRespD.text = rMathAvanc[quest, 3];
        }
        else if (acertos + erros < 10 && erros < 3)
        {
            if (respostaUsuario == cMathAvanc[quest])
            {
                acertos++;
            }
            else
            {
                erros++;
            }
            respostaUsuario = -1;
            pRespondidas[quest] = true;
            mathAvanc();
        }
        else
        {
            //GAME OVER
            SceneManager.LoadScene("gameOver");
        }
    }

    public void portAvanc()
    {
        //iniciar com cor default
        cores.iniciarCorBotoes();
        //jogo em si
        lbDisc.text = "Português";
        lbNv.text = "Avançado";

        quest = Random.Range(0, 9);

        if (respostaUsuario == -1 && acertos + erros < 10 && erros < 3)
        {

            for (int i = 0; i < 65535; i++)
            {
                if (pRespondidas[quest] == true)
                {
                    quest = Random.Range(0, 9);
                }
            }

            lbPergunta.text = pPortAvanc[quest];
            lbRespA.text = rPortAvanc[quest, 0];
            lbRespB.text = rPortAvanc[quest, 1];
            lbRespC.text = rPortAvanc[quest, 2];
            lbRespD.text = rPortAvanc[quest, 3];
        }
        else if (acertos + erros < 10 && erros < 3)
        {
            if (respostaUsuario == cPortAvanc[quest])
            {
                acertos++;
            }
            else
            {
                erros++;
            }
            respostaUsuario = -1;
            pRespondidas[quest] = true;
            portAvanc();
        }
        else
        {
            //GAME OVER
            SceneManager.LoadScene("gameOver");
        }
    }

    public void respA()
    {
        respostaUsuario = 0;
        VerificarRespostaCor();
        //aguarda a pausa para ler a explicação
        cores.AguardarTempoResposta();        
    }

    public void respB()
    {
        respostaUsuario = 1;
        VerificarRespostaCor();
        //aguarda a pausa para ler a explicação
        cores.AguardarTempoResposta();
    }

    public void respC()
    {
        respostaUsuario = 2;
        VerificarRespostaCor();
        //aguarda a pausa para ler a explicação
        cores.AguardarTempoResposta();
    }

    public void respD()
    {
        respostaUsuario = 3;
        VerificarRespostaCor();
        //aguarda a pausa para ler a explicação
        cores.AguardarTempoResposta();
    }

    //caso seja false, o tempo corre normal. Se for true, ele é pausado
    public void CronometroModoAmpulheta()
    {
        if(tempoPausado==false)
        {
            tempo -= Time.deltaTime;
        }
        else
        {
            lbDisc.text = "Tempo: " + Mathf.Floor(tempo / 60) + ":" + Mathf.Floor(tempo % 60);
        }

        lbDisc.text = "Tempo: " + Mathf.Floor(tempo / 60) + ":" + Mathf.Floor(tempo % 60);
    }

    //para o Update, para selecionar o modo de jogo
    public void ModoDeJogo()
    {
        switch (modoJogo)
        {
            case 0: ampulMode(); break;
            case 1: mathBasic(); break;
            case 2: mathAvanc(); break;
            case 3: portBasic(); break;
            case 4: portAvanc(); break;
        }
    }

    public void DefinirEstatisticas()
    {
        if (modoJogo == 0)
        {
            media = (acertos / 40) * 100;
        }
        else
        {
            media = (acertos / 10) * 100;
        }
    }

    public void VerificarRespostaCor()
    {
        switch (modoJogo)
        {
            case 0:
                switch (disc)
                {
                    case 0:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cMathBasic[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);

                        }
                        else
                        {
                            cores.MudancaCorBotoes(cMathBasic[quest]);
                        }
                        break;
                    case 1:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cMathAvanc[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);

                        }
                        else
                        {
                            cores.MudancaCorBotoes(cMathAvanc[quest]);
                        }
                        break;
                    case 2:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cPortBasic[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);

                        }
                        else
                        {
                            cores.MudancaCorBotoes(cPortBasic[quest]);
                        }
                        break;
                    case 3:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cPortAvanc[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);

                        }
                        else
                        {
                            cores.MudancaCorBotoes(cPortAvanc[quest]);
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                //if para mudar a cor do botão
                if (respostaUsuario == cMathBasic[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);

                }
                else
                {
                    cores.MudancaCorBotoes(cMathBasic[quest]);
                }
                break;
            case 2:
                //if para mudar a cor do botão
                if (respostaUsuario == cMathAvanc[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);

                }
                else
                {
                    cores.MudancaCorBotoes(cMathAvanc[quest]);
                }
                break;
            case 3:
                //if para mudar a cor do botão
                if (respostaUsuario == cPortBasic[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);

                }
                else
                {
                    cores.MudancaCorBotoes(cPortBasic[quest]);
                }
                break;
            case 4:
                //if para mudar a cor do botão
                if (respostaUsuario == cPortAvanc[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);

                }
                else
                {
                    cores.MudancaCorBotoes(cPortAvanc[quest]);
                }
                break;
            default:
                break;
        }
    }

}

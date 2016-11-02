using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class logicaJogo : MonoBehaviour {

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
    public int[] pRespondidas;
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
    public float tempo = 300.0f;
    public int respostaUsuario = -1;
    public int acertos = 0;
    public int erros = 0;


    // Use this for initialization
    void Start() {
        // Perguntas de Matemática Básica
        pMathBasic = new string[10] { "p0", "p1", "p2", "p3", "p4", "p5", "p6", "p7", "p8", "p9" };
        // Respostas de Matemática Básica
        rMathBasic = new string[10, 4] { { "r0a", "r0b", "r0c", "r0d" }, { "r1a", "r1b", "r1c", "r1d" }, { "r2a", "r2b", "r2c", "r2d" }, { "r3a", "r3b", "r3c", "r3d" }, { "r4a", "r4b", "r4c", "r4d" }, { "r5a", "r5b", "r5c", "r5d" }, { "r6a", "r6b", "r6c", "r6d" }, { "r7a", "r7b", "r7c", "r7d" }, { "r8a", "r8b", "r8c", "r8d" }, { "r9a", "r9b", "r9c", "r9d" } };
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
        if (modoJogo == 0 && tempo != 0)
        {
            tempo -= Time.deltaTime;
            lbDisc.text = "Tempo: " + Mathf.Floor(tempo / 60) +":" + Mathf.Floor(tempo%60);
        }
    }

    public void ampulMode()
    {
        int randomquest = Random.Range(0, 9);
        int randomdisc = Random.Range(0, 3);
        int[,] jafeitas = new int[4, 10];
        int temp;
        lbExp.text = "";
        lbNv.text = "";
        
        while(tempo > 0)
        {
            respostaUsuario = -1;

            if(randomdisc == 0)
            {
                temp = randomquest;
                lbPergunta.text = pMathBasic[temp];
                lbRespA.text = rMathBasic[temp, 0];
                lbRespB.text = rMathBasic[temp, 1];
                lbRespC.text = rMathBasic[temp, 2];
                lbRespD.text = rMathBasic[temp, 3];
                while (respostaUsuario == -1)
                {
                    if (respostaUsuario == cMathBasic[temp])
                    {
                        acertos++;
                    }
                    else if(respostaUsuario != -1)
                    {
                        erros++;
                    }
                }   
            }
            else if(randomdisc == 1)
            {
                temp = randomquest;
                lbPergunta.text = pMathAvanc[temp];
                lbRespA.text = rMathAvanc[temp, 0];
                lbRespB.text = rMathAvanc[temp, 1];
                lbRespC.text = rMathAvanc[temp, 2];
                lbRespD.text = rMathAvanc[temp, 3];
                while (respostaUsuario == -1)
                {
                    if (respostaUsuario == cMathAvanc[temp])
                    {
                        acertos++;
                    }
                    else if (respostaUsuario != -1)
                    {
                        erros++;
                    }
                }
            }
            else if(randomdisc == 2)
            {
                temp = randomquest;
                lbPergunta.text = pPortBasic[temp];
                lbRespA.text = rPortBasic[temp, 0];
                lbRespB.text = rPortBasic[temp, 1];
                lbRespC.text = rPortBasic[temp, 2];
                lbRespD.text = rPortBasic[temp, 3];
                while (respostaUsuario == -1)
                {
                    if (respostaUsuario == cPortBasic[temp])
                    {
                        acertos++;
                    }
                    else if (respostaUsuario != -1)
                    {
                        erros++;
                    }
                }
            }
            else if(randomdisc == 3)
            {
                temp = randomquest;
                lbPergunta.text = pPortAvanc[temp];
                lbRespA.text = rPortAvanc[temp, 0];
                lbRespB.text = rPortAvanc[temp, 1];
                lbRespC.text = rPortAvanc[temp, 2];
                lbRespD.text = rPortAvanc[temp, 3];
                while (respostaUsuario == -1)
                {
                    if (respostaUsuario == cPortAvanc[temp])
                    {
                        acertos++;
                    }
                    else if (respostaUsuario != -1)
                    {
                        erros++;
                    }
                }
            }
        }
        //GameOver//

        
    }

    public void mathBasic()
    {
        lbNv.text = "Básico";
        lbDisc.text = "Matemática";
    }

    public void portBasic()
    {
        lbNv.text = "Básico";
        lbDisc.text = "Português";
    }

    public void mathAvanc()
    {
        lbDisc.text = "Matemática";
        lbNv.text = "Avançado";
    }

    public void portAvanc()
    {
        lbDisc.text = "Português";
        lbNv.text = "Avançado";
    }

    public void respA()
    {
        respostaUsuario = 0;
    }

    public void respB()
    {
        respostaUsuario = 1;
    }

    public void respC()
    {
        respostaUsuario = 2;
    }

    public void respD()
    {
        respostaUsuario = 3;
    }
}

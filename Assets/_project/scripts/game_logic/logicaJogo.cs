using UnityEngine;
using System.Collections;

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
    }

    // Update is called once per frame
    void Update() {

    }

    public static void comecaJogo(int modojogo)
    {
        switch(modojogo)
        {
            case 0: ampulMode(); break;
            case 1: mathBasic(); break;
            case 2: mathAvanc(); break;
            case 3: portBasic(); break;
            case 4: portAvanc(); break;
        }
    }

    public static void ampulMode()
    {

    }

    public static void mathBasic()
    {

    }

    public static void portBasic()
    {

    }

    public static void mathAvanc()
    {

    }

    public static void portAvanc()
    {

    }
}

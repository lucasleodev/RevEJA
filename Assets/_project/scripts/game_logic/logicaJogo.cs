using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicaJogo : MonoBehaviour
{
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
    public static int qtdAcerto, qtdErro;


    // Use this for initialization
    void Start()
    {
        //corrige um bug de setar o tempo em 0 após sair pelo pause
        Time.timeScale = 1.0f;
        //cria instância e deixa botões com a cor definida como default
        cores = GetComponent<corBotoes>();
        cores.iniciarCorBotoes();
        //----------FIM DO TRECHO DE INICIAR AS CORES--------------
        // Perguntas de Matemática Básica
        pMathBasic = new string[10] { "Assinale a alternativa que mostra um número compreendido entre 2,31 e 2,32:", "Em um jogo, o valor de cada ponto perdido é -4, e o valor de cada ponto ganho é +3. Ana perdeu 13 pontos e ganhou 15 pontos. Fazendo os cálculos, pode-se verificar que o total de pontos de Ana é:", "Na seguinte equação ( 2+2x2 ), qual seria o resultado?", "Uma polegada corresponde a cerca de 2,5 cm. Um sapato comprado no exterior possui 6 polegadas de comprimento, que corresponde a:", "Imaginando a figura de uma bola de futebol, de um dado e de um copo de vidro, podemos associa-los com as respectivas formas geométricas:", "Pedro cercou um terreno quadrado de lado igual a 90 metros. Quantos metros de muro Pedro construiu para cercar todo esse terreno?", "Considere a promoção “Leve 5 toalhas, pague 3”. Ignorando o preço das toalhas, de quanto seria o desconto?", "Ao pesar 1/4 de quilograma de salame, a balança mostrou:", "Na seguinte equação (   5x5+(1x(3+3))   ), qual seria o resultado?", "A fração de uma hora que corresponde a 15 minutos é" };
        // Respostas de Matemática Básica
        rMathBasic = new string[10, 4] { { "2,315 ", "2,309", "2,205", "2,305 " }, { "-10", "-7", "3", "1" }, { "4", "8", "6", "10" }, { "12 cm", "13 cm", "14 cm", "15 cm" }, { "esfera/cubo/cilindro", "cilindro/cubo/esfera", "cilindro/esfera/cubo", "cubo/esfera/cilindro" }, { "90", "180", "360", "810" }, { "20%", "40%", "60%", "80%" }, { "0,250 kg", "0,125 kg", "0,150 kg", "0,500 kg" }, { "28", "31", "18", "26" }, { "1/6", "1/4", "1/3", "1/2" } };
        // Perguntas de Português Básico
        pPortBasic = new string[10] { "Na oração “Luiz resolveu ir ao cinema”, qual é o sujeito?", "Qual das opções abaixo é usada em orações interrogativas?", "Pronomes são divididos em quantos modos?", "Quais os graus de um substantivo?", "O que são adjetivos?", "Professora: Roberto, conjugue o verbo ir no presente. Roberto: EU...VOU, tu...vais, ele...vai... Professora: Mais rápido, mais rápido! Roberto: Nós corremos, vós correis, eles correm! /*/*/*//*/*/*/ O efeito de humor do texto é provocado pelo fato de:", "notícia s.f. 1. Informação a respeito de acontecimento novo 2. conhecimento da situação de alguém 3. recordação, lembrança 4. nota 5. JOR relato de fatos ou acontecimentos, recentes ou atuais, ocorridos do país ou no mundo, veiculado em jornal, televisão, revista etc. /*/*/*/*/*/*/*/ Os numerais usados para definir a palavra “notícia” servem para:", "Minha rua Reynaldo Damazio A rua é pequena meio torta, o carro passa rápido, as casas ficam quietas, janelas nem piscam. Fonte: DAMAZIO, Reynaldo. Folhinha. Folha de São Paulo. São Paulo, mar. 2003. Personificação é uma forma de dar características de seres animados a seres inanimados. Marque a alternativa em que ocorre um exemplo de personificação:", "Acabou percebendo que o tal fio só era perdido quando, no meio de uma história ou conversa, alguém vinha com qualquer pergunta ou assunto diferente. Era o bastante: -Viu? Agora perdi o fio da meada... reclamava o contador do caso. Uma noite, olhos bem abertos, resolveu interromper a mãe, que contava uma história para ele dormir. Não demorou muito e ela exclamou: -Droga! Perdi o fio da meada.Fonte: GAMA, Rinaldo. Folhinha, FolhadeS. Paulo, 6 nov. 1983./*/*/*/ A expressão 'perdi o fio da meada' significa que a mãe:", "Qual o coletivo de lobo?" };
        // Respostas de Português Básico
        rPortBasic = new string[10, 4] { { "Luiz", "Cinema", "Resolveu", "Nenhuma das anteriores" }, { "Porquê", "Porque", "Por que", "Por quê" }, { "3: plural, singular e possesivo", "1: imperativo", "2: singular e plurial", "2: singular e plural" }, { "Aumentativo e diminutivo", "Aumentativo e simples", "Diminutivo e indicativo", "Derivativo e coletivo" }, { "Palavras que dão características ao substantivo", "Palavras que modificam o verbo", "Palavras que funcionam como sinônimos", "Nenhuma das anteriores" }, { "Roberto não saber conjugar o verbo ir.", "A professora pedir para Roberto conjugar o verbo ir.", "A professora pedir para Roberto falar mais rápido.", "Roberto entender de forma equivocada o pedido da professora." }, { "sensibilizar o leitor sobre a importância da notícia", "apontar de forma difícil o significado da palavra", "chamar a atenção para a ordem crescente dos vários significados", "organizar os vários significados da palavra" }, { "“A rua é pequena”", "“janelas nem piscam”", "“o carro passa rápido”", "“meio torta”" }, { "contou uma mentira", "desistiu do que ia falar", "esqueceu o que ia dizer", "quis enganar o menino" }, { "Alcatéia", "Matilha", "Bando", "Alcatilha" } };
        // Perguntas de Matemática Avançada
        pMathAvanc = new string[10] { "Resolva a expressão a seguir e marque a alternativa que corresponde ao resultado certo: 2³x2³+3/2⁶ = ?", "Uma massa de bolo precisa ser batida durante 1/4 de hora , ou seja , durante:", "Carla está calculando custo de um a viagem de carro. Ela sabe que, para andar 120Km seu carro consome 15 litros de combustível cujo preço é R$ 2,00 o litro. Para uma viagem de 960Km, Carla gastará, apenas com combustível:", "Uma máquina fotográfica custava R$ 400,00. No Dia dos Pais foi vendida com um desconto de 5% e, logo depois, em cima do novo preço sofreu um aumento de 10%. O seu preço atual, em reais, é:", "João tem um quadro retangular que mede 25 cm x 15 cm. A área desse quadro em cm² é:", "A área de um quadrado de tamanho x+2 é 49 cm². Logo, o valor de x é:", "A equação (x-3) * (x-2)=0  é a forma fatorada de:", "A nota de José, nos 3 primeiros bimestres do ano, foi 7. No último bimestre, porém, ele tirou 9. Sua média final, então, foi de:", "Em um retângulo de largura de 5 cm e comprimento de y cm, sua área é de 45cm². Qual seu comprimento?", "Em um restaurante, o cardápio constitui de 3 opções de entradas, 5 opções de pratos principais, 4 bebidas e 8 sobremesas. Qual a combinação possível de refeições completas (entrada, prato principal, bebida e sobremesa)?" };
        // Respostas de Matemática Avançada
        rMathAvanc = new string[10, 4] { { "3", "24", "32", "27" }, { "5 min", "15 min ", "30 min", "45 min" }, { "R$ 120,00 ", "R$ 128,00", "R$ 220,00 ", "R$ 240,00" }, { "R$ 405,00", "R$ 412,00", "R$ 418,00", "R$ 420,00" }, { "375", "175", "39", "111" }, { "5", "6", "9", "11" }, { "X²-6=0", "x²-5x-6=0", "x²-5x+6=0", "2x-5=0" }, { "6,5", "7", "8", "7,5" }, { "9", "8", "7", "6" }, { "480", "320", "240", "560" } };
        // Perguntas de Português Avançado
        pPortAvanc = new string[10] { "Dentre as palavras abaixo, apenas uma apresenta prefixo e sufixo. Assinale-a:", "Qual movimento literário tem como características a preocupação dos artistas com o equilíbrio artístico, combatendo os exagereos de estilos anteriores, como o Romantismo?", "Aquisição à vista. A Bauducco, maior fabricante de panetones do país, está negociando a compra de sua maior concorrente, a Visconti, subsidiária brasileira da italiana Visagis. O negócio vem sendo mantido sob sigilo pelas duas empresas em razão da proximidade do Natal. Seus controladores temem que o anúncio dessa união – resultando numa espécie de AmBev dos panetones – melindre os varejistas. (Cláudia Vassallo, na Exame, dez./99)/*/*/*/*/Por “aquisição à vista” entende-se, no texto:", "No substantivo CEDER, sua derivada fica:", "“Modo Indicativo”: No pretérito mais que perfeito, o verbo poup-o fica:", "“Modo Subjuntivo”: No pretérito imperfeito, o verbo levar fica:", "De que século é o Trovadorismo?", "Quais as características do Gênero Lírico?", "Qual é a característica do Romantismo?", "Sujeito 1: 5 tiros? Sujeito 2: É. Sujeito 1: Brincando de pegador? Sujeito 2: É. O PM pensou que... Sujeito 1: Hoje? Sujeito 2: Cedinho./*/*/*/*/*/ Os sinais de pontuação são elementos com importantes funções para a progressão temática. Nesse miniconto, as reticências foram utilizadas para indicar:" };
        // Respostas de Português Avançado
        rPortAvanc = new string[10, 4] { { "desvio", "influir", "repulsa", "desconfortável" }, { "Parnasianismo", "Realismo", "Naturalismo", "Barroco" }, { "que a negociação é provável.", "que a negociação está distante, mas vai acontecer", "que a negociação dificilmente ocorrerá", "que a negociação está próxima" }, { "cesão", "cessão", "ceção", "cedessão" }, { "poupava", "poupei", "poupara", "pouparei" }, { "leve", "levasse", "levar", "levares" }, { "V ao XV", "IV ao VII", "V ao X", "V ao IX" }, { "Poesia cantada", "Comédia / tragédia", "Relatando heróis greco-romanos", "Contando as histórias dos deuses" }, { "Linguagem muito descritiva", "Texto nacionalista", "Possui musa inspiradora", "Todas" }, { "Uma fala hesitante", "Uma informação implícita", "Uma situação incoerente", "A interrupção de uma ação" } };
        // Explicações de Matemática Básica
        eMathBasic = new string[10] { "2,315 está entre 2,31 e 2,32. Como as casas decimais podem tender ao infinito (2,310000000000001 por exemplo), ele está incluso", "13 vezes -4 resulta -52. 15 vezes 3 resulta 45. -52+45 = -7", "Primeiro é feito sempre multiplicação e divisão, depois é feito soma e subtração. 2x2=4, que somado a 2 resulta 6", "15 cm, pois 6x2,5=15", "Esfera. cubo e cilindro respectivamente", "Se o terreno tem o formato de um quadrado, e cada lado possui 90 metros, murar todos os lados resultará em 360 metros, pois 90x4=360", "Usando da regra de 3: 5 toalhas vale 100% e 3 valem x. Logo, forma a equação 5x=300. x=300/5 que dá 60%", "Se meio quilo é igual a 0.500 kg, 1/4 de quilo será a metade da metade, ou 0,250 kg", "31. Primeiro são realizadas as operações dentro dos parênteses, independente de sua natureza(adição, subtração...). Depois é feita a multiplicação e divisão, e por fim a soma e a subtração", "1 hora equivale a 60 minutos. Dividindo 60 por 15 temos 4. Logo 15 minutos de hora é igual a 1/4" };
        // Explicações de Matemática Avançada
        eMathAvanc = new string[10] { "Usando as propriedades de exponenciação, mantém-se a base e soma-se o expoente (por ser multiplicação), o que faz o 2³x2³ virar 2⁶. Agora com 2⁶+3/2⁶, corta-se o 2⁶, restando 3", "Dividindo 60 minutos por 4, temos 15 minutos, o quarto de hora", "A cada 120km o carro consome 15 litros de combustível. Dividindo 960 por 120 temos 8. Multiplica-se ele por 15 (120) e depois por 2, que é o preço da gasolina, tendo como resultado 240", "Multiplicando 400 por 0,05 (a forma decimal de 5%), temos 20. Subtraindo de 400, resta 380. Agora repetimos a conta, com 380x0,1 (forma decimal de 10%), obtendo 38 como resultado. Somando 380+38, chegamos no novo preço de R$ 418,00", "Basta multiplicar 25x15. A área de um retângulo é sua largura vezes comprimento", "A área de um quadrado é o tamanho do lado ao quadrado. O único número somado com 2 que ao quadrado resulta em 49 é 5 (5+2=7 e 7²=49)", "É só aplicar a regra da distributiva e calcular: x vezes x é x² e x vezes -2 é -2x. -3 vezes x é -3x e -3 vezes -2 é 6. A equação fica x²-5x+6", "1 ano é formado por 4 bimestres. Ele tirou 7 três vezes e 9 uma vez. então, soma-se tudo e divide-se por 4, tendo a média de 7,5", "Basta dividir 45 por 5. O comprimento é 9", "Como vai ser escolhido apenas 1 item de cada uma das opções, basta multiplicar todas as opções: 3x5x4x8=480" };
        // Explicações de Português Básico
        ePortBasic = new string[10] { "Luiz. O sujeito de uma oração sempre vem antes do verbo, que no caso é “resolveu”", "Por que. Por quê é usado em finais de frase ou antes de pontos de interrogação. Porque é equivalente a pois, uma vez que, então é usada como pausa. Porquê é um substantivo com o sentido de causa, razão ou motivo.", "Singular e Plural. No singular existe o eu, tu, ele e no plural nós, vós, eles.", "aumentativo e diminutivo. E ainda há 2 divisões: pode ser a forma sintética, formado através de sufixos (voz/vozeirão,  casa/casinha, ovo/ovinho) ou na forma analítica, formada com a ajuda de adjetivos (casa / casa grande, pedra/ pedra minúscula)  ", "Palavras que dão características ao substantivo. Por exemplo, no substantivo homem podemos aplicar os adjetivos alto, magro, gordo, elegante, rico, forte, baixo, pálido. Essas palavras são adjetivos.", "Roberto entender de forma equivocada o pedido da professora, pois ele entender que deve conjugar o verbo correr, que é o ato de andar (ir) mais rápido", "Organizar os vários significados da palavra, os dividindo por tópicos", "“janelas nem piscam”", "esqueceu o que ia dizer. Perder o fio da meada é uma gíria para dizer que perdeu o foco do que estava sendo dito", "Alcatéia. Matilha é o coletivo de cão" };
        // Explicações de Português Avançado
        ePortAvanc = new string[10] { "Desconfortável, pois temos a Palavra Inicial Conforto, o prefixo des, o radical confort e o sufixo ável, formando a palavra: Desconfortável.", "Parnasianismo. Entre outras características desse movimento estão a imparcialidade do autor (sua visão do mundo não interfere na abordagem dos fatos), objetividade no tratamento dos temas abordados e busca da perfeição e beleza estética dos textos (por isso a preferência por sonetos e a valorização da metrificação)", "Que a negociação está próxima. Pois a negociação é vista como “terra a vista”.", "Cessão. Pois em todos os substantivos derivados de verbos terminados em -gredir, -mitir e -ceder, devemos usar ss.", "Poupara", "Levasse", "Idade Média, século V ao XV, o gênero lírico -> Trovadorismo foi a 1ª escola literária", "Poesia cantada, normalmente acompanho pela lira", "Todas. O Romantismo surgiu na França com o movimento de exposição de sentimentos, aproximadamente em 1800. Suas particularidades eram a linguagem descritiva, o sentimentalismo exagerado, o nacionalismo, a presença de figuras de linguagem, possuir uma musa inspiradora e o personagem masculino principal ser o perfeito herói.", "Uma informação implícita" };
        /* Respostas Corretas [A = 0, B = 1, C = 2, D = 3] */
        // Matemática Básica
        cMathBasic = new int[10] { 0, 1, 2, 3, 0, 2, 2, 0, 1, 1 };
        // Matemática Avançada
        cMathAvanc = new int[10] { 0, 1, 3, 2, 0, 0, 2, 3, 0, 0 };
        // Português Básico
        cPortBasic = new int[10] { 0, 2, 4, 0, 0, 3, 3, 1, 2, 0 };
        // Português Avançado
        cPortAvanc = new int[10] { 3, 0, 3, 1, 2, 1, 0, 0, 3, 1 };
        // Colocar vetores e matrizes
        pRespondidasAmp = new bool[4, 10] { { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false } };
        pRespondidas = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        respostaUsuario = -1;
        acertos = 0;
        erros = 0;
        tempo = 300.0f;

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
    void Update()
    {
        if (modoJogo == 0 && tempo > 0)
        {
            //inicia cronometro
            CronometroModoAmpulheta();
        }
        else if (modoJogo == 0)
        {
            // GAME OVER
            qtdAcerto = acertos;
            qtdErro = erros;
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

        if (respostaUsuario == -1 && acertos + erros < 40)
        {
            quest = Random.Range(0, 9);
            disc = Random.Range(0, 3);

            for (int i = 0; i < 65535; i++)
            {
                if (pRespondidasAmp[disc, quest] == true)
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
                lbExp.text = eMathBasic[quest];

            }
            else if (disc == 1)
            {
                lbPergunta.text = pMathAvanc[quest];
                lbRespA.text = rMathAvanc[quest, 0];
                lbRespB.text = rMathAvanc[quest, 1];
                lbRespC.text = rMathAvanc[quest, 2];
                lbRespD.text = rMathAvanc[quest, 3];
                lbExp.text = eMathAvanc[quest];

            }
            else if (disc == 2)
            {
                lbPergunta.text = pPortBasic[quest];
                lbRespA.text = rPortBasic[quest, 0];
                lbRespB.text = rPortBasic[quest, 1];
                lbRespC.text = rPortBasic[quest, 2];
                lbRespD.text = rPortBasic[quest, 3];
                lbExp.text = ePortBasic[quest];

            }
            else if (disc == 3)
            {
                lbPergunta.text = pPortAvanc[quest];
                lbRespA.text = rPortAvanc[quest, 0];
                lbRespB.text = rPortAvanc[quest, 1];
                lbRespC.text = rPortAvanc[quest, 2];
                lbRespD.text = rPortAvanc[quest, 3];
                lbExp.text = ePortAvanc[quest];

            }
        }
        else if (acertos + erros < 40)
        {
            if (disc == 0)
            {
                if (respostaUsuario == cMathBasic[quest])
                {
                    acertos++;
                }
                else
                {
                    erros++;
                }
            }
            else if (disc == 1)
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
            else if (disc == 3)
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
            qtdAcerto = acertos;
            qtdErro = erros;
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
            lbExp.text = eMathBasic[quest];
        }
        else if (acertos + erros < 10 && erros < 3)
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
            qtdAcerto = acertos;
            qtdErro = erros;
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
            lbExp.text = ePortBasic[quest];


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
            qtdAcerto = acertos;
            qtdErro = erros;
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
            lbExp.text = eMathAvanc[quest];
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
            qtdAcerto = acertos;
            qtdErro = erros;
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
            lbExp.text = ePortAvanc[quest];
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
            qtdAcerto = acertos;
            qtdErro = erros;
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
        if (tempoPausado == false)
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

    //reservar para outro metodo

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
                            cores.SomCerto();
                        }
                        else
                        {
                            cores.MudancaCorBotoes(cMathBasic[quest]);
                            cores.SomErrado();
                        }
                        break;
                    case 1:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cMathAvanc[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);
                            cores.SomCerto();
                        }
                        else
                        {
                            cores.MudancaCorBotoes(cMathAvanc[quest]);
                            cores.SomErrado();
                        }
                        break;
                    case 2:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cPortBasic[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);
                            cores.SomCerto();
                        }
                        else
                        {
                            cores.MudancaCorBotoes(cPortBasic[quest]);
                            cores.SomErrado();
                        }
                        break;
                    case 3:
                        //if para mudar a cor do botão
                        if (respostaUsuario == cPortAvanc[quest])
                        {
                            cores.MudancaCorBotoes(respostaUsuario);
                            cores.SomCerto();
                        }
                        else
                        {
                            cores.MudancaCorBotoes(cPortAvanc[quest]);
                            cores.SomErrado();
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
                    cores.SomCerto();
                }
                else
                {
                    cores.MudancaCorBotoes(cMathBasic[quest]);
                    cores.SomErrado();
                }
                break;
            case 2:
                //if para mudar a cor do botão
                if (respostaUsuario == cMathAvanc[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);
                    cores.SomCerto();
                }
                else
                {
                    cores.MudancaCorBotoes(cMathAvanc[quest]);
                    cores.SomErrado();
                }
                break;
            case 3:
                //if para mudar a cor do botão
                if (respostaUsuario == cPortBasic[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);
                    cores.SomCerto();
                }
                else
                {
                    cores.MudancaCorBotoes(cPortBasic[quest]);
                    cores.SomErrado();
                }
                break;
            case 4:
                //if para mudar a cor do botão
                if (respostaUsuario == cPortAvanc[quest])
                {
                    cores.MudancaCorBotoes(respostaUsuario);
                    cores.SomCerto();
                }
                else
                {
                    cores.MudancaCorBotoes(cPortAvanc[quest]);
                    cores.SomErrado();
                }
                break;
            default:
                break;
        }
    }

}
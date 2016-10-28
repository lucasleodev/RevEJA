using UnityEngine;
using System.Collections;

public class gerenciadorPerguntas : MonoBehaviour
{
    [SerializeField]
    private TextAsset questoesXML;
    private perguntas questionData;
    private Pergunta currentQuestion;

    void Start()
    {
        questionData = perguntas.LoadFromText(questoesXML.text);
    }

    // Call this when you want a new question
    public void SetNewQuestion()
    {
        // gets a random question
        int q = Random.Range(0, questionData.questoes.Count - 1);
        currentQuestion = questionData.questoes[q];

        // add code here to set text values of your Question GameObject
        // e.g. GetComponent<SomeScript>().Text = currentQuestion.questionText;
    }

    // Use this to see if user selected correct answer
    public bool CorrectAnswerSelected(int selectedAnswerID)
    {
        return selectedAnswerID == currentQuestion.idRespostaCorreta;
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public struct Pergunta
{
    public string pergunta;
    public string respostaA;
    public string respostaB;
    public string respostaC;
    public string respostaD;
    public string explicacao;
    public int idRespostaCorreta;
}

[XmlRoot]


public class perguntas
{
    [XmlArray("Questions")]
    [XmlArrayItem("Question")]
    public List<Pergunta>
        questoes = new List<Pergunta>();

    public static perguntas LoadFromText(string text)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(perguntas));
            return serializer.Deserialize(new StringReader(text)) as perguntas;
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Exception loading question data: " + e);
            return null;
        }
    }
}

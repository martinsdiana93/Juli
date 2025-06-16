using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{

    public GameObject menuInicial;
    public GameObject JogoCopos;

    public TMP_Text rightAnswersText;
    public TMP_Text wrongAnswersText;

    public GameObject popUpFinal;

    public void Start()
    {
        
    }

    public void TestAgain()
    {
        Contar_Pontos.Reset();
        menuInicial.SetActive(true);
        JogoCopos.SetActive(false);
        popUpFinal.SetActive(false);
        FindFirstObjectByType<JogoCoposController>()?.IniciarNivel();
    }

    public void EndGame()
    {
        rightAnswersText.text = Contar_Pontos.GetRightAnswer().ToString();
        wrongAnswersText.text = Contar_Pontos.GetWrongAnswer().ToString();
        popUpFinal.SetActive(true);
    }
}

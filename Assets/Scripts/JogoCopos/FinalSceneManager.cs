using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{

    public GameObject menuInicial;
    public GameObject JogoCopos;
    public GameObject botaoAvancarNivel;

    public TMP_Text rightAnswersText;
    public TMP_Text wrongAnswersText;

    public GameObject popUpFinal;

    public void TestAgain()
    {
        Contar_Pontos.Reset();
        menuInicial.SetActive(false);
        JogoCopos.SetActive(true);
        popUpFinal.SetActive(false);
        FindFirstObjectByType<JogoCoposController>()?.IniciarNivel();
    }

    public void VoltarMenuJogoCopos()
    {
        Contar_Pontos.Reset();
        menuInicial.SetActive(true);
        JogoCopos.SetActive(false);
        popUpFinal.SetActive(false);
        FindFirstObjectByType<JogoCoposController>()?.ResetarCenas();
    }

    public void NextLevel()
    {
        Contar_Pontos.Reset();
        menuInicial.SetActive(false);
        JogoCopos.SetActive(true);
        popUpFinal.SetActive(false);

        var jogoCoposController = FindFirstObjectByType<JogoCoposController>();
        if (jogoCoposController != null)
        {
            jogoCoposController.nivelActual++; // Avança para o próximo nível
            jogoCoposController.IniciarNivel();
        }
    }

    public void VoltarMenunicial()
    {
        Contar_Pontos.Reset();
    }

    public void EndGame()
    {
        rightAnswersText.text = Contar_Pontos.GetRightAnswer().ToString();
        wrongAnswersText.text = Contar_Pontos.GetWrongAnswer().ToString();
        MostrarPopUpFinal();
    }

    public void MostrarPopUpFinal()
    {
        popUpFinal.SetActive(true);

        var jogoCoposController = FindFirstObjectByType<JogoCoposController>();
        if (jogoCoposController != null)
        {
            if (jogoCoposController.nivelActual == 3) // 3 é o último nível
            {
                botaoAvancarNivel.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
        else
        {
            botaoAvancarNivel.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class WordGame : MonoBehaviour
{
    public List<GameObject> SolutionWord = new List<GameObject>();
    public List<LetterButton> LetterOption = new List<LetterButton>();
    public string FinalWord = "";
    public int wordStep=0;

    public GameObject PopUpFinal;

    public bool game_finished = false;
    public float end_delay = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        wordStep = 0;
        game_finished = false;
        end_delay = 0f;

        if (PopUpFinal == null)
{
        Debug.LogWarning("PopUpFinal não foi atribuído!");
}

        if (PopUpFinal != null && PopUpFinal.activeSelf)
            PopUpFinal.SetActive(false); // Garante que está escondido no início

        foreach (GameObject letter in SolutionWord)
        {
            letter.SetActive(false);
        }

        foreach (LetterButton letter in LetterOption)
        {
            letter.gameObject.SetActive(true);
        }
    }

    public void PickLetter(LetterButton ButtonChosen)
    {
        if (game_finished) return;

        if (ButtonChosen.letter == FinalWord[wordStep])
        {
            SolutionWord[wordStep].SetActive(true);
            ButtonChosen.gameObject.SetActive(false);
            wordStep++;
        }

        if(wordStep >=FinalWord.Length)
        {
            Debug.Log("Fim do jogo — a mostrar popup");
            //Ganhaste o jogo
            if (PopUpFinal != null)
                PopUpFinal.SetActive(true); // Mostra o popup final
            game_finished = true;
        }
    }

    public void RepetirNivel()
    {
        if (PopUpFinal != null)
            PopUpFinal.SetActive(false); // Esconde o popup final, se estiver visível

        StartGame(); // Recomeça o jogo com os mesmos dados
    }
}

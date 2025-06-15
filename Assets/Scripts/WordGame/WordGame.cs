using UnityEngine;
using System.Collections.Generic;

public class WordGame : MonoBehaviour
{
    public List<GameObject> SolutionWord = new List<GameObject>();
    public List<LetterButton> LetterOption = new List<LetterButton>();
    public string FinalWord = "";
    public int wordStep=0;

    public bool game_finished = false;
    public float end_delay = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        wordStep = 0;
        game_finished = false;
        end_delay = 0f;
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
        if (ButtonChosen.letter == FinalWord[wordStep])
        {
            SolutionWord[wordStep].SetActive(true);
            ButtonChosen.gameObject.SetActive(false);
            wordStep++;
        }

        if(wordStep >=FinalWord.Length)
        {
            //Ganhaste o jogo
            game_finished = true;
        }
    }

    void Update()
    {
        if (game_finished){
            end_delay += Time.deltaTime;
            if(end_delay >= 2.0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

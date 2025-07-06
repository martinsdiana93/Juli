using UnityEngine;
using System.Collections.Generic;

public class WordGame : MonoBehaviour
{
    public List<GameObject> SolutionWord = new List<GameObject>();
    public List<LetterButton> LetterOption = new List<LetterButton>();
    public string FinalWord = "";
    public int wordStep=0;

    public GameObject PopUpFinal;
    public LevelManager levelManager;

    public bool game_finished = false;
    public float end_delay = 0f;

    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;

    public void Update()
    {
        if (game_finished)
        {
            end_delay += Time.deltaTime;
            if (end_delay >= 2.0f)
            {
                game_finished = false;
                end_delay = 0f;
                if (PopUpFinal != null)
                {
                    PopUpFinal.SetActive(true); // Mostra o popup final
                }
                levelManager.UpdateButtons();
            }
        }
    }

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
            correctSound.Play(); 
        }
        else
        {
           wrongSound.Play();
        }

        if(wordStep >=FinalWord.Length)
        {
            Debug.Log("Fim do jogo — a mostrar popup");
            //Ganhaste o jogo
            game_finished = true;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class WordGameDif : MonoBehaviour
{
	public List<WordGame> easygames=new List<WordGame>();
    public List<WordGame> mediumgames = new List<WordGame>();
    public List<WordGame> hardgames = new List<WordGame>();

    public void ChooseDifficulty(int difficulty)
   {
        int choice = 0;
        switch (difficulty)
        {
            case 1:
                choice= Random.Range(0, easygames.Count);
                easygames[choice].gameObject.SetActive(true);
                easygames[choice].StartGame();
                break;
            case 2:
                choice = Random.Range(0, mediumgames.Count);
                mediumgames[choice].gameObject.SetActive(true);
                mediumgames[choice].StartGame();
                break;
            case 3:
                choice = Random.Range(0, hardgames.Count);
                hardgames[choice].gameObject.SetActive(true);
                hardgames[choice].StartGame();
                break;
        }
   }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public enum Dificuldade { Facil, Medio, Dificil }

    public Dificuldade dificuldadeAtual;
    public WordGameDif wordGameDif; // Refer�ncia ao script que tem as listas de jogos

    public GameObject botaoAvancar; // Bot�o "Avan�ar n�vel", que ser� desativado no fim
    public GameObject popupFinal;

    public void AvancarNivel()
    {
        // Verifica se j� chegou ao fim
        if (wordGameDif.currentDifficulty >= 3)
        {
            UpdateButtons();
            Debug.Log("�ltimo n�vel atingido.");
            return;
        }
        DesactivarJogos();
        wordGameDif.ChooseDifficulty(wordGameDif.currentDifficulty + 1);
    }

    public void UpdateButtons()
    {
        Debug.Log("Update Button!");
        botaoAvancar.GetComponent<Button>().interactable = (wordGameDif.currentDifficulty < 3); // Esconde o bot�o
    }

    public void DesactivarJogos()
    {
        popupFinal.SetActive(false);
        // Desativa todos os jogos
        foreach (WordGame jogo in wordGameDif.easygames)
            jogo.gameObject.SetActive(false);
        foreach (WordGame jogo in wordGameDif.mediumgames)
            jogo.gameObject.SetActive(false);
        foreach (WordGame jogo in wordGameDif.hardgames)
            jogo.gameObject.SetActive(false);
        Debug.Log("Jogos Desactivados!");
    }

    public void RepetirNivelAleatorio()
    {
        DesactivarJogos();
        wordGameDif.ChooseDifficulty(wordGameDif.currentDifficulty);
    }
}

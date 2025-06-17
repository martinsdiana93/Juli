using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public enum Dificuldade { Facil, Medio, Dificil }

    public Dificuldade dificuldadeAtual;
    public WordGameDif wordGameDif; // Referência ao script que tem as listas de jogos

    private int indiceAtual = 0;

    public GameObject botaoAvancar; // Botão "Avançar nível", que será desativado no fim

    public void IniciarJogo(Dificuldade dificuldade)
    {
        dificuldadeAtual = dificuldade;
        indiceAtual = 0;
        AtivarNivelAtual();
    }

    public void AvancarNivel()
    {
        indiceAtual++;

        // Verifica se já chegou ao fim
        if (indiceAtual >= ObterListaAtual().Count)
        {
            Debug.Log("Último nível atingido.");
            botaoAvancar.SetActive(false); // Esconde o botão
            return;
        }

        AtivarNivelAtual();
    }

    private void AtivarNivelAtual()
    {
        List<WordGame> lista = ObterListaAtual();

        // Desativa todos os jogos
        foreach (WordGame jogo in lista)
            jogo.gameObject.SetActive(false);

        WordGame nivelAtual = lista[indiceAtual];
        nivelAtual.gameObject.SetActive(true);
        nivelAtual.StartGame();

        Debug.Log("Dificuldade atual: " + dificuldadeAtual + " | Nível: " + indiceAtual);
        botaoAvancar.SetActive(indiceAtual < lista.Count - 1); // Esconde se for o último
    }

    private List<WordGame> ObterListaAtual()
    {
        switch (dificuldadeAtual)
        {
            case Dificuldade.Facil: return wordGameDif.easygames;
            case Dificuldade.Medio: return wordGameDif.mediumgames;
            case Dificuldade.Dificil: return wordGameDif.hardgames;
            default: return new List<WordGame>();
        }
    }

    public void RepetirNivelAleatorio()
    {
        // Obtém lista atual da dificuldade
        List<WordGame> lista = ObterListaAtual();

        // Desativa todos os jogos
        foreach (WordGame jogo in lista)
        {
            jogo.gameObject.SetActive(false);
        }

        // Escolhe outro jogo aleatório
        int novoIndice = Random.Range(0, lista.Count);
        indiceAtual = novoIndice;

        // Ativa e inicia o novo jogo
        lista[indiceAtual].gameObject.SetActive(true);
        lista[indiceAtual].StartGame();

    }
}

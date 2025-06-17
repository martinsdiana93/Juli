using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public enum Dificuldade { Facil, Medio, Dificil }

    public Dificuldade dificuldadeAtual;
    public WordGameDif wordGameDif; // Refer�ncia ao script que tem as listas de jogos

    private int indiceAtual = 0;

    public GameObject botaoAvancar; // Bot�o "Avan�ar n�vel", que ser� desativado no fim

    public void IniciarJogo(Dificuldade dificuldade)
    {
        dificuldadeAtual = dificuldade;
        indiceAtual = 0;
        AtivarNivelAtual();
    }

    public void AvancarNivel()
    {
        indiceAtual++;

        // Verifica se j� chegou ao fim
        if (indiceAtual >= ObterListaAtual().Count)
        {
            Debug.Log("�ltimo n�vel atingido.");
            botaoAvancar.SetActive(false); // Esconde o bot�o
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

        Debug.Log("Dificuldade atual: " + dificuldadeAtual + " | N�vel: " + indiceAtual);
        botaoAvancar.SetActive(indiceAtual < lista.Count - 1); // Esconde se for o �ltimo
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
        // Obt�m lista atual da dificuldade
        List<WordGame> lista = ObterListaAtual();

        // Desativa todos os jogos
        foreach (WordGame jogo in lista)
        {
            jogo.gameObject.SetActive(false);
        }

        // Escolhe outro jogo aleat�rio
        int novoIndice = Random.Range(0, lista.Count);
        indiceAtual = novoIndice;

        // Ativa e inicia o novo jogo
        lista[indiceAtual].gameObject.SetActive(true);
        lista[indiceAtual].StartGame();

    }
}

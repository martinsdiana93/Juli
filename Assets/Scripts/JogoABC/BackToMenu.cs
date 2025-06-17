using UnityEngine;
using System.Collections.Generic;

public class BackToMenu : MonoBehaviour
{
    public GameObject menuInicial;     // Referência ao menu inicial
    public List<GameObject> jogos;     // Lista de todos os jogos possíveis

    public void VoltarMenu()
    {
        // Desativa todos os jogos (caso algum esteja ativo)
        foreach (GameObject jogo in jogos)
        {
            jogo.SetActive(false);
        }

        // Ativa o menu inicial
        menuInicial.SetActive(true);
    }
}

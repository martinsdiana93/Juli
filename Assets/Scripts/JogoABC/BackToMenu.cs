using UnityEngine;
using System.Collections.Generic;

public class BackToMenu : MonoBehaviour
{
    public GameObject menuInicial;     // Refer�ncia ao menu inicial
    public List<GameObject> jogos;     // Lista de todos os jogos poss�veis

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

using UnityEngine;


public class SelecionarNiveis : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject jogoBackground;
    public int nivelSelecionado;

    public void CarregarNivel(int nivel)
    {
        nivelSelecionado = nivel;
        menuInicial.SetActive(false);
        jogoBackground.SetActive(true);

        // Iniciar lógica do jogo (opcional)
        FindFirstObjectByType<JogoCoposController>()?.IniciarNivel(nivelSelecionado);
    }
}


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudarNivel : MonoBehaviour
{
    public GameObject nivelFacil;
    public GameObject nivelMedio;
    public GameObject nivelDificil;
    
    public Button botaoProximoNivel;
    private int nivelAtual = 0;


    void Start()
    {
        // Ao iniciar, desativa todos os níveis (ou ativa só um)
        DesativarTodosOsNiveis();
    }

    public void AtivarFacil()
    {
        DesativarTodosOsNiveis();
        nivelFacil.SetActive(true);
        nivelFacil.GetComponent<Jogo_Pares>()?.ReplayNivel(); // reinicia
    }

    public void AtivarMedio()
    {
        DesativarTodosOsNiveis();
        nivelMedio.SetActive(true);
        nivelMedio.GetComponent<Jogo_Pares>()?.ReplayNivel();
    }

    public void AtivarDificil()
    {
        DesativarTodosOsNiveis();
        nivelDificil.SetActive(true);
        nivelDificil.GetComponent<Jogo_Pares>()?.ReplayNivel();
    }

    public void DesativarTodosOsNiveis()
    {
        nivelFacil.SetActive(false);
        nivelMedio.SetActive(false);
        nivelDificil.SetActive(false);
    }

    public void NextLevel()
    {
        // Desativa o nível atual
        if (nivelAtual == 0) nivelFacil.SetActive(false);
        else if (nivelAtual == 1) nivelMedio.SetActive(false);
        else if (nivelAtual == 2) nivelDificil.SetActive(false);

        nivelAtual++;

        if (nivelAtual == 1)
        {
            nivelMedio.SetActive(true);
            nivelMedio.GetComponent<Jogo_Pares>()?.ReplayNivel();
        }
        else if (nivelAtual == 2)
        {
            nivelDificil.SetActive(true);
            nivelDificil.GetComponent<Jogo_Pares>()?.ReplayNivel();

            // Desativa o botão "Próximo Nível" porque estamos no último nível
            if (botaoProximoNivel != null)
            {
                botaoProximoNivel.interactable = false;
            }
        }
        else
        {
            Debug.Log("Já não há mais níveis.");
        }
    }

    public void ReplayNivelAtual()
    {
        if (nivelAtual == 0)
            nivelFacil.GetComponent<Jogo_Pares>()?.ReplayNivel();
        else if (nivelAtual == 1)
            nivelMedio.GetComponent<Jogo_Pares>()?.ReplayNivel();
        else if (nivelAtual == 2)
            nivelDificil.GetComponent<Jogo_Pares>()?.ReplayNivel();
    }
}

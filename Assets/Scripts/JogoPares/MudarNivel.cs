using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MudarNivel : MonoBehaviour
{
    public GameObject nivelFacil;
    public GameObject nivelMedio;
    public GameObject nivelDificil;

    void Start()
    {
        // Ao iniciar, desativa todos os n�veis (ou ativa s� um)
        DesativarTodosOsNiveis();
    }

    public void AtivarFacil()
    {
        DesativarTodosOsNiveis();
        nivelFacil.SetActive(true);
    }

    public void AtivarMedio()
    {
        DesativarTodosOsNiveis();
        nivelMedio.SetActive(true);
    }

    public void AtivarDificil()
    {
        DesativarTodosOsNiveis();
        nivelDificil.SetActive(true);
    }

    private void DesativarTodosOsNiveis()
    {
        nivelFacil.SetActive(false);
        nivelMedio.SetActive(false);
        nivelDificil.SetActive(false);
    }
}

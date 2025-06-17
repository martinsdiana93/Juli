using UnityEngine;

public class JogoMatController : MonoBehaviour
{
    public GameObject menuInicial;

    public GameObject jogo1;
    public GameObject jogo2;
    public GameObject jogo3;

    void Start()
    {
        // Ao iniciar, mostra apenas o menu e esconde os jogos
        menuInicial.SetActive(true);
        jogo1.SetActive(false);
        jogo2.SetActive(false);
        jogo3.SetActive(false);
    }

    public void IniciarJogo1()
    {
        AtivarJogo(jogo1);
    }

    public void IniciarJogo2()
    {
        AtivarJogo(jogo2);
    }

    public void IniciarJogo3()
    {
        AtivarJogo(jogo3);
    }

    private void AtivarJogo(GameObject jogoSelecionado)
    {
        menuInicial.SetActive(false);

        jogo1.SetActive(false);
        jogo2.SetActive(false);
        jogo3.SetActive(false);

        jogoSelecionado.SetActive(true);
    }
}

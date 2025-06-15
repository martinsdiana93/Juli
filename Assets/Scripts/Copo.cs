using UnityEngine;

public class Copo : MonoBehaviour
{
    public GameObject copoFechado;
    public GameObject copoAbertoComMirtilo;
    public GameObject copoAbertoVazio;

    public JogoCoposController controlador = null;

    public bool temMirtilo = false;

    public void ClickCup()
    {
        controlador.JogadorEscolheu(this);
    }

    public void Revelar()
    {
        copoFechado.SetActive(false);

        if (temMirtilo)
            copoAbertoComMirtilo.SetActive(true);
        else
            copoAbertoVazio.SetActive(true); // aqui tenho que rever o script 
    }

    public void Esconder()
    {
        copoFechado.SetActive(true);
        copoAbertoComMirtilo.SetActive(false);
        copoAbertoVazio.SetActive(false);
    }

    public void Resetar()
    {
        Esconder();
        temMirtilo = false;
    }

    public void MostrarComMirtilo()
    {
        copoFechado.SetActive(false);
        copoAbertoComMirtilo.SetActive(true);
    }

    public void MostrarVazio()
    {
        copoFechado.SetActive(false);
        copoAbertoVazio.SetActive(true);
    }

}

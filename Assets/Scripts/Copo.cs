using UnityEngine;

public class Copo : MonoBehaviour
{
    public GameObject copoFechado;
    public GameObject copoAbertoComMirtilo;
    public GameObject copoAbertoVazio;

    public bool temMirtilo = false;

    public void Revelar()
    {
        copoFechado.SetActive(false);

        if (temMirtilo)
            copoAbertoComMirtilo.SetActive(true);
        else
            copoAbertoVazio.SetActive(true); // aqui tenho que rever o script 
    }

    public void Resetar()
    {
        copoFechado.SetActive(true);
        copoAbertoComMirtilo.SetActive(false);
        copoAbertoVazio.SetActive(false);
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

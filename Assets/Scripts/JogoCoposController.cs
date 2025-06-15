using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JogoCoposController : MonoBehaviour
{
    public List<Copo> copos; // Atribuir no Inspector (esquerda, meio, direita)
    public int trocasPorNivel = 3; // muda conforme nível
    private Copo copoComMirtilo;
    private bool podeClicar = false;

    public void IniciarNivel(int nivel)
    {
        trocasPorNivel = nivel switch
        {
            1 => 3,
            2 => 5,
            3 => 9,
            _ => 3
        };

        copoComMirtilo = copos[Random.Range(0, copos.Count)];
        StartCoroutine(EmbaralharCopos());
    }

    IEnumerator EmbaralharCopos()
    {
        podeClicar = false;

        for (int i = 0; i < trocasPorNivel; i++)
        {
            int a = Random.Range(0, copos.Count);
            int b = Random.Range(0, copos.Count);

            while (a == b) b = Random.Range(0, copos.Count);

            // Troca posições
            Vector3 posA = copos[a].transform.position;
            copos[a].transform.position = copos[b].transform.position;
            copos[b].transform.position = posA;

            yield return new WaitForSeconds(0.5f); // tempo entre trocas aqui preciso de adicionar 
        }

        podeClicar = true;
    }

    public void JogadorEscolheu(Copo escolhido)
    {
        if (!podeClicar) return;

        podeClicar = false;

        if (escolhido == copoComMirtilo)
        {
            escolhido.MostrarComMirtilo();
        }
        else
        {
            escolhido.MostrarVazio();
            copoComMirtilo.MostrarComMirtilo(); // mostra o certo também
        }
    }
}

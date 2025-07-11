using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JogoCoposController : MonoBehaviour
{
    public List<Copo> copos; // Atribuir no Inspector (esquerda, meio, direita)
    public int trocasPorNivel = 3; // muda conforme nível
    public int trocasActuais = 0;
    public Copo copoComMirtilo;
    public bool podeClicar = false;
    public float tradeSpeed = 1.0f;
    public int nivelActual = 0;
    public bool revealOthers = false;
    public bool revealOthersDone = false;
    public float tickReveal = 0f;
    public Copo revealedCup = null;

    public bool tradeStart = false;
    public float tickStart = 0f;

    public GameObject tradeCupA = null;
    public Vector3 tradeCupA_Start = Vector3.zero;
    public Vector3 tradeCupA_End = Vector3.zero;
    public GameObject tradeCupB = null;
    public Vector3 tradeCupB_Start = Vector3.zero;
    public Vector3 tradeCupB_End = Vector3.zero;
    public bool tradeCups = false;
    public float tickTrade = 0f;

    public GameObject popUpErrado;
    public GameObject popUpCerto;
    public FinalSceneManagerJogoCopos sceneManager;

    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound; 

    public void IniciarNivel()
    {
        IniciarNivel(nivelActual);
    }
    public void IniciarNivel(int nivel)
    {
        nivelActual = nivel;
        trocasActuais = 0;
        switch (nivel)
        {
            case 1:
                trocasPorNivel = 3;
                tradeSpeed = 0.8f;
                break;
            case 2:
                trocasPorNivel = 5;
                tradeSpeed = 0.65f;
                break;
            case 3:
                trocasPorNivel = 9;
                tradeSpeed = 0.5f;
                break;
        }

        copoComMirtilo = copos[Random.Range(0, copos.Count)];
        copoComMirtilo.temMirtilo = true;
        foreach (Copo cup in copos)
        {
            cup.Revelar();
        }
        tradeStart = true;
        tickStart = 0f;
        tickReveal = 0f;
    }

    public void Update()
    {
        if (tradeStart)
        {
            tickStart += Time.deltaTime;
            if (tickStart >= 2f)
            {
                foreach (Copo cup in copos) { cup.Esconder(); }
                tradeStart = false;
                Pick2Cups();
            }
        }
        if (tradeCups)
        {
            tickTrade += Time.deltaTime / tradeSpeed;
            tradeCupA.transform.position = Vector3.Lerp(tradeCupA_Start, tradeCupA_End, tickTrade);
            tradeCupB.transform.position = Vector3.Lerp(tradeCupB_Start, tradeCupB_End, tickTrade);
            if(tickTrade >= 1f)
            {
                trocasActuais++;
                tradeCups = false;
                if (trocasActuais < trocasPorNivel) { Pick2Cups(); } else { podeClicar = true; }
            }
        }
        if (revealOthers)
        {
            tickReveal += Time.deltaTime;
            if (tickReveal >= 0.5f && !revealOthersDone)
            {
                revealOthersDone = true;
                foreach (Copo cup in copos)
                {
                    if (cup != revealedCup)
                    {
                        cup.Revelar();
                    }
                }
            }
            if (tickReveal >= 1f)
            {
                popUpCerto.SetActive(Contar_Pontos.lastCorrect);
                popUpErrado.SetActive(Contar_Pontos.lastWrong);
            }
            if (tickReveal > 2f)
            {
                revealOthers = false;
                revealOthersDone = false;
                popUpCerto.SetActive(false);
                popUpErrado.SetActive(false);
                foreach (Copo cup in copos)
                {
                    cup.Resetar();
                }
                if (Contar_Pontos.CheckGameEnd()) sceneManager.EndGame();
                else IniciarNivel();
            }
        }
    }

    public void Pick2Cups()
    {
        int a = Random.Range(0, copos.Count);
        int b = Random.Range(0, copos.Count);

        while (a == b) b = Random.Range(0, copos.Count);
        tradeCupA = copos[a].gameObject;
        tradeCupB = copos[b].gameObject;
        tradeCupA_Start = tradeCupA.transform.position;
        tradeCupA_End = tradeCupB.transform.position;
        tradeCupB_Start = tradeCupB.transform.position;
        tradeCupB_End = tradeCupA.transform.position;
        tickTrade = 0f;
        tickStart = 0f;
        tradeCups = true;
    }

    public void JogadorEscolheu(Copo escolhido)
    {
        if (!podeClicar) return;

        podeClicar = false;
        escolhido.Revelar();
        if (copoComMirtilo == escolhido)
        {
            // Ganhaste!
            revealOthers = true;
            revealedCup = escolhido;
            Contar_Pontos.IncrementRightAnswer();
            correctSound.Play(); 

        } else
        {
            // Perdeste
            revealOthers = true;
            revealedCup = escolhido;
            Contar_Pontos.IncrementWrongAnswer();
            wrongSound.Play(); 
        }
    }

    public void ResetarCenas()
    {
    foreach (Copo cup in copos)
    {
        cup.Resetar();
        cup.ResetarPosicao();
    }
    copoComMirtilo = null;
    podeClicar = false;
    tradeStart = false;
    tradeCups = false;
    revealOthers = false;
    revealOthersDone = false;
    tickReveal = 0f;
    tickStart = 0f;
    tickTrade = 0f;

    popUpCerto.SetActive(false);
    popUpErrado.SetActive(false);

    Contar_Pontos.lastCorrect = false;
    Contar_Pontos.lastWrong = false;
    }
}

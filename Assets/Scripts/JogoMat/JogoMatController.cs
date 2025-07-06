using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JogoMatController : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject final_popup;
    public Button next_game_button;
    
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;

    public int current_game = 0;

    public GameObject jogo1;
    public GameObject jogo2;
    public GameObject jogo3;
    public List<Puzzle> puzzle_pieces = new List<Puzzle>();
    public List<DropPieces> drop_pieces = new List<DropPieces>();

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
        current_game = 1;
        AtivarJogo(jogo1);
    }

    public void IniciarJogo2()
    {
        current_game = 2;
        AtivarJogo(jogo2);
    }

    public void IniciarJogo3()
    {
        current_game = 3;
        AtivarJogo(jogo3);
    }

    private void AtivarJogo(GameObject jogoSelecionado)
    {
        //menuInicial.SetActive(false);
        desactivar_jogos();
        jogoSelecionado.SetActive(true);
    }

    public void desactivar_jogos(){
        final_popup.SetActive(false);
        jogo1.SetActive(false);
        jogo2.SetActive(false);
        jogo3.SetActive(false);
        foreach(Puzzle pp in puzzle_pieces){
            pp.gameObject.SetActive(true);
            if(pp.started) {pp.ResetImage();}
        }
        foreach(DropPieces dp in drop_pieces){
            dp.toggle_alpha(true);
            DropPieces.contadorPecasRestantes = dp.numeroTotalDePecas;
        }
    }

    public void win_game(){
        desactivar_jogos();
        final_popup.SetActive(true);
        next_game_button.interactable = (current_game != 3);
    }

    public void next_game(){
        if (current_game < 3) {current_game++;}
        repeat_game();
    }

    public void repeat_game(){
        desactivar_jogos();
        switch(current_game){
            case 1: IniciarJogo1(); break;
            case 2: IniciarJogo2(); break;
            case 3: IniciarJogo3(); break;
        }
    }

    public void play_sound(string option){
        switch(option){
            case "correct": correctSound.Play(); break;
            default: wrongSound.Play(); break;
        }
    }
}

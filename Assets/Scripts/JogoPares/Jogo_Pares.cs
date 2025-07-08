using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Jogo_Pares : MonoBehaviour
{

    public List<Piece> pieces_list = new List<Piece>();

    public Piece myPiece = null;

    public GameObject win_screen = null;

    [SerializeField] private AudioSource correctSound;
    
    [SerializeField] private AudioSource wrongSound;    

    public void PickPiece(Piece selected_piece)
    {
        // Impede que peças com overlap sejam selecionadas
        if (selected_piece.has_overlap())
        {
            Debug.Log("Peça bloqueada, não pode ser selecionada.");
            return;
        }

        if (myPiece == null)
        {
            myPiece = selected_piece;
            myPiece.piece_highlighted.SetActive(true);
        }

        else
        {
            if (myPiece.piece_name == selected_piece.piece_name && myPiece != selected_piece && !selected_piece.piece_disabled.activeSelf)
            {
                myPiece.gameObject.SetActive(false);
                selected_piece.gameObject.SetActive(false);                
                myPiece = null;
                update_pieces();
                correctSound.Play(); 
            }
            else
            {
                myPiece.piece_highlighted.SetActive(false);
                selected_piece.piece_highlighted.SetActive(false);
                myPiece = null;
                wrongSound.Play(); 
            }
        }
    }
        
    public void update_pieces()
    {
        int active_pieces = 0;
        foreach (Piece piece in pieces_list)
        {
            if (piece.gameObject.activeSelf) { active_pieces++; }
            piece.piece_disabled.SetActive(piece.has_overlap());
        }

        if (active_pieces == 0)
        {
            win_screen.SetActive(true);
        }
    }

    public void ReplayNivel()
    {
        foreach (Piece piece in pieces_list)
    {
        piece.gameObject.SetActive(true);
        if (piece.piece_highlighted != null)
            piece.piece_highlighted.SetActive(false);
        if (piece.piece_disabled != null)
            piece.piece_disabled.SetActive(false);
    }

    myPiece = null;

    if (win_screen != null)
        win_screen.SetActive(false);

    update_pieces();
    }
}

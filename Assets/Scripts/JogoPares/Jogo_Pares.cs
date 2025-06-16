using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Jogo_Pares : MonoBehaviour
{

    public List<Piece> pieces_list = new List<Piece>();

    public Piece myPiece = null;

    public GameObject win_screen = null;

    private void Start()
    {
        update_pieces();
    }

    public void PickPiece(Piece selected_piece)
    {
        if (selected_piece.piece_disabled.activeSelf == true) { return; }
        if (myPiece == selected_piece) { return; }

        if (myPiece == null)
        {
            myPiece = selected_piece;
            myPiece.piece_highlighted.SetActive(true);
        }

        else
        {
            if (myPiece.piece_name == selected_piece.piece_name)
            {
                myPiece.gameObject.SetActive(false);
                selected_piece.gameObject.SetActive(false);
                myPiece = null;
                update_pieces();
            }
            else
            {
                myPiece.piece_highlighted.SetActive(false);
                selected_piece.piece_highlighted.SetActive(false);
                myPiece = null;
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
}

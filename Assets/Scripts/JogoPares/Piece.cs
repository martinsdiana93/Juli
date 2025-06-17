using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Piece : MonoBehaviour
{
    public int piece_position = 0;

    public string piece_name = "";

    public GameObject piece_highlighted = null;

    public GameObject piece_disabled = null;

    public Jogo_Pares jogo_pares = null;

    public List<GameObject> overlaps = new List<GameObject> ();

    public void OnButtonClick() 
    {
        jogo_pares.PickPiece(this);
    }

    public bool has_overlap()
    {
        foreach (GameObject overlapper in overlaps)
        {
            if (overlapper.activeSelf) { return true; }
        }
        return false;
    }  
}

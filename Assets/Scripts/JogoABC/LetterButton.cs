using UnityEngine;
using System.Collections.Generic;

public class LetterButton : MonoBehaviour
{
    public char letter = 'a';
    public WordGame wordGame;

    public void onclick()
    {
        wordGame.PickLetter(this);
    }  
}

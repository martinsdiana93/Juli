using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public MainCharacter mc = null;
    public GameObject game_window = null;
    
    public void start_game(){
        if (mc.happiness <= 0) {return;}
        game_window.SetActive(true);
    }
}

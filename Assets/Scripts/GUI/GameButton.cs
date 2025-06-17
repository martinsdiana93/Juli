using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public MainCharacter mc = null;
    public GameObject game_window = null;
    public MainHUD mh = null;

    public void start_game(){
        if (mc.happiness <= 0) {return;}
        mh.game_cost();
        mc.gameObject.SetActive(false);
        mh.change_activity(MainHUD.ActivityType.Game);
        game_window.SetActive(true);
    }
}

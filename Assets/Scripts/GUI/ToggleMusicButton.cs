using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicButton : MonoBehaviour
{
    public MainHUD main_hud;
    public Sprite music_on;
    public Sprite music_off;
    public Image button_image;

    public void click_toggle(){
        main_hud.music_enabled = !main_hud.music_enabled;
        main_hud.update_music();
        foreach(ToggleMusicButton tmb in main_hud.toggle_music_buttons){
            tmb.update_image();
        }
    }

    public void update_image(){
        button_image.sprite = main_hud.music_enabled ? music_on : music_off;
    }
}

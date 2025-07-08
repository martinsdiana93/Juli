using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainCharacter : MonoBehaviour
{
    public int hygiene = 100;
    public int food = 100;
    public int thirst = 100;
    public int energy = 100;

    public Image char_image = null;

    // Sprites
    public Sprite neutral_sprite;
    public Sprite shower_sprite;
    public Sprite sleeping_on_sprite;
    public Sprite sleeping_off_sprite;
    public Sprite happy_sprite;
    public Sprite sad_sprite;

    // Positions
    public Vector2 neutral_position;
    public Vector2 eating_position;
    public Vector2 drinking_position;
    public Vector2 shower_position;
    public Vector2 sleeping_position;

    public int happiness {
        get{
            return (int)(Mathf.Clamp(((hygiene+food+thirst+energy)/4), 0, 100));
        }
    }

    public void shower(){
        hygiene = Mathf.Clamp(hygiene + 50, 0, 100);
    }

    public void eat(bool healthy){
        food = Mathf.Clamp(food + (healthy? 50 : 20), 0, 100);
        change_character_sprite(healthy ? "happy" : "sad");
        change_character_position("eat");
    }

    public void drink(bool healthy){
        thirst = Mathf.Clamp(thirst + (healthy? 50 : 20), 0, 100);
        change_character_sprite(healthy ? "happy" : "sad");
    }

    public void sleep(){
        energy = Mathf.Clamp(energy + 50, 0, 100);
        change_character_sprite("sleep_off");
    }

    public void change_character_sprite(string new_sprite){
        switch(new_sprite){
            case "shower": char_image.sprite = shower_sprite; break;
            case "sleep_on": char_image.sprite = sleeping_on_sprite; break;
            case "sleep_off": char_image.sprite = sleeping_off_sprite; break;
            case "happy": char_image.sprite = happy_sprite; break;
            case "sad": char_image.sprite = sad_sprite; break;
            default: char_image.sprite = neutral_sprite; break;

        }
    }

    public void change_character_position(string new_position){
        switch(new_position){
            case "eat": gameObject.transform.localPosition = eating_position; break;
            case "drink": gameObject.transform.localPosition = drinking_position; break;
            case "shower": gameObject.transform.localPosition = shower_position; break;
            case "sleep": gameObject.transform.localPosition = sleeping_position; break;
            default: gameObject.transform.localPosition = neutral_position; break;
        }
    }
}

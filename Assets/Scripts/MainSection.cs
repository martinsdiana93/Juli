using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainHUD : MonoBehaviour
{
    // Main Info
    public GameObject buttons = null;
    public MainCharacter mc = null;
    public int game_cost_amount = 20;

    // Activity Screens
    public ActivityScreen screen_shower = null;
    public GameObject screen_showerObject = null;
    public ActivityScreen screen_eat = null;
    public GameObject screen_eatObject = null;
    public ActivityScreen screen_drink = null;
    public GameObject screen_drinkObject = null;
    public ActivityScreen screen_sleep = null;
    public GameObject screen_sleepObject = null;

    // Needs
    public Image hygiene = null;
    public Image food = null;
    public Image thirst = null;
    public Image energy = null;
    public Image happiness_bar = null;

    // Timeouts
    public float timeout_time = 600.0f;
    public float hygiene_timeout = 0.0f;
    public float food_timeout = 0.0f;
    public float thirst_timeout = 0.0f;
    public float energy_timeout = 0.0f;

    public float tick = 0.0f;
    public float tick_rate = 1.0f;

    public void Start(){
        update_needs();
    }

    public void Update(){
        if (hygiene_timeout > 0.0f) {hygiene_timeout -= Time.deltaTime;}
        if (food_timeout > 0.0f) {food_timeout -= Time.deltaTime;}
        if (thirst_timeout > 0.0f) {thirst_timeout -= Time.deltaTime;}
        if (energy_timeout > 0.0f) {energy_timeout -= Time.deltaTime;}

        tick += Time.deltaTime;
        if (tick >= tick_rate){
            tick -= tick_rate;
            deplete_needs();
            update_needs();
        }
    }

    public void deplete_needs(){
        switch(Random.Range(0,4)){
            case 0:
                mc.hygiene = Mathf.Clamp(mc.hygiene - 1, 0, 100);
                break;
            case 1:
                mc.food = Mathf.Clamp(mc.food - 1, 0, 100);
                break;
            case 2:
                mc.thirst = Mathf.Clamp(mc.thirst - 1, 0, 100);
                break;
            case 3:
                mc.energy = Mathf.Clamp(mc.energy - 1, 0, 100);
                break;
        }
    }

    public void change_activity(ActivityType new_at)
    {
        switch(new_at){
            case ActivityType.None:
                buttons.SetActive(true);
                screen_showerObject.SetActive(false);
                screen_eatObject.SetActive(false);
                screen_drinkObject.SetActive(false);
                screen_sleepObject.SetActive(false);
                break;
            case ActivityType.Shower:
                if(hygiene_timeout > 0.0f) {return;}
                buttons.SetActive(false);
                screen_showerObject.SetActive(true);
                screen_shower.pick_fact();
                screen_eatObject.SetActive(false);
                screen_drinkObject.SetActive(false);
                screen_sleepObject.SetActive(false);
                break;
            case ActivityType.Eat:
                if(food_timeout > 0.0f) {return;}
                buttons.SetActive(false);
                screen_showerObject.SetActive(false);
                screen_eatObject.SetActive(true);
                screen_eat.pick_clock_options();
                screen_drinkObject.SetActive(false);
                screen_sleepObject.SetActive(false);
                break;
            case ActivityType.Drink:
                if(thirst_timeout > 0.0f) {return;}
                buttons.SetActive(false);
                screen_showerObject.SetActive(false);
                screen_eatObject.SetActive(false);
                screen_drinkObject.SetActive(true);
                screen_drink.pick_fact();
                screen_sleepObject.SetActive(false);
                break;
            case ActivityType.Sleep:
                if(energy_timeout > 0.0f) {return;}
                buttons.SetActive(false);
                screen_showerObject.SetActive(false);
                screen_eatObject.SetActive(false);
                screen_drinkObject.SetActive(false);
                screen_sleepObject.SetActive(true);
                screen_sleep.pick_fact();
                break;
            case ActivityType.Game:
                buttons.SetActive(false);
                screen_showerObject.SetActive(false);
                screen_eatObject.SetActive(false);
                screen_drinkObject.SetActive(false);
                screen_sleepObject.SetActive(false);
                break;
        }
        update_needs();
    }

    public void update_needs(){
        // hygiene
        if (mc.hygiene <= 60){
            hygiene.enabled = true;
            if (mc.hygiene <= 30){
                hygiene.color = Color.red;
            } else {
                hygiene.color = Color.yellow;
            }
        }
        else {
            hygiene.enabled = false;
        }
        // food
        if (mc.food <= 60){
            food.enabled = true;
            if (mc.food <= 30){
                food.color = Color.red;
            } else {
                food.color = Color.yellow;
            }
        }
        else {
            food.enabled = false;
        }
        // thirst
        if (mc.thirst <= 60){
            thirst.enabled = true;
            if (mc.thirst <= 30){
                thirst.color = Color.red;
            } else {
                thirst.color = Color.yellow;
            }
        }
        else {
            thirst.enabled = false;
        }
        // energy
        if (mc.energy <= 60){
            energy.enabled = true;
            if (mc.energy <= 30){
                energy.color = Color.red;
            } else {
                energy.color = Color.yellow;
            }
        }
        else {
            energy.enabled = false;
        }

        // Happiness
        RectTransform rt = happiness_bar.GetComponent<RectTransform>();
        int truncate_value = Mathf.CeilToInt(mc.happiness / 10)*10;
        rt.sizeDelta = new Vector2(truncate_value * 5, rt.sizeDelta.y);

        if (mc.happiness <= 60){
            if (mc.happiness <= 30){
                happiness_bar.color = Color.red;
            } else {
                happiness_bar.color = Color.yellow;
            }
        }
        else {
            happiness_bar.color = Color.green;
        }
    }

    public void game_cost(){
        List<string> choices = new List<string>();
        if (mc.hygiene >= game_cost_amount) {choices.Add("hygiene");}
        if (mc.food >= game_cost_amount) {choices.Add("food");}
        if (mc.thirst >= game_cost_amount) {choices.Add("thirst");}
        if (mc.energy >= game_cost_amount) {choices.Add("energy");}

        if (choices.Count <= 0) {return;}
        lower_needs(choices[Random.Range(0,choices.Count)]);
    }

    public void lower_needs(string need){
        switch(need){
            case "hygiene":
                mc.hygiene -= game_cost_amount;
                break;
            case "food":
                mc.food -= game_cost_amount;
                break;
            case "thirst":
                mc.thirst -= game_cost_amount;
                break;
            case "energy":
                mc.energy -= game_cost_amount;
                break;
        }
        update_needs();
    }

    public enum ActivityType{
        None,
        Shower,
        Eat,
        Drink,
        Sleep,
        Game
    }
}

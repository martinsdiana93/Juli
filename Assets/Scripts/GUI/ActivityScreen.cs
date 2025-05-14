using UnityEngine;
using UnityEngine.UI;

public class ActivityScreen : MonoBehaviour
{
	public MainHUD mh = null;
	public TMPro.TextMeshProUGUI text = null;
    public string[] facts = new string[0];
	public MainHUD.ActivityType at = MainHUD.ActivityType.None;

	// Choice Based
	public bool choices = false;
	public GameObject choice_object = null;
	public GameObject return_button = null;
	public int good_choice = 0;
	public Image choice_1 = null;
	public Image choice_2 = null;
	public Sprite[] good_choices = new Sprite[0];
	public Sprite[] bad_choices = new Sprite[0];


	public void pick_fact(){
		if (choices && (good_choices.Length > 0 && bad_choices.Length > 0)) {
			choice_object.SetActive(true);
			return_button.SetActive(false);
			switch(Random.Range(0,2)){
				case 0:
					good_choice = 0;
					choice_1.sprite = good_choices[Random.Range(0,good_choices.Length)];
					choice_2.sprite = bad_choices[Random.Range(0,bad_choices.Length)];
					break;
				case 1:
					good_choice = 1;
					choice_1.sprite = bad_choices[Random.Range(0,bad_choices.Length)];
					choice_2.sprite = good_choices[Random.Range(0,good_choices.Length)];
					break;
			}
		} else {
			choice_object.SetActive(false);
			return_button.SetActive(true);
		}

		if (facts.Length < 0){
			text.text = "Não há factos!";
			return;
		}
		text.text = facts[Random.Range(0, facts.Length)];
	}

	public void click_option(int op){
		switch(at){
			case MainHUD.ActivityType.Shower:
                mh.hygiene_timeout += mh.timeout_time;
                mh.mc.shower();
                break;
            case MainHUD.ActivityType.Eat:
                mh.food_timeout += mh.timeout_time;
                mh.mc.eat(op == good_choice);
                break;
            case MainHUD.ActivityType.Drink:
                mh.thirst_timeout += mh.timeout_time;
                mh.mc.drink(op == good_choice);
                break;
            case MainHUD.ActivityType.Sleep:
                mh.energy_timeout += mh.timeout_time;
                mh.mc.sleep();
                break;
		}
		mh.change_activity(MainHUD.ActivityType.None);
	}
}

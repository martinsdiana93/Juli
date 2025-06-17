using UnityEngine;
using UnityEngine.UI;

public class ActivityScreen : MonoBehaviour
{
	public MainHUD mh = null;
	public TMPro.TextMeshProUGUI text = null;
    public string[] facts = new string[0];
	public MainHUD.ActivityType at = MainHUD.ActivityType.None;

    // Choice Based
    public bool automaticTransition = true;
	public bool choices = false;
	public GameObject choice_object = null;
	public GameObject return_button = null;
	public int good_choice = 0;
	public Image choice_1 = null;
	public Image choice_2 = null;
	public Sprite[] good_choices = new Sprite[0];
	public Sprite[] bad_choices = new Sprite[0];

	// Clock Based
	public string current_meal = "";
	public bool clockAnimStart = false;
    public bool clockAnimEnd = false;
    public float clockTick = 0.0f;
	public GameObject clockDisplay = null;
	public GameObject clockChoice1 = null;
    public Sprite clockDisplay1 = null;
    public Sprite[] clockGoodChoices1 = new Sprite[0];
    public Sprite[] clockBadChoices1 = new Sprite[0];
	public GameObject clockChoice2 = null;
    public Sprite clockDisplay2 = null;
    public Sprite[] clockGoodChoices2 = new Sprite[0];
    public Sprite[] clockBadChoices2 = new Sprite[0];
    public GameObject clockChoice3 = null;
    public Sprite clockDisplay3 = null;
    public Sprite[] clockGoodChoices3 = new Sprite[0];
    public Sprite[] clockBadChoices3 = new Sprite[0];
    public GameObject clockChoice4 = null;
    public Sprite clockDisplay4 = null;
    public Sprite[] clockGoodChoices4 = new Sprite[0];
    public Sprite[] clockBadChoices4 = new Sprite[0];
	public GameObject wrongChoice = null;

    // Clock Defines
    Vector3 clockStartPos = new Vector3(-590, 139, 0);
    Vector3 clockEndPos = new Vector3(-496, -30, 0);
    Vector3 clockStartRot = new Vector3(0, -65.355f, 0);
    Vector3 clockEndRot = new Vector3(0, 0, 0);
    Vector3 clockStartScale = new Vector3(0.2845881f, 0.2845881f, 0.2845881f);
    Vector3 clockEndScale = new Vector3(0.8915734f, 0.8915734f, 0.8915734f);

    public void pick_fact()
	{
        pick_fact(good_choices, bad_choices);
    }
    public void pick_fact(Sprite[] goodChoices, Sprite[] badChoices)
    {
		if (choices && (goodChoices.Length > 0 && badChoices.Length > 0)) {
			choice_object.SetActive(true);
			return_button.SetActive(false);
			switch(Random.Range(0,2)){
				case 0:
					good_choice = 0;
					choice_1.sprite = goodChoices[Random.Range(0,goodChoices.Length)];
					choice_2.sprite = badChoices[Random.Range(0, badChoices.Length)];
					break;
				case 1:
					good_choice = 1;
					choice_1.sprite = badChoices[Random.Range(0, badChoices.Length)];
					choice_2.sprite = goodChoices[Random.Range(0,goodChoices.Length)];
					break;
			}
		} else {
			//choice_object.SetActive(false);
			return_button.SetActive(true);
		}

		if (facts.Length < 0){
			text.text = "Não há factos!";
			return;
		}
		text.text = facts[Random.Range(0, facts.Length)];
	}

	public void pick_clock_options()
	{
        // Clock Animation
        clockAnimStart = true;
        clockTick = -1.0f;
        clockDisplay.SetActive(true);
        clockDisplay.transform.localPosition = clockStartPos;
        clockDisplay.transform.localEulerAngles = clockStartRot;
        clockDisplay.transform.localScale = clockStartScale;
        // Pick Random Time
        switch (Random.Range(0, 4))
		{
			case 0:
				current_meal = "breakfast";
                clockDisplay.GetComponent<Image>().sprite = clockDisplay1;
                break;
			case 1:
                current_meal = "lunch";
                clockDisplay.GetComponent<Image>().sprite = clockDisplay2;
                break;
            case 2:
                current_meal = "brunch";
                clockDisplay.GetComponent<Image>().sprite = clockDisplay3;
                break;
            case 3:
                current_meal = "dinner";
                clockDisplay.GetComponent<Image>().sprite = clockDisplay4;
                break;
        }
        clockChoice1.SetActive(false);
        clockChoice2.SetActive(false);
        clockChoice3.SetActive(false);
        clockChoice4.SetActive(false);
    }

    public void Update()
    {
        if (clockAnimStart){
            clockTick += Time.deltaTime/1;
            if(clockTick > 0)
            {
                clockDisplay.transform.localPosition = Vector3.Lerp(clockStartPos, clockEndPos, clockTick);
                clockDisplay.transform.localEulerAngles = Vector3.Lerp(clockStartRot, clockEndRot, clockTick);
                clockDisplay.transform.localScale = Vector3.Lerp(clockStartScale, clockEndScale, clockTick);
            }
            if (clockTick >= 1)
            {
                clockDisplay.transform.localPosition = clockEndPos;
                clockDisplay.transform.localEulerAngles = clockEndRot;
                clockDisplay.transform.localScale = clockEndScale;
                clockAnimStart = false;
                clockChoice1.SetActive(true);
                clockChoice2.SetActive(true);
                clockChoice3.SetActive(true);
                clockChoice4.SetActive(true);
            }
        }
        if (clockAnimEnd)
        {
            clockTick += Time.deltaTime / 1;
            clockDisplay.transform.localPosition = Vector3.Lerp(clockEndPos, clockStartPos, clockTick);
            clockDisplay.transform.localEulerAngles = Vector3.Lerp(clockEndRot, clockStartRot, clockTick);
            clockDisplay.transform.localScale = Vector3.Lerp(clockEndScale, clockStartScale, clockTick);
            if (clockTick >= 1)
            {
                clockAnimEnd = false;
                clockDisplay.transform.localPosition = clockStartPos;
                clockDisplay.transform.localEulerAngles = clockStartRot;
                clockDisplay.transform.localScale = clockStartScale;
                switch (current_meal)
                {
                    case "breakfast":
                        pick_fact(clockGoodChoices1, clockBadChoices1);
                        break;
                    case "lunch":
                        pick_fact(clockGoodChoices2, clockBadChoices2);
                        break;
                    case "brunch":
                        pick_fact(clockGoodChoices3, clockBadChoices3);
                        break;
                    case "diner":
                        pick_fact(clockGoodChoices4, clockBadChoices4);
                        break;
                }
            }
        }

    }

	public void pick_meal_option(string meal_option)
	{
		if (meal_option == current_meal)
        {
            clockTick = 0.0f;
            clockAnimEnd = true;
            clockChoice1.SetActive(false);
            clockChoice2.SetActive(false);
            clockChoice3.SetActive(false);
            clockChoice4.SetActive(false);
            wrongChoice.SetActive(false);
		}
		else
		{
            wrongChoice.SetActive(true);
        }
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
        if (automaticTransition)
        {
            mh.change_activity(MainHUD.ActivityType.None);
        }
	}
}

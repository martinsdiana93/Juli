using UnityEngine;
using UnityEngine.UI;

public class MealChoiceButton : MonoBehaviour
{
    public string mealType; // Ex: "breakfast", "lunch", etc.
    public GameObject normalVersion;
    public GameObject greyedVersion;
    public Button button;

    private ActivityScreen activityScreen;

    public void Init(ActivityScreen screen)
    {
        activityScreen = screen;
        ResetState(); // volta a mostrar versão normal
    }

    public void OnClick()
    {
        if (activityScreen != null)
        {
            activityScreen.pick_meal_option(mealType, this);
        }
    }

    public void SetGreyedOut()
    {
        normalVersion.SetActive(false);
        greyedVersion.SetActive(true);
        button.interactable = false;
    }

    public void ResetState()
    {
        normalVersion.SetActive(true);
        greyedVersion.SetActive(false);
        button.interactable = true;
    }
}

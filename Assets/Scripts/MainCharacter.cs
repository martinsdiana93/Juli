using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public int hygiene = 100;
    public int food = 100;
    public int thirst = 100;
    public int energy = 100;

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
    }

    public void drink(bool healthy){
        thirst = Mathf.Clamp(thirst + (healthy? 50 : 20), 0, 100);
    }

    public void sleep(){
        energy = Mathf.Clamp(energy + 50, 0, 100);
    }
}

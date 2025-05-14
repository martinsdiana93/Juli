using UnityEngine;

public class ActivityButton : MonoBehaviour
{
	public MainHUD mh = null;
    public MainCharacter mc = null;
    public MainHUD.ActivityType at;

    public void do_activity(){
        mh.change_activity(at);
    }
}

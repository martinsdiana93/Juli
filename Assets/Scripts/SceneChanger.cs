using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SceneChanger : MonoBehaviour
{
    public MainHUD mh = null;
    public List<GameObject> activities = new List<GameObject> ();
    public void LoadScene(string sceneName)
    {
        foreach (GameObject activity in activities) {
            activity.SetActive(false);
        }
        mh.mc.gameObject.SetActive(true);
        mh.change_activity(MainHUD.ActivityType.None);
    }
}

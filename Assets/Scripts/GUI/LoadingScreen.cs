using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image progress_bar = null;
    public float tick = 0f;
    public int time_loading = 0;
    public float fill_time = 5f;

    // Update is called once per frame
    void Update()
    {
        float tick_interval = fill_time / 10;
        tick += Time.deltaTime;
        if(tick > tick_interval){
            tick -= tick_interval;
            update_bar();
        }
    }

    private void update_bar(){
        time_loading++;
        RectTransform rt = progress_bar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2((time_loading+1) * 50, rt.sizeDelta.y);

        if (time_loading >= 10){
            gameObject.SetActive(false);
        }
    }
}

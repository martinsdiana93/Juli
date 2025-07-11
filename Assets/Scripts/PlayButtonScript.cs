using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public float scaleAmount = 1.1f;     // quanto aumenta
    public float speed = 2f;             // velocidade da pulsação
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * 0.05f; // 0.05 = intensidade
        transform.localScale = originalScale * scale;
    }
}

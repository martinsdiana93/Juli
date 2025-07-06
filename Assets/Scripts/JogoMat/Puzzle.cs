using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image targetImage;

    public Vector2 _startPosition = Vector2.zero;
    private RectTransform _rectTransform;
    private Canvas _myCanvas;
    public CanvasGroup _canvasGroup;
    public bool started = false;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.transform.localPosition;
        _myCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        started = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }

    public void ResetImage()
    {
        gameObject.GetComponent<RectTransform>().localPosition = _startPosition;
    }
}

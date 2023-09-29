using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    // Do not optimize this yet you absolute buffoon
    [SerializeField] public Canvas canvas;
    [SerializeField] public PuzzleInput puzzleInput;
    [SerializeField] public AspectBase aspect;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        GetComponent<Image>().sprite = aspect.tile.sprite;
    }
    public void OnPointerDown(PointerEventData eventData) { }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        puzzleInput.OnDragEnd(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;          
    [SerializeField] private Canvas _canvas; 
    private RectTransform _rectTransform;    
    private CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        startPosition = transform.position;        // запоминаем стартовую позицию
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false; // даём возможность дроп-зонам получать события
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        // Конвертируем позицию курсора в локальные UI-координаты родителя и двигаем объект
        Vector2 screenPos = Mouse.current.position.ReadValue();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform.parent as RectTransform,
                screenPos,
                _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera,
                out Vector2 localPoint))
        {
            _rectTransform.anchoredPosition = localPoint; // двигаем по anchoredPosition
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;  // возвращаем Raycast'ы
        transform.position = startPosition;
    }
}

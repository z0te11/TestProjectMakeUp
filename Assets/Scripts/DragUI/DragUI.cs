using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour,  IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private bool _isFollow;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = gameObject.transform.position;
    }

    private void OnEnable()
    {
        InteractUI.onSwitchedMakeUp += BackToStartPos;
    }

    private void OnDisable()
    {
        InteractUI.onSwitchedMakeUp -= BackToStartPos;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(30f, 0f, 0f);
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        BackToStartPos();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isFollow = true;
        Debug.Log(gameObject.ToString() + "Start Follow");
    }

    private void Update()
    {
        if (_isFollow)
        {
            FollowToCamera();
        }
    }

    private void FollowToCamera()
    {
        Vector2 mousePos = Input.mousePosition;
        _rectTransform.position = mousePos;
    }

    public void StopFollowToCamera()
    {
        BackToStartPos();
    }

    public void BackToStartPos()
    {
        _isFollow = false;
        gameObject.transform.position = _originalPosition;
    }
}

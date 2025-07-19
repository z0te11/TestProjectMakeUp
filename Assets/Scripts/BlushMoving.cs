using UnityEngine;

public class BlusMoving : MonoBehaviour
{
    private Vector2 _originalPosition;

    private void Awake()
    {
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

    public void MoveToNewPos(Vector2 newPos)
    {
        gameObject.transform.position = newPos + new Vector2(100f, -100f);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
    }

    public void BackToStartPos()
    {
        gameObject.transform.position = _originalPosition;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class MakeUpBlush : MakeUpComp
{
    [SerializeField] private BlusMoving _blushMove;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _blushMove.MoveToNewPos(this.transform.position);
    }
}

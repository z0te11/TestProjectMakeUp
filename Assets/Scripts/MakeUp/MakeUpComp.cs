using UnityEngine;
using UnityEngine.EventSystems;

public class MakeUpComp : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] protected MakeUpType _makeUp;
    [SerializeField] protected int _numberMakeUp;


    public virtual void OnPointerDown(PointerEventData eventData)
    {
        InteractUI.instance.SetNumberMakeUp(_numberMakeUp);
        InteractUI.instance.SetTypeMakeUp(_makeUp);
        InteractUI.instance.IsCanInteract(true);
    }
}

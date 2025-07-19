using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractUI : MonoBehaviour, IPointerDownHandler, IDropHandler
{
    public static Action onSwitchedMakeUp;
    public static InteractUI instance;
    private int numberMakeUp;
    private MakeUpType makeUpType;
    private bool isCanInteract = false;

    private MakeUpSwitcher[] _makeUpSwiychers;

    private void Awake()
    {
        if (instance == null) instance = this;
        _makeUpSwiychers = GetComponentsInChildren<MakeUpSwitcher>();
    }

    public void SetNumberMakeUp(int number)
    {
        numberMakeUp = number;
        Debug.Log("MakeUp Number " + number);
    }

    public void SetTypeMakeUp(MakeUpType makeUp)
    {
        makeUpType = makeUp;
        Debug.Log("MakeUp Type " + makeUp);
    }

    public void IsCanInteract(bool isCan)
    {
        isCanInteract = isCan;
        Debug.Log("Can interact " + isCan);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isCanInteract)
        {
            SwitchMakeUp();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && isCanInteract)
        {
            var makeUpComp = eventData.pointerDrag.GetComponent<MakeUpComp>();
            if (makeUpComp) SwitchMakeUp();
        }
    }

    private void SwitchMakeUp()
    {
        for (int i = 0; i < _makeUpSwiychers.Length; i++)
        {
            if (_makeUpSwiychers[i].makeUp == makeUpType)
            {
                _makeUpSwiychers[i].ChangeMakeUp(numberMakeUp);
                Debug.Log(makeUpType + numberMakeUp);
            }
        }
        onSwitchedMakeUp?.Invoke();
        IsCanInteract(false);
    }
}

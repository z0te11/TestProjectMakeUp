using System.Collections;
using System;
using UnityEngine;

public class TabsSwitcherController : MonoBehaviour
{
    public static Action<int> onTabSwitch;
    [SerializeField] private TabsSwitcher[] _tabs;

    private void Awake()
    {
        _tabs = GetComponentsInChildren<TabsSwitcher>();
    }

    public void Start()
    {
        ActiveTab(0);
    }

    public void ActiveTab(int numberTab)
    {
        for (int i = 0; i < _tabs.Length; i++)
        {
            _tabs[i].DeActiveTab();
            if (i == numberTab) _tabs[i].ActiveTab();
        }
        onTabSwitch?.Invoke(numberTab);
    }
}

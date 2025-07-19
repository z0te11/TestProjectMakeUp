using UnityEngine;

public class PanelTabController : MonoBehaviour
{
    [SerializeField] private GameObject[] _panelTabs;
    private GameObject _currentPanel;

    private void OnEnable()
    {
        TabsSwitcherController.onTabSwitch += ActivePanel;
    }

    private void OnDisable()
    {
        TabsSwitcherController.onTabSwitch -= ActivePanel;
    }
    private void ActivePanel(int numberPanel)
    {
        if (_currentPanel != null) Destroy(_currentPanel);
        _currentPanel = Instantiate(_panelTabs[numberPanel], this.gameObject.transform);
    } 
}

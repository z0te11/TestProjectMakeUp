using UnityEngine;
using UnityEngine.UI;

public class TabsSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite _activeImage;
    [SerializeField] private Sprite _deActiveImage;
    private Image _currentImage;

    private void Awake()
    {
        _currentImage = GetComponent<Image>();
    }
    public void ActiveTab()
    {
        _currentImage.sprite = _activeImage;
    }

    public void DeActiveTab()
    {
        _currentImage.sprite = _deActiveImage;
    }
}

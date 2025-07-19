using UnityEngine;
using UnityEngine.UI;

public class MakeUpSwitcher : MonoBehaviour
{
    public MakeUpType makeUp;
    [SerializeField] private Sprite[] _makeUpSprites;

    private Image _currnetImage;

    private void Awake()
    {
        _currnetImage = GetComponent<Image>();
    }

    public void ChangeMakeUp(int numberEye)
    {
        _currnetImage.sprite = _makeUpSprites[numberEye];
    }

}

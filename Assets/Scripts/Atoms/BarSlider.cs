using UnityEngine;
using UnityEngine.UI;
using UnityAtoms.BaseAtoms;

public class BarSlider : MonoBehaviour
{
    [SerializeField]
    private IntConstant MaxValue;
    [SerializeField]
    private Image barImage;

    public void ChangeFillAmount(int Amount)
    {
        barImage.fillAmount = 1.0f * Amount / MaxValue.Value;
    }
}
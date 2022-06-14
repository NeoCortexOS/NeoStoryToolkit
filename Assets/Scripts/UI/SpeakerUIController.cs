using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUIController : MonoBehaviour
{
    public TMP_Text dialog;
   
    public string Dialog
    {
        get { return dialog.text; }
        set { dialog.text = value; }
    }

      public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

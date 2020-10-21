using UnityEngine;
using UnityEngine.UI;

public class SongEditorBtn : MonoBehaviour
{
    private Color prevColor = Color.white;
    [SerializeField] private int value = 0;
    public Color HighColor = Color.black;
    public void SetDefaultColor(Color color)
    {

        prevColor = color;
        if (!(value > 0))
        {
            Image img = GetComponent<Image>();
            img.color = color;
        }

    }
    public int GetValue()
    { return value; }
    public void SetValue(int value)
    {
        this.value = value;
        if (value > 0) ValueHigh();
        else ValueLow();
    }

    private void ValueLow()
    {
        Image img = GetComponent<Image>();
        img.color = prevColor;
    }

    private void ValueHigh()
    {
        Image img = GetComponent<Image>();
        prevColor = img.color;
        img.color = HighColor;
    }

    public void Toggle()
    {
        if (value <= 0) SetValue(1);
        else SetValue(0);
    }
}

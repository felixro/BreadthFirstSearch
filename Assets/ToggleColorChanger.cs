using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleColorChanger : MonoBehaviour 
{
    public Color[] colors;

    Slider slider;
    Image sliderImage;

	void Start () 
    {
        slider = GetComponent<Slider>();
        sliderImage = GetComponentInChildren<Image>();
	}
	
    public void SetSliderColor(float value)
    {
        Color selectedColor = colors[(int)value-1];

        ColorBlock colorBlock = slider.colors;
        colorBlock.pressedColor = selectedColor;
        colorBlock.highlightedColor = selectedColor;
        slider.colors = colorBlock;

        sliderImage.color = selectedColor;
    }
}

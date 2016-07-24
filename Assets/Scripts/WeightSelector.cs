using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeightSelector : MonoBehaviour 
{
    public Color[] colors;

    private Color currentColor;
    private int currentWeight;

    Slider slider;
    Image sliderImage;

	void Start () 
    {
        slider = GetComponent<Slider>();
        sliderImage = GetComponentInChildren<Image>();

        currentColor = colors[0];
        currentWeight = 1;
	}
	
    public void SetSliderColor(float value)
    {
        currentWeight = (int)value;
        currentColor = colors[currentWeight-1];

        ColorBlock colorBlock = slider.colors;
        colorBlock.pressedColor = currentColor;
        colorBlock.highlightedColor = currentColor;
        slider.colors = colorBlock;

        sliderImage.color = currentColor;
    }

    public Color GetCurrentWeightColor()
    {
        return currentColor;
    }

    public int GetCurrentWeight()
    {
        return currentWeight;
    }
}

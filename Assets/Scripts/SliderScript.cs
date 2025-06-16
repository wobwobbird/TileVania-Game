using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider; 
    public bool isOn;
    public Sounds soundScript;

    void Start()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(delegate { ToggleSlider(); });
            isOn = (int)slider.value == 1;
            UpdateSounds();
        }
    }


    // Update is called once per frame
    private void ToggleSlider()
    {
        Debug.Log("Slider value changed: " + slider.value);
        isOn = (int)slider.value == 1;   
        UpdateSounds();     
    }


    private void UpdateSounds()
    {
        if (soundScript != null)
        {
            soundScript.funnySounds = isOn;
            
        }
    }
}

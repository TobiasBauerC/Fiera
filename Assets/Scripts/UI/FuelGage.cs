using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGage : MonoBehaviour
{
    [SerializeField] private SpaceManager spaceManager;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;

    void Awake()
    {
        EventManager.AddHandler(EVENT.FuelChanged, UpdateSlider);
    }

    void UpdateSlider()
    {
        float newValue = spaceManager.activeShip.currentFuel / spaceManager.activeShip.maxFuel;
        slider.value = newValue;
        float colorLerp;
        if (newValue > 0.5f)
        {
            colorLerp = (newValue - 0.5f) / 0.5f;
            fillImage.color = Color.Lerp(Color.yellow, Color.green, colorLerp);
        }
        else
        {
            colorLerp = newValue / 0.5f;
            fillImage.color = Color.Lerp(Color.red, Color.yellow, colorLerp);
        }
    }
}

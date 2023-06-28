using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
        if (_slider == null)
            Debug.LogWarning("HealthBar.cs: Slider is null");
    }

    public void SetMaxHealth(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        _slider.value = health;
    }
}

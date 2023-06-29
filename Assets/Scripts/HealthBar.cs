using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    [SerializeField] Image _image;
    Image _fillImage;
    // [SerializeField] Sprite[] _sprites;
    // int id = 0;
    void Start()
    {
        _slider = GetComponent<Slider>();
        if (_slider == null)
            Debug.LogWarning("HealthBar.cs: Slider is null");

        _fillImage = transform.GetChild(0).GetComponent<Image>();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fillImage.color = Color.blue;
        }

        // float t = Mathf.PingPong(Time.time, 1);
        // print(t); 
        _fillImage.color = Color.Lerp(Color.green, Color.red, CalculateSlider());
    }

    private float CalculateSlider()
    {
        float a = _slider.maxValue;
        float b = _slider.minValue;
        float x = _slider.value;

        float t = (x - a) / (b - a);
        return t;
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



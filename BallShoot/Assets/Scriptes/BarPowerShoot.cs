using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPowerShoot : MonoBehaviour
{
    
    private Slider slider;
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private Image fill;
    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    public void SetValueSlide(float value)
    {
        slider.value = value;
        fill.color= gradient.Evaluate(value);
    }
}

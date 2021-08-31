using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPowerShoot : MonoBehaviour
{
    private Slider slider;
    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    public void SetValueSlide(float value)
    {
        slider.value = value;
    }
}

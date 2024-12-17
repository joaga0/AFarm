using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public HealthSystem healthSystem;

    public void SetHealthSystem(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        slider.maxValue = healthSystem.getMaxHealth();
        slider.value = healthSystem.getHealth();
    }

    private void Update()
    {
        if (healthSystem != null)
        {
            slider.value = healthSystem.getHealth();
        }
    }
}

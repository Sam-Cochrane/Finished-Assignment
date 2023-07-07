using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Slider health;

    public void SetMaxHealth(float Health)
    {
        health.maxValue = Health;
    }

    public void setHealth(float Health)
    {
        health.value = Health;
    }
}

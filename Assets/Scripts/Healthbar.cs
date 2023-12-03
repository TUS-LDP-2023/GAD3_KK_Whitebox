using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Image healthbar;
    public HealthEnemy health;

    private void Start()
    {
        UpdateHealthbar();
    }
    public void UpdateHealthbar()
    {
        healthbar.fillAmount = health.enemyCurrentHealth / health.enemyMaxHealth;
    }

}

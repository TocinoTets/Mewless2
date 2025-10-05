using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    Image imageHealthBar;

    HealthManager healthManager;

    float healthBarValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageHealthBar = GetComponentInChildren<Image>();
        healthManager = GetComponentInParent<HealthManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        imageHealthBar.fillAmount = healthManager.Health / 100f;   
    }

}

using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarManager : MonoBehaviour
{
    Slider healthBar;
    
    Camera cam;

    HealthManager healthManager;

    float healthBarValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        healthBar = GetComponent<Slider>();
        healthManager = GetComponentInParent<HealthManager>();      
    }
    /*  COMENTO ESTA PARTE PORQUE TIRA ERROR 
    // Update is called once per frame
    void Update()
    {
        healthBar.ba
    }*/
}

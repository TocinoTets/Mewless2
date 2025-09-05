using UnityEngine;

public class PlayerMovenment : MonoBehaviour
{
    [SerializeField] private float velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(Horizontal * Time.deltaTime * velocidad, 0, 0);
        transform.Translate(0, Vertical * Time.deltaTime * velocidad, 0);
    }
}

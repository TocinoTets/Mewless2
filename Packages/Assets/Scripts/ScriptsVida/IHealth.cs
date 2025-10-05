using UnityEngine;

public interface IHealth
{
    float Health {  get; set; }
    public void TakeDamage(float damage);
    public void Death();
}

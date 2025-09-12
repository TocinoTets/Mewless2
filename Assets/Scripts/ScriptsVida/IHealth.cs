using UnityEngine;

public interface IHealth
{
    int Health {  get; set; }
    void TakeDamage();
    void Death();
}

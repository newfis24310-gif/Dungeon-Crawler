using UnityEngine;
using System.Collections.Generic;

public class CombatComponent : MonoBehaviour, IComponent
{
    public int attack = 2;
    public int defence = 1;
    public int maxRandomDamage = 2;


    public void Attack(List<Entity> targets)
    {
        foreach(Entity target in targets)
        {
            HealthComponent targetHealth = target.GetComponent<HealthComponent>();
            if(targetHealth != null)
            {
                int randomDamage = Random.Range(1, maxRandomDamage+1);
                targetHealth.TakeDamage(attack + randomDamage);
                Debug.Log(this.name + " did " + attack + " damage plus " + randomDamage + " extra." );
            }
        }
    }

    public void Attack(GameObject target)
    {
        HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        if(targetHealth != null)
        {
            int randomDamage = Random.Range(1, maxRandomDamage+1);
            targetHealth.TakeDamage(attack + randomDamage);
            Debug.Log(this.name + " did " + attack + " damage plus " + randomDamage + " extra." );
        }
    }

    public void Initialize()
    {
        
    }
}

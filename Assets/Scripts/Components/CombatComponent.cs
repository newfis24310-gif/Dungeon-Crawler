using UnityEngine;
using System.Collections.Generic;

public class CombatComponent : MonoBehaviour, IComponent
{
    public int attack = 2;
    public int defence = 1;
    public int maxRandomDamage = 2;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float yoffset = 1.5f;

    List<GameObject> enemies = new List<GameObject>();

    public void PrepareCombat()
    {
        float currentOffset = yoffset;
        int numberOfEnemies = Random.Range(1, 3);
        if(numberOfEnemies == 1)
        {
            enemies.Add(Instantiate(enemyPrefab,gameObject.transform.position + Vector3.up * currentOffset, Quaternion.identity));
        }
        else if(numberOfEnemies > 1)
        {
            float offset = 0.5f;
            for(int i = 0; i < numberOfEnemies; i++)
            {
                enemies.Add(Instantiate(enemyPrefab,gameObject.transform.position + Vector3.up * currentOffset, Quaternion.identity));
                currentOffset += offset;
            }
        }
    }

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

    public void Attack(Entity target)
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

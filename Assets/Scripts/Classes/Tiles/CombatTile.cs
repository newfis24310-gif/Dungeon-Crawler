using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CombatTile : ActionTile
{
    Player playerCharacter;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float yoffset = 1.5f;
    [SerializeField] float waitTurn = 1f;
    List<GameObject> enemies = new List<GameObject>();
    public bool endCombat = false;

    public override void ExecuteEffect(Player player)
    {
        if(traversed == false)
        {
            Debug.Log("Oh no! You've entered combat.");
            playerCharacter = player;
            traversed = true;
            PrepareCombat();
        }
    }

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
        StartCoroutine(BattleRoutine());
    }

    IEnumerator BattleRoutine()
    {
        var playerCombat = playerCharacter.gameObject.GetComponent<CombatComponent>();
        var playerHealth = playerCharacter.gameObject.GetComponent<HealthComponent>();

        while (enemies.Count > 0)
        {
            Debug.Log("Player attacks.");
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                var enemy = enemies[i];

                playerCombat.Attack(enemy);
                if(enemy.GetComponent<HealthComponent>().status == HealthComponent.Status.Dead)
                {
                    enemies.RemoveAt(i);
                    Destroy(enemy.gameObject);
                    Debug.Log("An enemy died today... oh well.");
                }
            }

            yield return new WaitForSeconds(waitTurn);

            if(enemies.Count > 0)
            {
                Debug.Log("The enemies take charge.");
                foreach(var enemy in enemies)
                {
                    enemy.GetComponent<CombatComponent>().Attack(playerCharacter.gameObject);
                    if(playerHealth.status == HealthComponent.Status.Dead)
                    {
                        TurnManager.Instance.LoseGame();
                        yield break;
                    }
                }   

                yield return new WaitForSeconds(waitTurn);
            }
        }

        Debug.Log("You won the battle!");
        EndEffect();
        yield break;
    }
}

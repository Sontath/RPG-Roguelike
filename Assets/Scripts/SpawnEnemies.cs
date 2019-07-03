using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject Folder;
    public GameObject EnemyPrefab;
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        int enemySize = Random.Range(4, 7);
        Debug.Log("Size: " + enemySize);
        GameObject enemy;
        EnemyBrains script;

        PushEnemies pushEnemies = Folder.GetComponent<PushEnemies>();
        Rigidbody2D[] enemies = new Rigidbody2D[enemySize];

        for (int i = 0; i < enemySize; i++)
        {

            enemy = (Instantiate(EnemyPrefab, new Vector3(Random.Range(8, 40) * (Random.Range(0, 2) % 2 == 0 ? 1 : -1),
                Random.Range(8, 40) * (Random.Range(0, 2) % 2 == 0 ? 1 : -1), 0), Quaternion.identity) as GameObject);
            enemy.transform.parent = Folder.transform;
            script = enemy.GetComponent<EnemyBrains>();
            script.player = player;
            enemies[i] = enemy.GetComponent<Rigidbody2D>();
        }

        pushEnemies.enemies = enemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

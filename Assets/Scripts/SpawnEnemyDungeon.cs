using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyDungeon : MonoBehaviour
{
    public bool IsSpawn;
    [SerializeField]
    GameObject[] Enemies;
    [SerializeField]
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsSpawn)
        {
            int EnemySize = Random.Range(1, 4);

            for (int i = 0; i < EnemySize; i++)
            {
                GameObject enemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform);
                enemy.GetComponent<EnemyBrains>().player = player;
                Transform enemyRB = enemy.GetComponent<Transform>();
                enemyRB.position = new Vector3(transform.position.x + Random.Range(1, 9),
                    transform.position.y + Random.Range(1, 9), 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

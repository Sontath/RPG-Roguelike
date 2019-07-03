using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemies : MonoBehaviour
{
    public Rigidbody2D[] enemies;

    private void Update()
    {
        foreach (var Enemy in enemies)
        {
            if (Enemy != null)
            {
                foreach (var OtherEnemy in enemies)
                {
                    if (OtherEnemy != null)
                    {
                        if (OtherEnemy != Enemy)
                        {
                            if ((Enemy.position - OtherEnemy.position).magnitude < 3)
                            {
                                OtherEnemy.AddForce((new Vector2(-1 * (Enemy.position.x - OtherEnemy.position.x),
                                    -1 * (Enemy.position.y - OtherEnemy.position.y))) * 5);
                            }
                        }
                    }
                }
            }
        }
    }
}

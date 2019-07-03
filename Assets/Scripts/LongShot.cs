using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongShot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    public Transform player;
    [SerializeField]
    private Transform firePoint;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, player.rotation);
    }
}

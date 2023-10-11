using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicTower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    
    private void Start()
    {

    }

    protected override IEnumerator IShoot()
    {
        yield return WaitBeforeShooting;
        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower1 : BasicTower
{
    private void Start()
    {
        timeBetweenShots -= 1f;
    }
}

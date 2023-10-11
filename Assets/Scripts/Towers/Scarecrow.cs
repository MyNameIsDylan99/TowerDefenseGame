using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : Tower
{
    [SerializeField]
    int sendBack;
    protected override IEnumerator IShoot()
    {
        Enemy currentEnemy = CurrentTarget.GetComponent<Enemy>();
        int sendBackIndex = currentEnemy.CurrentIndex - sendBack;
        if(sendBackIndex<0)
        {
            currentEnemy.OverrideTargetTile(MapGenerator.StartTile);
        }
        else
        {
            currentEnemy.OverrideTargetTile(MapGenerator.PathTiles[sendBackIndex]);
        }
        
        yield return 0;
    }


}

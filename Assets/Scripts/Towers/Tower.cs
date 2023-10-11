using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int SellValue;
    public int IndexOfNextUpgrade;
    [SerializeField] protected float range;
    public float Range { get { return range; } }
    [SerializeField] protected float timeBetweenShots; //Time in seconds between shots.

    //WaitForSeconds to give the the barrel time to rotate before shooting.
    protected WaitForSeconds WaitBeforeShooting = new WaitForSeconds(0.2f);
    [SerializeField]
    protected int towerCost;
    public int TowerCost { get { return towerCost; } }
    [SerializeField]
    protected int upgradeCost;
    public int UpgradeCost { get { return upgradeCost; } }

    private float nextTimeToShoot;

    public GameObject CurrentTarget;

    public GameObject NextUpgrade;
    

    private void Start()
    {
        nextTimeToShoot = Time.time;
    }
    public virtual void Upgrade()
    {
        GameObject nextUpgrade = Instantiate(NextUpgrade);
        nextUpgrade.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
    private void UpdateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;
        float distance = Mathf.Infinity;
        foreach(GameObject enemy in Enemies.enemies)
        {
            if (enemy != null)
            {
                float _distance = (transform.position - enemy.transform.position).magnitude;
                if (_distance < distance)
                {
                    distance = _distance;
                    currentNearestEnemy = enemy;
                }
            }
        }
        if (distance <= range)
            CurrentTarget = currentNearestEnemy;
        else
            CurrentTarget = null;
    }
    protected virtual void Shoot()
    {
        StartCoroutine("IShoot");
    }
    protected virtual IEnumerator IShoot()
    {
        yield return WaitBeforeShooting;
    }

    private void Update()
    {
        UpdateNearestEnemy();
        if(Time.time >= nextTimeToShoot)
        {
            if(CurrentTarget!=null)
            {
                Shoot();
                nextTimeToShoot = Time.time + timeBetweenShots;
            }
        }
    }
}

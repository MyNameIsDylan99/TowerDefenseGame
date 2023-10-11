using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> EnemyList;
    [SerializeField]
    private int enemyHealth;
    [SerializeField]
    private float movementSpeed;
    public MoneyManager MoneyManager;
    public HealthManager HealthManager;
    public MusicManager musicManager;
    int currentIndex;
    public int CurrentIndex { get { return currentIndex; } }
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
        

    private GameObject targetTile;
    public GameObject TargetTile
    {
        get { return targetTile; }
    }
    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        MoneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        HealthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
        Enemies.enemies.Add(gameObject);
    }
    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        if(targetTile==null)
        targetTile = MapGenerator.StartTile;
    }
    public void TakeDamage(int amount)
    {
        musicManager.PlayPopSound();
        if (amount <= enemyHealth)
            MoneyManager.AddMoney(amount);
        else
            MoneyManager.AddMoney(enemyHealth);

        enemyHealth -= amount;
        if(enemyHealth<=0)
        {
            die();
        }
        else if(enemyHealth>=1&&enemyHealth<21)
        {
            GameObject newEnemy = Instantiate(EnemyList[enemyHealth - 1], this.transform.position,this.transform.rotation);
            newEnemy.GetComponent<Enemy>().OverrideTargetTile(this.targetTile);
            die();
        }
    }
    public void die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }
    private void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if(targetTile!=null&& targetTile != MapGenerator.EndTile)
        {
            float distance = (transform.position - targetTile.transform.position).magnitude;
            if (distance < 0.001f)
            {
                currentIndex = MapGenerator.PathTiles.IndexOf(targetTile);
                targetTile = MapGenerator.PathTiles[currentIndex + 1];
            }
        }
        if((transform.position-MapGenerator.EndTile.transform.position).magnitude<0.001)
        {
            HealthManager.RemoveHealth(enemyHealth);
            die();
        }
    }
    public void OverrideTargetTile(GameObject targetTile)
    {
        this.targetTile = targetTile;
    }

    private void Update()
    {
        CheckPosition();
        MoveEnemy();
    }
}

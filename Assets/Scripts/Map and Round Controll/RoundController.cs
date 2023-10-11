using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public MoneyManager MoneyManager;
    public GameObject WinScreen;
    public List<GameObject> EnemyList;

    public float timeBeforeRoundStarts;
    public float timeBetweenWaves;
    public float timeVariable;

    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public int round;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;
        round = 1;

    }

    private void SpawnEnemies()
    {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        switch(round)
        {
            case 1:
                StartCoroutine(SpawnSetOfEnemys(5, 0,0.5f));
                ;
                break;
            case 2:
                StartCoroutine(SpawnSetOfEnemys(5, 0, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 0, 0.5f));
                break;
            case 3:
                StartCoroutine(SpawnSetOfEnemys(10, 0, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 0, 0.5f));
                break;
            case 4:
                StartCoroutine(SpawnSetOfEnemys(10, 0, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(10, 0, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(3, 1, 0.2f));
                break;
            case 5:
                StartCoroutine(SpawnSetOfEnemys(7, 1, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(5, 1, 0.3f));
                break;
            case 6:
                StartCoroutine(SpawnSetOfEnemys(10, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(3, 2, 0.3f));
                break;
            case 7:
                StartCoroutine(SpawnSetOfEnemys(10, 0, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(3, 2, 0.5f));
                break;
            case 8:
                StartCoroutine(SpawnSetOfEnemys(5, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.1f));
                break;
            case 9:
                StartCoroutine(SpawnSetOfEnemys(10, 1, 0.4f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.2f));
                break;
            case 10:
                StartCoroutine(SpawnSetOfEnemys(5, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(3, 3, 0.5f));
                break;
            case 11:
                StartCoroutine(SpawnSetOfEnemys(5, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(3, 3, 0.2f));
                break;
            case 12:
                StartCoroutine(SpawnSetOfEnemys(10, 1, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(3, 3, 0.2f));
                break;
            case 13:
                StartCoroutine(SpawnSetOfEnemys(5, 3, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(20, 1, 0.2f));
                break;
            case 14:
                StartCoroutine(SpawnSetOfEnemys(5, 3, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(5, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(12, 2, 0.2f));
                break;
            case 15:
                StartCoroutine(SpawnSetOfEnemys(8, 3, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(20, 1, 0.2f));
                break;
            case 16:
                StartCoroutine(SpawnSetOfEnemys(5, 3, 0.5f));
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.3f));
                StartCoroutine(SpawnSetOfEnemys(15, 3, 0.3f));
                break;
            case 17:
                StartCoroutine(SpawnSetOfEnemys(20, 2, 0.25f));
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.1f));
                StartCoroutine(SpawnSetOfEnemys(5, 3, 0.2f));
                break;
            case 18:
                StartCoroutine(SpawnSetOfEnemys(30, 0, 0.25f));
                StartCoroutine(SpawnSetOfEnemys(20, 1, 0.2f));
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.3f));
                break;
            case 19:
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.1f));
                StartCoroutine(SpawnSetOfEnemys(10, 2, 0.1f));
                StartCoroutine(SpawnSetOfEnemys(10, 3, 0.2f));
                break;
            case 20:
                StartCoroutine(SpawnSetOfEnemys(50, 0, 0.4f));
                StartCoroutine(SpawnSetOfEnemys(20, 3, 0.1f));
                StartCoroutine(SpawnSetOfEnemys(10, 0, 0.4f));
                StartCoroutine(SpawnSetOfEnemys(10, 3, 0.05f));
                break;
            case 21:
                break;
            case 22:
                break;
            case 23:
                break;
            case 24:
                break;
            case 25:
                break;
            case 26:
                break;
            case 27:
                break;
            case 28:
                break;
            case 29:
                break;
            case 30:
                break;
            case 31:
                break;
            case 32:
                break;
            case 33:
                break;
            case 34:
                break;
            case 35:
                break;
            case 36:
                break;
            case 37:
                break;
            case 38:
                break;
            case 39:
                break;
            case 40:
                break;
        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator SpawnSetOfEnemys(int amount, int index, float seconds)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newEnemy = Instantiate(EnemyList[index], MapGenerator.StartTile.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(seconds);
        }
    }

    private void Update()
    {
        if(round==21)
        {
            WinScreen.SetActive(true);
                Time.timeScale = 0f;
        }
        GameObject.Find("Round").GetComponent<Text>().text = round.ToString();
        if(isStartOfRound)
        {
            if(Time.time>= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;
                SpawnEnemies();
                return;
            }
        }
        else if(isIntermission)
        {
            if(Time.time>=timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;
                SpawnEnemies();
            }
        }
        else if(isRoundGoing)
        {
            if(Enemies.enemies.Count>0)//Will check the amount of enemies remaining
            {

            }
            else
            {
                MoneyManager.AddMoney(50);
                isIntermission = true;
                isRoundGoing = false;
                timeVariable = Time.time + timeBetweenWaves;
                round++;
            }
        }
    }
}

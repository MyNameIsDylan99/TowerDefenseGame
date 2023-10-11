using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public MoneyManager moneyManager;

    public GameObject basicTowerPrefab;


    public int GetTowerCost(GameObject towerPrefab)
    {
        //int cost = int.Parse(towerPrefab.name.Substring(4,4));
        int cost = towerPrefab.GetComponent<Tower>().TowerCost;
        return cost;
    }
    public int GetUpgradeCost(GameObject towerPrefab)
    {
        //int cost = int.Parse(towerPrefab.name.Substring(9, 6));
        int cost = towerPrefab.GetComponent<Tower>().UpgradeCost;
        return cost;
    }
    public void BuyTower(GameObject towerPrefab)
    {
        moneyManager.RemoveMoney(GetTowerCost(towerPrefab));
    }
    public void SellTower(GameObject tower)
    {
        moneyManager.AddMoney(tower.GetComponent<Tower>().SellValue);
    }
    public void BuyUpgrade(GameObject towerPrefab)
    {
        moneyManager.RemoveMoney(GetUpgradeCost(towerPrefab));
    }

    public bool CanBuyTower(GameObject towerPrefab)
    {
        int cost = GetTowerCost(towerPrefab);
        bool canBuy = false;
        if(moneyManager.GetCurrentMoney()>=cost)
        {
            canBuy = true;
        }
        return canBuy;
    }
    public bool CanBuyUpgrade(GameObject towerPrefab)
    {
        int cost = GetUpgradeCost(towerPrefab);
        bool canBuy = false;
        if (moneyManager.GetCurrentMoney() >= cost)
        {
            canBuy = true;
        }
        return canBuy;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    private int currentPlayerMoney;
    public int StarterMoney;
    private Text moneyText;

    public void Start()
    {
        moneyText=GameObject.Find("Money").GetComponent<Text>();
        currentPlayerMoney = StarterMoney;
        moneyText.text = currentPlayerMoney.ToString();
    }
    public int GetCurrentMoney()
    {
        return currentPlayerMoney;
    }
    public void AddMoney(int amount)
    {
        currentPlayerMoney += amount;
        moneyText.text = currentPlayerMoney.ToString();
    }
    public void RemoveMoney(int amount)
    {
        currentPlayerMoney -= amount;
        moneyText.text = currentPlayerMoney.ToString();
    }
}

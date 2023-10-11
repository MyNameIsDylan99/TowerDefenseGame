using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject LoseScreen;
    private Text healthText;
    [SerializeField]
    private int health = 100;
    private void Awake()
    {
        healthText = GameObject.Find("Health").GetComponent<Text>();
        healthText.text = health.ToString();
    }
    public void RemoveHealth(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();
       if(health<=0)
        {
            LoseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }


}

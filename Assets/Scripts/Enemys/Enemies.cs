using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public static List<GameObject> enemies = new List<GameObject>();
    private void Start()
    {
        enemies = new List<GameObject>();
    }

}

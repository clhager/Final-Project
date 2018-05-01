using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public int currentHealth;
    public Text healthCounter;
    public int gold;

    // Use this for initialization
    void Start()
    {
        currentHealth = 5;
        gold = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        healthCounter.text = currentHealth.ToString();
    }
}

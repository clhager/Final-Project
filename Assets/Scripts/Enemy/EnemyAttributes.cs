using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour {
    public float Health = 10;
	public int reward;
    public bool burn;
    public float burnTime;
    public float burnDamage;
    public float currentTime;
    public bool freeze;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.time;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        if (burn & currentTime <= burnTime)
        {
            Health -= burnDamage * Time.deltaTime;
        } else
        {
            burn = false;
        }
	}
}

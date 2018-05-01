using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    private float originalScale;
	// Use this for initialization
	void Start () {
        maxHealth = gameObject.GetComponentInParent<EnemyAttributes>().Health;
        originalScale = gameObject.transform.localScale.x;
        GetComponent<SpriteRenderer>().sortingOrder = 10;
    }
	
	// Update is called once per frame
	void Update () {
		currentHealth = gameObject.GetComponentInParent<EnemyAttributes>().Health;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = (currentHealth / maxHealth) * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}

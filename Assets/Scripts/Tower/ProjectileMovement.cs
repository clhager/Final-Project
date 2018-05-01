using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public float speed = 5;
    public float damage;
    public GameObject target;
    public float level;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public bool fireTower;
    public bool waterTower;
    public bool energyTower;
    Collider2D[] surroundingEnemies;
    public bool meteorA;
    public bool whirlpoolA;
    public bool freezeA;
    public bool burnA;
    public bool paralyzeA;
    public float spreadDmg;
    private float distance;
    private float startTime;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
        }
        targetPosition = target.transform.position;
        distance = Vector2.Distance(startPosition, targetPosition);
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
        if (gameObject.transform.position == targetPosition)
        {
            if (target != null)
            {
                surroundingEnemies = Physics2D.OverlapCircleAll(targetPosition, 2f, (int)Mathf.Pow(2, 8));
                target.GetComponent<EnemyAttributes>().Health -= damage;
                if (fireTower)
                {
                    applyBurn(target);

                }
                else if (waterTower)
                {
                    applySlow(target);
                }
                foreach (Collider2D Enemies in surroundingEnemies)
                {
                    EnemyAttributes EA = Enemies.gameObject.GetComponent<EnemyAttributes>();
                    EnemyMovement EM = Enemies.gameObject.GetComponent<EnemyMovement>();
                    if ((level != 0 | (energyTower && EM.slow)) && Enemies.gameObject != target)
                    {
                        spreadDmg = damage;
                        if (EM.slow && energyTower)
                        {
                            spreadDmg = damage * 0.5f;
                        }
                        Debug.Log(spreadDmg);
                        if (meteorA)
                        {
                            applyBurn(Enemies.gameObject);
                            if (EM.freeze)
                            {
                                spreadDmg *= 2;
                                EM.freeze = false;
                            }
                        }
                        else if (whirlpoolA)
                        {
                            applySlow(Enemies.gameObject);
                        }
                        else if (freezeA)
                        {
                            applyFreeze(Enemies.gameObject);
                        }
                        EA.Health -= spreadDmg;
                    }
                }
                if (target.GetComponent<EnemyAttributes>().Health <= 0)
                {
					Map mapManager = GameObject.Find ("MapManager").GetComponent<Map>();
					mapManager.moneys += target.GetComponent<EnemyAttributes> ().reward;
					mapManager.budget.text = string.Format ("{0}", mapManager.moneys);
                    Destroy(target);
                }
            }
            Destroy(gameObject);
        }
    }

    void applyBurn(GameObject target)
    {
        target.GetComponent<EnemyAttributes>().burn = true;
        target.GetComponent<EnemyAttributes>().burnTime = Time.time + 3;
        target.GetComponent<EnemyAttributes>().burnDamage = 0.33f;
        if (burnA)
        {
            target.GetComponent<EnemyAttributes>().burnDamage = target.GetComponent<EnemyAttributes>().Health * 0.1f;
        }
        if (target.GetComponent<EnemyMovement>().freeze)
        {
            target.GetComponent<EnemyAttributes>().Health -= damage;
            target.GetComponent<EnemyMovement>().freeze = false;
        }
    }

    void applySlow(GameObject target)
    {
        target.GetComponent<EnemyMovement>().slow = true;
        target.GetComponent<EnemyMovement>().slowTime = Time.time + 5;
        
    }

    void applyFreeze(GameObject target)
    {
        target.GetComponent<EnemyMovement>().freeze = true;
        target.GetComponent<EnemyMovement>().freezetime = Time.time + 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject projectile;
    public float timeToReload;
    //public float fireSpeed;
	public int type;
	public int number;

    float reloadTimer = 0;
    List<GameObject> playerList;
    public bool fire;
    public bool water;
    public bool energy;
    public int element_type;
	public GameObject buildTowerMenu;
	public GameObject activeTowerMenu;
	public Animator anim;
	[HideInInspector]
	public GameObject buildSlot;

    // Use this for initialization
    void Start () {
        playerList = new List<GameObject>();
		buildTowerMenu = GameObject.Find ("MapManager").transform.Find("buildTowerMenu").gameObject;
		activeTowerMenu = GameObject.Find ("MapManager").transform.Find("activeTowerMenu").gameObject;
		anim = GetComponent<Animator> ();
        if (energy)
        {
            timeToReload *= 1.5f;
        }
	}

    // Update is called once per frame
    void Update () {
        shoot();
    }

    void shoot()
    {
        if (reloadTimer > timeToReload)
        {
            // check if there are any targets within range
            if (playerList.Count > 0)
            {
				anim.SetTrigger ("attack");
                reloadTimer = 0;
                //shoot at each player in range
                GameObject obj = playerList[0];
                // Create the projectile and Access its Rigidbody to add force
                Vector3 startPosition = gameObject.transform.position;
                Vector3 targetPosition = obj.transform.position;

                GameObject newProjectile = (GameObject)Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                newProjectile.transform.position = startPosition;
                ProjectileMovement bulletComp = newProjectile.GetComponent<ProjectileMovement>();
                bulletComp.target = obj.gameObject;
                bulletComp.startPosition = startPosition;
                bulletComp.targetPosition = targetPosition;
            }
        }
        else
        {
            reloadTimer += Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (isEnemy(coll.gameObject))
        {
            playerList.Add(coll.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (isEnemy(coll.gameObject))
        {
            playerList.Remove(coll.gameObject);
        }
    }


    //Returns whether or not the Game Object is the Player Character
    bool isEnemy(GameObject obj)
    {
        return obj.CompareTag("Enemy");
    }

	void OnMouseDown() {
		
		// Deactivate the build menu
		buildTowerMenu.SetActive (false);

		// Move the active menu to the tower
		activeTowerMenu.transform.position = this.transform.position;
		TowerMenu upgradeMenu = activeTowerMenu.GetComponent<TowerMenu> ();
		upgradeMenu.currentSlot = this.gameObject;

		// Set the appropriate upgrades
		TowerPanel upgradeA = upgradeMenu.towerPanels[0].GetComponent<TowerPanel> ();
		TowerPanel upgradeB = upgradeMenu.towerPanels[1].GetComponent<TowerPanel> ();

		activeTowerMenu.SetActive (true);
	}
}


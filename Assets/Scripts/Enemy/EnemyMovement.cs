using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
   
    public GameObject[] Waypoints;
    private int currentWaypoint = 0;
    private float lastTimeArrived;
    public float speed = 1.0f;
    public bool slow;
    public float slowTime;
	private Animator anim;
    public float check;
    public bool freeze;
    public float freezetime;
    public float current;
    public float currentTime;
	// Use this for initialization
	void Start () {
        lastTimeArrived = Time.time;
		anim = GetComponent<Animator>();
        check = speed;
	}
	
	// Update is called once per frame
	void Update () {
        current = Time.time;
        if (slow & (current <= slowTime))
        {
            speed = 0.5f * check;
        } else if (current > slowTime)
        {
            slow = false;
            speed = check;
        }
       if (freeze & Time.time <= freezetime)
        {
            speed = 0.0f;
        } else if (freezetime > Time.time)
        {
            freeze = false;
            speed = check;
        }
        Vector3 startWaypoint = Waypoints[currentWaypoint].transform.position;
        Vector3 targetWaypoint = Waypoints[currentWaypoint + 1].transform.position;
        float pathLength = Vector3.Distance(startWaypoint, targetWaypoint);
        float travelTime = pathLength / check;
        currentTime += Time.deltaTime * speed; 
		Vector3 lerp = Vector2.Lerp(startWaypoint, targetWaypoint, currentTime / travelTime);
		lerp.z = 2;
		anim.SetFloat ("movX", lerp.x - transform.position.x);
		anim.SetFloat("movY", lerp.y - transform.position.y);
		gameObject.transform.position = lerp;

		if (gameObject.transform.position.x == targetWaypoint.x && gameObject.transform.position.y == targetWaypoint.y)
        {
            if (currentWaypoint < Waypoints.Length - 2)
            {
                currentWaypoint += 1;
                currentTime = 0;
                RotateIntoMoveDirection();
            } else
            {
                GameObject sceneM = GameObject.Find("SceneM");
                sceneM.GetComponent<SceneManagement>().currentHealth -= 1;
				if (sceneM.GetComponent<SceneManagement> ().currentHealth == 0) {
					GameObject sceneManager = GameObject.Find ("SceneManager");
					sceneManager.GetComponent<LevelLoader> ().LoadLevel (0);
				}
                Destroy(gameObject);
            }
        }
        
	}

    private void RotateIntoMoveDirection()
    {
        Vector3 newStartPosition = Waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = Waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
       
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
       
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;


public class CivilianMovement : MonoBehaviour
{

    int currentLocation = 0;
    bool canGenerate;
    float testFloat = 10.0f;
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    StatusHolder player_script;
    public GameObject[] points;
    public bool isAlert;
    RaycastHit hit;
    GameObject player;
        
    void Awake()
    {
        
      
        //find all the points in the game
        points = GameObject.FindGameObjectsWithTag("Point");
        //we know how many total points
        print("Total Points: " + points.Length);


        canGenerate = true;
        nav = GetComponent<NavMeshAgent>();
        CreateNewLocation();

        
        player = GameObject.FindWithTag("Player");
        player_script = player.GetComponentInParent<StatusHolder>();


    }

    void Start()
    {
    }


    void Update()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Player Hit");
                
                if (player_script.isSuspect == true)
                {
                    Debug.Log(this.name + " is alerted to the player");
                    isAlert = true;

                    if (isAlert == true)
                    {
                       Vector3 disToPlayer = transform.position - player.transform.position + new Vector3(testFloat, 0, testFloat);
                       Debug.Log("disToPlayer = "+disToPlayer);
                       StartCoroutine(distanceDelay(10.0f));

                       Vector3 newPos = transform.position + disToPlayer;
                       Debug.Log("newPos = " + newPos);   
                       nav.SetDestination(newPos);
                       canGenerate = false;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            CreateNewLocation();
        }
    }

    void CreateNewLocation()
    {
        //wrapped in a boolean so that if you can't generate a new location then you wont even try
        if (canGenerate)
        {
            int rnd = RandomLocation();

            //when you've got a new location, you'll then start a timer (see line 114)
            StartCoroutine(canGenerateDelay(0.5f));

            Debug.Log(gameObject.name + " - new local = " + rnd + "current local is = " + currentLocation);

           
            nav.SetDestination(points[rnd].transform.position);

           
        }
    }

    //keep your random location code here so that you can keep it unique and just mess around with it as you need. 
    int RandomLocation()
    {
        int rnd = UnityEngine.Random.Range(0, points.Length);

        while (rnd == currentLocation)
        {
            Debug.Log("Same location generated generating new");
            rnd = UnityEngine.Random.Range(0, points.Length);
        }
        currentLocation = rnd;
        return rnd;
    }


    //this function is an Enumerator that has a different set of rules compared to normal functions
    //its got a parameter 
    IEnumerator canGenerateDelay(float delay)
    {
        canGenerate = false;
        yield return new WaitForSeconds(delay);
        canGenerate = true;
    }

    IEnumerator distanceDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAlert = false;
        testFloat = 10.0f;
        canGenerate = true; 
        CreateNewLocation();
    }


}

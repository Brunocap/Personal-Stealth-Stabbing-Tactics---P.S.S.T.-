using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;


public class CivilianMovement : MonoBehaviour
{

    int currentLocation = 0;
    bool canGenerate;

    NavMeshAgent nav;               // Reference to the nav mesh agent.

    public GameObject[] points;

    void Awake()
    {
        //find all the points in the game
        points = GameObject.FindGameObjectsWithTag("Point");
        //we know how many total points
        print("Total Points: " + points.Length);


        canGenerate = true;
        nav = GetComponent<NavMeshAgent>();
        CreateNewLocation();
    }

    void Start()
    {

    }


    void Update()
    {
        {
          
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
            StartCoroutine(canGenerateDelay(1.0f));

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


}

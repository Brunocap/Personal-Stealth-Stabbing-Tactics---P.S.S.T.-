using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovement : MonoBehaviour {

    public Transform Point1;
    public Transform Point2;
    public GameObject sightline;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(Point1.position);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Point1")
        {
            nav.SetDestination(Point1.position);
        }
        if (other.name == "Point2")
        {
            nav.SetDestination(Point2.position);
        }
    }
    public void Alert()
    {

    }


}

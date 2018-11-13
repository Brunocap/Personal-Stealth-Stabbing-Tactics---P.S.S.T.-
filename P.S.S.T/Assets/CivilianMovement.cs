using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CivilianMovement : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(Point1.position);
    }


    void Update()
    {
        {
          
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Point1")
        {
            nav.SetDestination(Point2.position);
        }
        if (other.name == "Point2")
        {
            nav.SetDestination(Point1.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

 /*public class SightLineScript : MonoBehaviour {

    public Transform CharacterPos;
    public float fieldOfView = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    NavMeshAgent nav;
    private SphereCollider col;
    private GameObject player;
    private Vector3 lastPlayerSighting;
    private bool PlayerIsSuspect;
    private Vector3 previousSighting;

    // Use this for initialization
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("Player").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");




    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, CharacterPos.transform.position, 2);
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, CharacterPos.transform.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);

        if (personalLastSighting)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
} 
*/

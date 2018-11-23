using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpottingBehaviour : MonoBehaviour {

    public Transform CharacterPos;
    public GameObject Guard;
    public GameObject player;
    public bool spottingissue = false;
    

    void Awake()
    {

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, CharacterPos.transform.position, 2);
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, CharacterPos.transform.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = Quaternion.Euler(eulerRotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonController")
        {
            if (other.GetComponent("Third Person Character").GetComponent("Is Suspect") == true)
            {
                spottingissue = true;
                Debug.Log(spottingissue);
            }
        }
    }
}

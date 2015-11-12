using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody> ().velocity = transform.forward * 10.0f;
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameManager manager;

    public float moveSpeed;
    public float rotationSpeed = 60f;
    public GameObject deathParticles;
    

    private float maxSpeed = 5f;
    private Vector3 input;
    private Vector3 spawn;

	// Use this for initialization
	void Start () {

        spawn = transform.position;
        manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddRelativeForce(input * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0.0f);
        }

        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0.0f);
        }

        if (transform.position.y < -5)
        {
            Death();
        }
        
	
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Death();
        }
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.transform.tag == "Goal")
        {
			if (manager.keyCount == 4) {
				manager.CompleteLevel();
			}            
        }

		if (other.transform.tag == "Key")
        {
            manager.keyCount += 1; ;
			Destroy(other.gameObject);
        }

		if (other.transform.tag == "Bullet")
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
        manager.deathCount += 1;
    }
}

using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

    public float triggerTime;

	// Use this for initialization
	void Start () {

        StartCoroutine(Go());
	
	}

    IEnumerator Go()
    {
        while(true)
        {
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(5f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

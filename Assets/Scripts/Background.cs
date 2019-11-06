using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public Vector3 backgroundVelocity = new Vector3(0, -7, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveBackground ();
	}

	private void moveBackground(){
		this.transform.position += (backgroundVelocity * Time.deltaTime);
	}
}

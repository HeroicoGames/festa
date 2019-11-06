using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Branch : MonoBehaviour {

	public Vector3 branchVelocity = new Vector3(0f, -7f, 0f);
	Transform[] allChildren;
	bool se_dejo_ver = false;
	bool se_dejo_ver_2 = false;
	public GUIText score;
	public AudioClip soundPoint;

	// Use this for initialization
	void Start () {
		allChildren = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		moveBranch ();
	}

	private void moveBranch(){
		this.transform.position += (branchVelocity * Time.deltaTime);

		Transform children_1 = allChildren [1];
		SpriteRenderer s_renderer_1 = children_1.GetComponent<SpriteRenderer>();
		if (s_renderer_1.isVisible == true && se_dejo_ver == false) {
			se_dejo_ver = true;

		} else if (s_renderer_1.isVisible == false && se_dejo_ver == true){
		
			se_dejo_ver = false;
			Vector3 posTemporal = children_1.transform.position;
			posTemporal.y += 40f;
			children_1.transform.position = posTemporal;

			int points = int.Parse(score.text) + 1;
			score.text = points.ToString();
			playSound(soundPoint);
		}

		Transform children_2 = allChildren [2];
		SpriteRenderer s_renderer_2 = children_2.GetComponent<SpriteRenderer>();

		if (s_renderer_2.isVisible == true && se_dejo_ver_2 == false) {
			se_dejo_ver_2 = true;
			
		} else if (s_renderer_2.isVisible == false && se_dejo_ver_2 == true){
			
			se_dejo_ver_2 = false;
			Vector3 posTemporal = children_2.transform.position;
			posTemporal.y += 40f;
			children_2.transform.position = posTemporal;

			int points = int.Parse(score.text) + 1;
			score.text = points.ToString();
			playSound(soundPoint);
		}
	}

	public void playSound(AudioClip coinSound){
		AudioSource.PlayClipAtPoint (coinSound, transform.position);
	}
}

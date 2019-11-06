using UnityEngine;
using System.Collections;

public class Ballon : MonoBehaviour {

	string move_to;
	Vector3 move_to_left_vector = new Vector3(-7, 0, 0);
	Vector3 move_to_right_vector = new Vector3(7, 0, 0);
	public Branch branch;
	public Background background;
	private Animator animator;
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isGameOver != true) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				move_to = "to_left";
				
			}
			else if (Input.GetKey (KeyCode.RightArrow))
				move_to = "to_right";
		}
	}

	void FixedUpdate() {
		if(move_to == "to_left"){

			transform.position = transform.position + (move_to_left_vector * Time.deltaTime);
			move_to = "";
		}

		else if (move_to == "to_right"){

			transform.position += (move_to_right_vector * Time.deltaTime);
			move_to = "";
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		string collision_name = collision.gameObject.name;
		Vector3 initialize_vector = new Vector3(0, 0, 0);

		if(collision_name == "left_branch" | collision_name == "right_branch"){
			branch.branchVelocity = initialize_vector;
			background.backgroundVelocity = initialize_vector;

			animator.SetTrigger("GameOver");
			isGameOver = true;

			Rigidbody2D rigidBody = this.GetComponent<Rigidbody2D>();
			rigidBody.gravityScale = 1;
		}
	}


	void OnGUI()
	{
		const int anchoBoton = 84;
		const int altoBoton = 60;
		if(isGameOver)
		{
			// Dibujamos un boton  de Reinicio
			if (
				GUI.Button(
					new Rect(
						Screen.width / 2 - (anchoBoton / 2), (1.5f * Screen.height / 3) -(altoBoton / 2), anchoBoton, altoBoton
					),
					"Reiniciar!"
				)
			)
			{
				Application.LoadLevel("Amazonia");
			}
			if (
				GUI.Button(
				new Rect(
				Screen.width / 2 - (anchoBoton / 2),
				(2.1f * Screen.height / 3) - (altoBoton / 2),
				anchoBoton,
				altoBoton
				),
				"Puntajes!"
				)
				)
			{
			}
			if (
				GUI.Button(
				new Rect(
				Screen.width / 2 - (anchoBoton / 2),
				(2.7f * Screen.height / 3) - (altoBoton / 2),
				anchoBoton,
				altoBoton
				),
				"Compartir!"
				)
				)
			{
			}
		}
	}

}

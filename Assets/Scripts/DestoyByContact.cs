using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour {
	public GameObject explosion;
	public int scoreValue;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter (Collider other)
	{

//		if (explosion != null)
//		{
//			Instantiate (explosion, transform.position, transform.rotation);
//		}

		if (other.CompareTag ("bolt")) {
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		} else
			return;
	}
}
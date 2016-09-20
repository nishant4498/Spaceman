using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int hpValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player")
		{    
			if (gameController.getHP () <= 0) {
				gameController.AddScore (scoreValue);
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				Destroy (other.gameObject);
				return;
			} else {
				gameController.DecreaseHP (hpValue);
				if (gameController.getHP () == 0) {
					Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
					gameController.GameOver ();
					Destroy (other.gameObject);
					return;
				}
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
		if (other.tag == "Bolt") {
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
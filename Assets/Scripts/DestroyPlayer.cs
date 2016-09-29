using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

	private GameController gameController;
	public GameObject explosion;
	public GameObject playerExplosion;
	public int hpValue;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Enemy")) {
			Debug.Log ("Inside destroy player me: " + gameObject.name + ", other: " + other.name+ ", other tag: " + other.tag);
			gameController.DecreaseHP (hpValue);
			Destroy (other.gameObject);
			if (gameController.getHP () <= 0) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				Destroy (gameObject);
				return;
			}
		} else
			return;
			
	}
}

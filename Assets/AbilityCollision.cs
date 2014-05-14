using UnityEngine;
using System.Collections;

public class AbilityCollision : MonoBehaviour {

	GameObject AbilityGen;
	GameObject Player;
	// Use this for initialization
	void Start () {
		AbilityGen = GameObject.Find("Ability Generator");
		Player = GameObject.Find ("First Person Controller");
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.name == "First Person Controller") {
			AbilityGen.GetComponent<AbilityGenerator>().removeAbility (gameObject);
			chooseAbility();
		}
		if (collision.collider.name == "Cube(Clone)") {
			AbilityGen.GetComponent<AbilityGenerator>().removeAbility (gameObject);
		}
	}
	
	void chooseAbility(){
		Player.GetComponent<AbilityUse> ().setAbility (Random.Range (1, 8));
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward);
	}
}

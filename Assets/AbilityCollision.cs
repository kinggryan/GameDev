using UnityEngine;
using System.Collections;

public class AbilityCollision : MonoBehaviour {

	GameObject AbilityGen;
	// Use this for initialization
	void Start () {
		AbilityGen = GameObject.Find("Ability Generator");
	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.name == "First Person Controller" || collision.collider.name == "Cube(Clone)") {
			AbilityGen.GetComponent<AbilityGenerator>().removeAbility (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward);
	}
}

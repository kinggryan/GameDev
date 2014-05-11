using UnityEngine;
using System.Collections;

public class BlockCollision : MonoBehaviour {
	
	GameObject blockgen;

	
	
	// Use this for initialization
	void Start () {
		blockgen = GameObject.Find("Block Generator");
	}
	
	void OnCollisionEnter(Collision collision) {
		int h_self;
		float difference;
		if (collision.collider.name == "Cube(Clone)") {

			h_self = blockgen.GetComponent<BlockGenerator>().getHeight(gameObject);
			difference = rigidbody.transform.position.y - (2.5f + 5f * (float)(h_self));
			if (Mathf.Abs(difference) > 1)
				rigidbody.isKinematic = false;
			else
				if (Mathf.Abs(collision.rigidbody.transform.position.x - rigidbody.transform.position.x) < 1)
					if(Mathf.Abs(collision.rigidbody.transform.position.z - rigidbody.transform.position.z) < 1)
						rigidbody.isKinematic = true;
		} else {
			if (collision.collider.name == "First Person Controller") {


				//kill player
				blockgen.GetComponent<BlockGenerator>().removeBlock(gameObject);
				Debug.Log ("kill");
			}
		}
	}
	
	void OnCollisionStay(Collision collision) {
		//rigidbody.isKinematic = false;
	}
	
	void OnCollisionExit(Collision collision) {
		//if (collision.collider.name == "Cube(Clone)") {
			//rigidbody.isKinematic = false;
		//}
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}

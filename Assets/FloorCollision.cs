using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour {
	
	public GameObject blockgen;
	
	// Use this for initialization
	void Start () {
		//blockgen = GameObject.Find("Block Generator");
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "Cube(Clone)") {
			//((BlockGenerator)blockgen.GetComponent(typeof(BlockGenerator))).removeRow();
			blockgen.GetComponent<BlockGenerator>().removeRow();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

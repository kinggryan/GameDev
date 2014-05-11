using UnityEngine;
using System.Collections;

public class AbilityGenerator : MonoBehaviour {

	// Use this for initialization
	public GameObject Box;
	GameObject[,] Boxes = new GameObject[5,5];
	int[,] checkFull = new int[5, 5];
	int count = 0;

	void Start () {
		for(int i = 0; i < 5; i++){
			for(int j = 0; j < 5; j++){
				checkFull[i,j] = 0;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(count < 4){
			create_ability();
			count++;
		}
	}
	void create_ability(){

		int x = Random.Range (0,5);
		int z = Random.Range (0,5);

		while(checkFull[x,z] == 1){
			x = Random.Range (0,5);
			z = Random.Range (0,5);
		}
		Vector3 pos = new Vector3 (-10 + 5 * x, 1, -10 + 5 * z);

		Boxes[x, z] = (GameObject)Instantiate (Box, pos, Box.transform.rotation);
		checkFull [x, z] = 1;
	}

	public void removeAbility(GameObject ability) {
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				if (Boxes[i,j] == ability) {
					checkFull[i,j] = 0;
					//DestroyImmediate(ability);
					Destroy(ability);
					count--;
				}
			}
		}
	}

}

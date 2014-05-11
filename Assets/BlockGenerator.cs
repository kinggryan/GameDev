using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject Block;
	GameObject[,,] blocks = new GameObject[5,5,5];
	int blockCount = 0;
	float timer = 0;
	int[,] blockGrid = new int[5,5];
	
	void Start () {
	//	blocks = new GameObject[25];
		for(int i = 0; i < 5; i++)
			for (int j = 0; j < 5; j++)
				blockGrid[i, j] = 0;
		for(int i = 0; i < 1; i++)
			create_Block ();
	}

	void Update () {
		timer += Time.deltaTime;
		if (blockCount < 50){
			if (timer > 5) {
				timer = 0;
				create_Block ();
			}
		}
	}
	
	void create_Block () {
		int x, z, h;
		Vector3 pos;
		//bool flag;
/*
		x = blockCount / 5;
		z = blockCount % 5;
		h = blockGrid [x, z];
*/
		pos = blockPlaceAt ();
/*		
		do{
			flag = false;
			x = Random.Range (0, 5);
			z = Random.Range (0, 5);
			if (blockGrid [x, z] > 3)
				flag = true;
		} while (flag == true); 
		h = blockGrid [x, z];
		blockCount++;
		blockGrid [x, z]++;
*/
		x = (int)pos.x;
		h = (int)pos.y;
		z = (int)pos.z;

		pos = new Vector3(-10 + 5 * x, 20, -10 + 5 * z);
		blocks[x, z, h] = (GameObject)Instantiate (Block, pos, Quaternion.AngleAxis(90, new Vector3(1,0,0)));
		blocks [x, z, h].rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
			RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		blocks [x, z, h].layer = h + 8;
		blocks [x, z, h].GetComponent<Projector> ().ignoreLayers = (1<<(h + 8));
	}

	Vector3 blockPlaceAt() {
		bool xflag = (Random.value > 0.5f); // if true search for empty spot from high x to low x
		bool zflag = (Random.value > 0.5f); // if true search for empty spot from high z to low z
		bool flag;
		int x, z, h;
		//Debug.Log (blockCount);
		if (blockCount > 25) {
			if (xflag) {
				if(zflag) {
					for(int i = 0; i < 5; i++) {
						for(int j = 0; j < 5; j++) {
							if (blockGrid[4 - i, 4 - j] == 0) { // spot is empty
								x = 4 - i;
								z = 4 - j;
								h = blockGrid [x, z];
								blockCount++;
								blockGrid [x, z]++;
								return new Vector3 (x, h, z);
							} // if (blockGrid[4 - i, 4 - j] == 0)
						} // for(int j = 0; j < 5; j++)
					} // for(int i = 0; i < 5; i++)
				} // if(zflag)
				else {
					for(int i = 0; i < 5; i++) {
						for(int j = 0; j < 5; j++) {
							if (blockGrid[4 - i, j] == 0) { // spot is empty
								x = 4 - i;
								z = j;
								h = blockGrid [x, z];
								blockCount++;
								blockGrid [x, z]++;
								return new Vector3 (x, h, z);
							} // if (blockGrid[4 - i, j] == 0)
						} // for(int j = 0; j < 5; j++)
					} // for(int i = 0; i < 5; i++)
				} // else (!zflag)
			} // if( xflag)
			else {
				if(zflag) {
					for(int i = 0; i < 5; i++) {
						for(int j = 0; j < 5; j++) {
							if (blockGrid[i, 4 - j] == 0) { // spot is empty
								x = i;
								z = 4 - j;
								h = blockGrid [x, z];
								
								blockCount++;
								blockGrid [x, z]++;
								return new Vector3 (x, h, z);
							} // if (blockGrid[i, 4 - j] == 0)
						} // for(int j = 0; j < 5; j++)
					} // for(int i = 0; i < 5; i++)
				} // if(zflag)
				else {
					for(int i = 0; i < 5; i++) {
						for(int j = 0; j < 5; j++) {
							if (blockGrid[i, j] == 0) { // spot is empty
								x = i;
								z = j;
								h = blockGrid [x, z];
								
								blockCount++;
								blockGrid [x, z]++;
								return new Vector3 (x, h, z);
							} // if (blockGrid[i, j] == 0)
						} // for(int j = 0; j < 5; j++)
					} // for(int i = 0; i < 5; i++)
				} // else (!zflag)
			} // else (!xflag)
		} // less than 25 blocks

		do{
			flag = false;
			x = Random.Range (0, 5);
			z = Random.Range (0, 5);
			if (blockGrid [x, z] > 3)
				flag = true;
		} while (flag == true);
		h = blockGrid [x, z];
		blockCount++;
		blockGrid [x, z]++;
		return new Vector3 (x, h, z);
	}

	public int getHeight(GameObject block_obj) {
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				for (int k = 0; k < 5; k ++) {
					if (blocks[i,j,k] == block_obj)
						return k;
				}
			}
		}
		return 6;
	}

	public void removeBlock(GameObject block) {
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				for (int k = 0; k < 5; k ++) {
					if (blocks[i,j,k] == block) {
						Destroy(block);
						blockCount--;
						blockGrid[i,j]--;
					}
				}
			}
		}

	}


	public void removeRow () {
		bool flag = true;	// remove row if true

		for(int i = 0; i < 5; i++) // check if bottom row is full
			for(int j = 0; j < 5; j++)
				if (blockGrid[i, j] == 0) {
					flag = false;
				}

		if (flag == true) { // remove the bottom row
			for (int i = 0; i < 5; i++) {
				for(int j = 0; j < 5; j++) {
					Destroy(blocks[i, j, 0], 2);
					//apply destruction effects here
					blockCount--;
					blockGrid[i, j]--;
					for (int k = 0; k < blockGrid[i, j]; k++){
						blocks[i,j,k] = blocks[i,j,k + 1];
						blocks[i,j,k].layer = k+8;
						blocks [i,j,k].GetComponent<Projector> ().ignoreLayers = (1 <<(k + 8));
					}
				}
			}
		}
	}


}
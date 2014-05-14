using UnityEngine;
using System.Collections;

public class AbilityUse : MonoBehaviour {

	int ability;
	/*
	 * 0 = No Ability
	 * 1 = Farther Push
	 * 2 = Pull
	 * 3 = Stun
	 * 4 = Slow Bomb
	 * 5 = Higher Jump
	 * 6 = Farther Jump
	 * 7 = No Jump
	 * 8 = Directions Reversed
	 */

	int getAbility(){
		return ability;
	}

	public void setAbility(int x){
		ability = x;
	}

	// Use this for initialization
	void Start () {
		ability = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ability == 5 || ability == 6 || ability == 7 || ability == 8){
			StartCoroutine(resetBuff ());
		}
	}
	IEnumerator resetBuff(){
		//Debug.Log("Before Waiting 5 seconds");
		yield return new WaitForSeconds (5);
		//Debug.Log("After Waiting 5 seconds");
		ability = 0;
	}
}

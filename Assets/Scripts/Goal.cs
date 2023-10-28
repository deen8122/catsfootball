using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class Goal : MonoBehaviour {
	public bool isLeftGoal = false;
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == Constants.BallTag ){
			GameManager.instance.Goal (this.isLeftGoal);
		}


	}

}

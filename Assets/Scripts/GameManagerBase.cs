using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class GameManagerBase : MonoBehaviour {
	//public int test = 0;
	public static GameState CurrentGameState = GameState.Playing;
	public GameObject[] CurrnetCats;
	public GameObject[] AllCats;
	public GameGUI	mGameGUI ;
	protected GameObject Sel = null;
	public int GAME_MODE = 0;//1 - PVP 0 - PVS
	protected int SCORE_PLAYER = 0;
	protected int SCORE_ENEMY = 0;
	protected bool isMovePlayer = true;
	//------------------------------------------------------------------


	public bool OnMouseDown(Vector3 mousePos){
		if (GAME_MODE == Constants.ALL_CATS_DISACTIVATE || (GAME_MODE == Constants.GAME_MODE_PVS && isMovePlayer == false))
			return false;
		print ("GM - OnMouseDown...");
		if(GameManager.CurrentGameState == GameState.PressedObj){
			print ("Обьект выбран, нет необходимтости искать...");
			return false;
		}
		float R =1f;
		float distance = 0;
		cat2[] playeryGO = GameObject.FindObjectsOfType<cat2>() as cat2[];

		for (int i = 0; i < playeryGO.Length; i++) {
			if(playeryGO[i].gameObject == null) continue;
			if(playeryGO[i].isLock == false){
				mousePos.z = 0;
				distance = Vector2.Distance(mousePos, playeryGO[i].gameObject.transform.position);
				//print (distance);
				//print ("mousePos="+mousePos.ToString()+" playeryGO="+playeryGO[i].gameObject.transform.position.ToString()+ " distance="+distance);
				if(distance < R){
					R = distance;
					Sel = playeryGO[i].gameObject;
				}
			}

		}
		if(Sel !=null) {

			Sel.GetComponent<Fire>().TouchDown();
			return true;
		}else return false;
	}

	public void onMouseUp(){
		if (GAME_MODE == Constants.ALL_CATS_DISACTIVATE || ( GAME_MODE == Constants.GAME_MODE_PVS && isMovePlayer == false) )
			return;
		if(Sel!=null){
			Sel.GetComponent<Fire>().TouchUp();
			Sel = null;
		}
	}



	enum pos { x,y}
	protected void SetINitPosition(){
		Vector2[] posA = new Vector2[]{ new Vector2(-2,0) ,new Vector2(-3,1) ,new Vector2(-3,-1),new Vector2(-4,0),new Vector2(-4,1),new Vector2(-4,-1)};
		GameObject[] playeryGO = GameObject.FindGameObjectsWithTag(Constants.PlayerTag);
		for (int i = 0; i < playeryGO.Length; i++) {
			playeryGO [i].gameObject.transform.position = posA[i];	
		}
		Vector2[] posB = new Vector2[]{ new Vector2(2,0) ,new Vector2(3,1) ,new Vector2(3,-1),new Vector2(4,0),new Vector2(4,-1),new Vector2(4,1)};
		playeryGO = GameObject.FindGameObjectsWithTag(Constants.EnemyTag);
		for (int i = 0; i < playeryGO.Length; i++) {
			playeryGO [i].gameObject.transform.position = posB[i];	
		}
	}


	public void LockCats(string tagName){
		print ("LockCats ->" + tagName);
		GameObject[] playeryGO = GameObject.FindGameObjectsWithTag(tagName);
		for (int i = 0; i < playeryGO.Length; i++) {
			playeryGO [i].gameObject.GetComponent<cat2> ().Lock ();	
		}
	}
	public void UnlockCats(string tagName){
		print ("UnlockCats ->" + tagName);
		GameObject[] playeryGO = GameObject.FindGameObjectsWithTag(tagName);
		CurrnetCats = playeryGO;
		for (int i = 0; i < playeryGO.Length; i++) {
			playeryGO [i].gameObject.GetComponent<cat2> ().Unlock ();	
		}
	}
	public int GetCatsCount(string tagName){
		GameObject[] playeryGO = GameObject.FindGameObjectsWithTag(tagName);
		return playeryGO.Length;
	}
}

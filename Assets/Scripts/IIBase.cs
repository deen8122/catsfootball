using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class IIBase : MonoBehaviour {
	public GameObject[] playeryGO;
	public GameObject[] enemyGO;
	public int selectedObj = 0;
	//public GameObject ball;

	void Start () {
		playeryGO = null;
		enemyGO = null;
		//ball = GameObject.FindGameObjectWithTag( Constants.BallTag);
	}
	public bool CheckCanDoPassToNearGoal (){

		return false;
	}
	//Оцениваем удар в сторону ворот
	public bool CheckCanDoPassToGoal(){
		GameObject goal = GameObject.Find ("goal-left");
		float D = Random.Range (3f, 5f);
		if (Vector2.Distance (playeryGO [selectedObj].transform.position, goal.transform.position) <= D) {
			return true;

		}
		return false;

	}
	//Есть ли игроки рядом с мячом
	public bool isPlayersNearBall(float R = 1.5f){
		bool f = false;
		for (int i = 0; i < playeryGO.Length; i++) {
			if (playeryGO[i].GetComponent<cat2>().isPassBall == true)
				continue;
			if (Vector2.Distance(playeryGO[i].transform.position, Ball.instance.transform.position) < R) {
				print ("Есть рядом с мячом  кто то то не нужно снова бежать к мячу!");
				f = true;
			}

		}
		return f;
	}
	//Ищем кому можно передать пас
	public int CheckToDoPass(){


		print ("CheckToDoPass --------------------->");
		int sel = -1;
		float distanceMin =4f;
		float dist = 0;
		for (int i = 0; i < playeryGO.Length; i++) {
			if (selectedObj == i)
				continue;
			if (playeryGO[i].GetComponent<cat2>().isHasBall == true)
				continue;
			dist = Vector2.Distance(playeryGO[selectedObj].transform.position, playeryGO[i].transform.position);
			if (dist < distanceMin && !isEnemyInWay (playeryGO[selectedObj] , playeryGO[i].transform.position)) {
				distanceMin = dist;
				sel = i;
			}

		}

		//		print ("CheckToDoPass ---------------------> sel="+sel+" distanceMin="+distanceMin+" - "+playeryGO [sel].name);
		return sel;

	}
	public void DoPassToGoal(){
		print ("DoPassToGoal");

		BallToPoint (new Vector2(-7,Random.Range(-0.5f,0.5f)));

	}









	public void BallToPoint(Vector3 pos){
		pos = correctingPoint (pos);
		playeryGO [selectedObj].GetComponent<cat2> ().StartShoot ();
		playeryGO [selectedObj].GetComponent<Fire> ().TouchDown ();
		var maxPosition = -(playeryGO [selectedObj].transform.position - pos).normalized * 0.6f + playeryGO [selectedObj].transform.position;
		Ball.instance.transform.position = maxPosition;

		print ("BallToPoint ---------------------> pos="+pos.ToString());
		playeryGO [selectedObj].GetComponent<Fire> ().SetPosAttackPosition (pos);
		playeryGO [selectedObj].GetComponent<Fire> ().TouchUp ();
	}
	private int colled = 0;
	public Vector2 correctingPoint(Vector2 point){
		colled++;
		if (colled > 20) {
			colled = 0;
			return point;
		}
		print ("........................................correctingPoint "+colled+"  "+point.ToString()+"...........................................");
		bool f = false;
		Vector2 retPoint = new Vector2 (0,0);

		for (int i = 0; i < enemyGO.Length; i++) {
			if(isPointInCircle(point,enemyGO [i].transform.position,2.5f) ){
				f = true;
			}
		}
		if (f) {
			//print ("........................................correctingPoint  f=true ...........................................");
			float angle = Vector3.Angle(point, transform.forward);
			//print (angle);
			angle+=1;
			point = RotatePointAroundPivot (point,playeryGO [selectedObj].transform.position,new Vector3(angle,angle,angle));
			correctingPoint (point);
		}
		colled = 0;
		return point;

	}


	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		return Quaternion.Euler(angles) * (point - pivot) + pivot;
	}

	public bool  isPointInCircle(Vector2 point ,Vector2 center, float R){
		if ((point.x - center.x) * (point.x - center.x) + (point.y - center.y) * (point.y - center.y) <= R * R) {
			return true;
		} else
			return false;

	}




	//Пас Игроку , передаем его номер
	public void DoPassToCat(int num){
		print ("DoPassToCat ---------------------> передает "+playeryGO [selectedObj].name+" принимает "+playeryGO [num].name);
		playeryGO [selectedObj].GetComponent<cat2> ().StartShoot ();
		playeryGO [selectedObj].GetComponent<Fire> ().TouchDown ();


		Vector3 pos = playeryGO [num].transform.position;

		var maxPosition = -(playeryGO [selectedObj].transform.position - pos).normalized * 0.6f + playeryGO [selectedObj].transform.position;
		Ball.instance.transform.position = maxPosition;

		print ("DoPassToCat ---------------------> pos="+pos.ToString());
		playeryGO [selectedObj].GetComponent<Fire> ().SetPosAttackPosition (pos);
		playeryGO [selectedObj].GetComponent<Fire> ().TouchUp ();
	}

	//Бежим к мячу
	public void MoveToBall(int num){

	}
	//Бежим к  точке
	public void MoveToPoint(GameObject o, Vector2 point,float force = 1){
		print ("II MoveToPoint "+point.ToString());
		o.GetComponent<cat2> ().StartShoot ();
		o.GetComponent<Fire> ().TouchDown ();
		o.GetComponent<Fire> ().SetPosAttackPosition (force*point);
		o.GetComponent<Fire> ().TouchUp ();
	}
	//
	public float GetDistanceToBall(int num){
		return  Vector2.Distance(playeryGO[num].transform.position, Ball.instance.transform.position);

	}

	public float GetDistanceToPoint(int num){
		GameObject goal = GameObject.Find ("goal-left");
		return  Vector2.Distance(playeryGO[num].transform.position, new Vector2(-6.5f,0));

	}
	//проверяет есть ли на пути противник!
	public bool isEnemyInWay(GameObject player , Vector2 way){
		RaycastHit2D hit = Physics2D.Raycast(player.transform.position, way);
		if (hit.collider != null) {
			if (hit.collider.gameObject.tag == Constants.PlayerTag) {
				return true;

			}
		}
		return false;
	}


	//Есть ли у кого мяч?
	public bool isBallinPlayer(){
		bool f = false;
		for (int i = 0; i < playeryGO.Length; i++) {
			if (playeryGO [i].GetComponent<cat2> ().isPassBall) {
				f = true;
				break;
			}
		}
		if (f)
			print ("isBallinPlayer  Y");
		else
			print ("isBallinPlayer  N");
		return f;
	}



	/*
	 * Двигаемся поближе к мячу. 
	 * Но при этом используем стратегию.
	 */ 

	public void MoveToBallNear(int numGO){
		//Если мячь больше нуля. ТО есть ближе к воротам не надо бежать на за ним, а занимать позицию поближе
		//к воротам и чтоб могли передать пас.
		print ("MoveToBallNear ");
		float randX = Ball.instance.transform.position.x;
	
		float F = 1;

		float randY = 0;

		if (playeryGO [numGO].transform.position.y < Ball.instance.transform.position.y) {
			randY =  Random.Range (1f, 5f);
		} else {
			randY = Random.Range (-5f, -1f);
		}

		randY = Ball.instance.transform.position.y - randY;
		//Если рядом с мячом есть кто то то не нужно снова бежать к мячу!
		if (isPlayersNearBall ()) {
			
			if (playeryGO [numGO].transform.position.y > Ball.instance.transform.position.y) {
				randY = Ball.instance.transform.position.y + Random.Range (1f, 3f);
			} else {
				randY = Ball.instance.transform.position.y + Random.Range (-5f, 0f);
			}

		}


		float X = playeryGO [numGO].transform.position.x - Ball.instance.transform.position.x;
		if (playeryGO [numGO].transform.position.x > Ball.instance.transform.position.x) {
			F = Random.Range (0f, 1f);
			X = playeryGO [numGO].transform.position.x - Random.Range (2f, 10f);

		} else {

			X = playeryGO [numGO].transform.position.x - Random.Range (-1f, 1f);

		}
		MoveToPoint (playeryGO [numGO], new Vector2 (X, randY));

	}




}

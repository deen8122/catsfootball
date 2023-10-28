using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class II : IIBase
{


	/*
	 * 
	 * Вызывается после остановки игрока.
	 * 
	 */
	public void DoneMove ()
	{
		print ("II DoneMove");
		Move ();
	}


	//Начало хода
	public void Move ()
	{
		print ("::::::::::::::::::::::::::::::::II Move::::::::::::::::::::::::::::::::");
			playeryGO = GameObject.FindGameObjectsWithTag (Constants.EnemyTag);
			enemyGO = GameObject.FindGameObjectsWithTag (Constants.PlayerTag);
		//print (playeryGO.Length);

		bool isHasPassBall = isBallinPlayer ();
		float distanceMin = 5;
		float distance = 0;
		bool canMove = false;
		bool canPass = false;
		selectedObj = -1;

		for (int i = 0; i < playeryGO.Length; i++) {				
			if (playeryGO [i].GetComponent<cat2> ().isMoved)
				continue;
			canMove = true;
			//если у одног есть мяч то просто двигаемся поближе
			if (isHasPassBall) {
				MoveToBallNear (i);
				return;
			
			} else {
				//Ищем того кто ближе к мячу!
				distance = GetDistanceToBall (i);
				if (distance < distanceMin) {
					distanceMin = distance;
					selectedObj = i;
				} 
			}


		}//for


		//Нет игроков близких к мячу
		if (selectedObj == -1) {
			for (int i = 0; i < playeryGO.Length; i++) {				
				if (playeryGO [i].GetComponent<cat2> ().isMoved)
					continue;
				selectedObj = i;
				break;
			}
		}
		//---
		print("1===================== selectedObj="+selectedObj);
		if (canMove) {
			GoToBall (playeryGO [selectedObj]);
			return;
		}

		for (int i = 0; i < playeryGO.Length; i++) {
			if (playeryGO [i].GetComponent<cat2> ().isPassBall == true) {
				selectedObj = i;
				canPass = true;
				break;

			}

		}
		print("2===================== selectedObj="+selectedObj);
		/*
		 * Если все походили то ищем кому передать пас или же если не кому
		 * то или бьем по воротам  или уводим мячь в сторону.
		 */
		if (canPass) {
			//ПРОВЕРКА, ЕСЛИ ВОРОТА РЯДОМ ТО БЬЕМ ПО ВОРОТАМ!!!!
			float d  = Random.Range (4f, 5.5f);

			float d2 = GetDistanceToPoint (selectedObj);
			print("3===================== d2="+d2+"  d="+d);
			if (d2 < d) {

				DoPassToGoal ();
				return;
			}
		}
		if (canPass && !canMove) {
			int n = CheckToDoPass ();
			//n = -1;
			if (n >= 0) {
				//Передаем пас коту п
				DoPassToCat (n);
			} else {
				
				if (CheckCanDoPassToGoal ()) {
					DoPassToGoal ();
				} else {
					PlayWithBall ();

				}
			}

		}

	}









	/*
	 * Играем с мячом.
	 * Варинаты:
	 * 1 бьем ближе к вортом но чтобы противник не мог перехватить
	 * 2 Оставляем рядом, но закрываемся от противника
	 * 
	 */
	public void PlayWithBall(){
		int min = 0;
		int max = 0;
		int minDE = -1;

		int MODE = Random.Range (0, 5);
		print ("MODE ="+MODE);
		//MODE = 0;
		switch (MODE) {
		//Бьем наугад в сторону ворот
		case 0:
			print ("Бью по воротам"+MODE);
			GameObject goal1 = GameObject.Find ("goal-left");
			Vector2 pos1 =( goal1.transform.position - playeryGO [selectedObj].transform.position).normalized * 5.2f + playeryGO [selectedObj].transform.position;
			BallToPoint (pos1);
			break;
		case 1:
		case 2:
		case 3:
		case 4:
			for (int i = 0; i < enemyGO.Length; i++) {
				if(Vector2.Distance (playeryGO [selectedObj].transform.position, enemyGO [i].transform.position)   <= 2){
					minDE = i;
				}
			}
			if (minDE >= 0) {
				print ("Противник рядом. Прячу мяч"+minDE);
				Vector2 pos =-1*(enemyGO [minDE].transform.position - playeryGO [selectedObj].transform.position).normalized * 0.1f + playeryGO [selectedObj].transform.position;
				print (pos.ToString());
				BallToPoint (pos);

			} else {
				print ("Противник далеко. Бью в торону ворот"+minDE);
				GameObject goal = GameObject.Find ("goal-left");
				Vector2 pos =( goal.transform.position + playeryGO [selectedObj].transform.position).normalized * 5.2f + playeryGO [selectedObj].transform.position;
				print (pos.ToString());
				BallToPoint (pos);
			}
			break;
		default:
			BallToPoint (new Vector2(2, Random.Range(-3,3)));
			break;
		}


	}
	public void GoToBall (GameObject o)
	{

		o.GetComponent<cat2> ().StartShoot ();
		o.GetComponent<Fire> ().TouchDown ();
		o.GetComponent<Fire> ().SetPosAttackPosition (Ball.instance.transform.position);
		o.GetComponent<Fire> ().TouchUp ();

	}
		



}

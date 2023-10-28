using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using System.Linq;
//using UnityEditor;

public class GameManager : GameManagerBase {
	
	//====================================================================================================================
	IEnumerator CheckMoveds(){
		yield return new WaitForSeconds(1f);
		if (CurrnetCats [0] != null) {

			if (MOVE >= CURRENT_MAX_COL) {
				bool f = true;
				int N = CurrnetCats.Length;
				int countStay = 0;
				for (int i = 0; i < N; i++) {
					//Если мяч и игроки без движения!
					if (Ball.instance.GetComponent<Rigidbody2D> ().velocity.sqrMagnitude <= Constants.MinVelocity
					   && CurrnetCats [i].gameObject.GetComponent<Rigidbody2D> ().velocity.sqrMagnitude <= Constants.MinVelocity) {
						countStay++;
					}
				}
				//ЕСЛИ ВСЕ ОСТАНОВИЛИСЬ
				if (countStay == N) {
					for (int i = 0; i < N; i++) {
						//Если хотя бы у кого есть мяч
						//print (N+" ///////////////////////////////////////////// "+CurrnetCats [i].gameObject.tag+" :" +CurrnetCats [i].gameObject.GetComponent<cat2> ().isPassBall);
						if (CurrnetCats [i].gameObject.GetComponent<cat2> ().isPassBall == true) {
							//print ("/////////////////////////////////////////////GM есть мяч");
							f = true;
							break;
						} else {
							//print ("--------------------------------------------------GM нет мяч");
							f = false;
						}
					
					}

				}



				if (f) {
					//StartCoroutine (CheckMoveds ());
					if (!isMovePlayer && countStay == N) {
						if (GAME_MODE == Constants.GAME_MODE_PVS) {
							GetComponent<II> ().DoneMove ();
						}
					}
				} else {
					//print ("======================================>GM Все ходы сделаны... пасс тоже");
					StartMove ();
				}
			}// 

			StartCoroutine (CheckMoveds ());
		}
	}
	//Вызывается после хода кота
	public void DoMove(){MOVE++;
		
	}

	//Гооол!!! 
	public void Goal(bool isLeftGoal){
		if (isLeftGoal) {
			SCORE_ENEMY++;

		} else {
			SCORE_PLAYER++;
		}

		PlayerPrefs.SetInt ("SCORE_PLAYER",SCORE_PLAYER);
		PlayerPrefs.SetInt ("SCORE_ENEMY",SCORE_ENEMY);
		//GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI>().setScoreText ();
		if (PlayerPrefs.GetInt ("isMovePlayer", 1) == 1) {

			PlayerPrefs.SetInt ("isMovePlayer", 0);
		} else
			PlayerPrefs.SetInt ("isMovePlayer", 1);

		GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().setScoreText ();
		if (SCORE_PLAYER >= 3) {
			
			if (this.GAME_MODE == Constants.GAME_MODE_PVP) {
				PVPGameDone (1);
			}else PlayerWon ();

		} else if (SCORE_ENEMY >= 3) {
			if (this.GAME_MODE == Constants.GAME_MODE_PVP) {
				PVPGameDone (2);
			}else PlayerLost ();


		} else {
			GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().ShowGaolText ();
			StartCoroutine (Reload2SEc ());
		}
	}


	IEnumerator Reload2SEc() {		
	yield return new WaitForSeconds(2f);
		Application.LoadLevel (Application.loadedLevel);
		//GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().RealoadGame ();

}
	public void StopingPlayer(){
		if (!isMovePlayer) {
			if (GAME_MODE == Constants.GAME_MODE_PVS) {
				GetComponent<II> ().DoneMove ();
			}
		}
	}
	//Вызывается после хода и паса кота
	public void DoneMove(){
		//MOVE++;
	}

		
	void Awake (){
		print ("---------------------------------------------Awake--------------------------------------------------");

		//PlayerPrefs.SetInt (Constants.CurrentLevelName, 0);
		if (instance == null) {
			instance = this;
			instance.InitGame ();
		}
		else if (instance != this) {
			instance.InitGame ();
			Destroy (gameObject);
		
		}

		//StartCoroutine (instance.StartAfter1Sec());
		DontDestroyOnLoad (gameObject);

	}
	IEnumerator StartAfter1Sec() {		
		yield return new WaitForSeconds(0.5f);
		instance.InitGame ();

	}
	//----------------------------------------------------------------------
	void ResetGameData(){
		print ("---------------------------------------------ResetGameData--------------------------------------------------"+PlayerPrefs.GetInt ("RESET").ToString());
		if (PlayerPrefs.GetInt ("RESET") == 1) {
			PlayerPrefs.SetInt ("RESET", 0);
			PlayerPrefs.SetInt ("SCORE_PLAYER", 0);
			PlayerPrefs.SetInt ("SCORE_ENEMY", 0);
			SCORE_PLAYER = 0;// PlayerPrefs.GetInt ("SCORE_PLAYER",0);
			SCORE_ENEMY =0;// PlayerPrefs.GetInt ("SCORE_ENEMY",0);
		}


	}
	void InitGame(){
		
		print ("---------------------------------------------InitGame--------------------------------------------------");
		Time.timeScale = 1;
		ResetGameData ();
		this.GAME_MODE = PlayerPrefs.GetInt ("GAME_MODE", 1);
		mGameGUI = GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI>();
		if (PlayerPrefs.GetInt ("isMovePlayer", 1) == 1) {
			isMovePlayer = true;
		} else
			isMovePlayer = false;
		//isMovePlayer = false;
		//print ("StartCoroutine (StartMoveAfter1Sec())   1 ");
		if (this.GAME_MODE != Constants.GAME_MODE_PVP) {
			CreateEnemies ();
		}
		SetINitPosition ();
		StartCoroutine (instance.StartMoveAfter1Sec());

	}

	private void CreateEnemies(){
		LevelsData _levelsData = new LevelsData ();
		int currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevelName);
		Level _level = _levelsData.GetLevelData(PlayerPrefs.GetInt(Constants.CurrentLevelName));
		print ("InitGame: currentLevel="+currentLevel+" "+_level.levelName + "_level.enemy.Length="+_level.enemy.Length);
		GameObject go;
		for (int i = 0; i < _level.enemy.Length; i++) {
			print (_level.enemy[i].Name);
			go = Instantiate(Resources.Load(""+ _level.enemy[i].Name+"")) as GameObject;
			//Object pf = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Perfabs/"+ _level.enemy[i].Name+".prefab", typeof(GameObject));
			//go = Instantiate(pf, Vector3.zero, Quaternion.identity) as GameObject;
			go.GetComponent<Fire> ().ThrowSpeed = _level.enemy [i].PassForce;
			go.GetComponent<Fire> ().MoveSpeed = _level.enemy [i].SpeedForce;
		}

	}
	public void RealoadGame(){
		InitGame ();
	}
	//----------------------------------------------------------------------
	public void  StartMove(){
		//print ("======================================>StartMove");
		if (isMovePlayer)
			isMovePlayer = false;
		else
			isMovePlayer = true;
		MOVE = 0;
		GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().SetFlagActive (isMovePlayer);
		PLAYER_CAT_COL = GetCatsCount (Constants.PlayerTag);
		ENEMY_CAT_COL =  GetCatsCount (Constants.EnemyTag);
		//print ("======================================>StartMove" +PLAYER_CAT_COL+":"+ENEMY_CAT_COL);
		if (isMovePlayer) {
			UnlockCats (Constants.PlayerTag);
			LockCats (Constants.EnemyTag);
			CURRENT_MAX_COL = PLAYER_CAT_COL;


		} else {
			UnlockCats (Constants.EnemyTag);
			LockCats (Constants.PlayerTag);
			CURRENT_MAX_COL = ENEMY_CAT_COL;
			if (GAME_MODE == Constants.GAME_MODE_PVS) {
				GetComponent<II> ().Move ();
			}
		}

		StartCoroutine (CheckMoveds());
	}
	IEnumerator StartMoveAfter1Sec() {		
		yield return new WaitForSeconds(0.5f);
		//print ("StartCoroutine (StartMoveAfter1Sec())  2");
		instance.StartMove ();

	}





	[HideInInspector]
	public bool isEnemy = false;
	Vector2 pointTo;
	private GameObject[] enemyGO;
	private GameObject MainCamera;

	[HideInInspector]
	public int ENEMY_CAT_COL = 1;
	[HideInInspector]
	public int PLAYER_CAT_COL = 1;
	[HideInInspector]
	private int CURRENT_SHOTER = 0;

	[HideInInspector]
	public static GameManager instance = null;  
	public int MOVE =1;
	private int CURRENT_MAX_COL = 10;


	




	//-------------------------------------
	IEnumerator WaitFOR() {
		print(Time.time);
		yield return new WaitForSeconds(0.5f);
		print(Time.time);
	}


	public void PlayerWon(){  
		
		GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().PlayerWon ();
		//this.GAME_MODE = Constants.ALL_CATS_DISACTIVATE;
		int CurrentLevel = PlayerPrefs.GetInt(Constants.CurrentLevelName);
		CurrentLevel++;
		print ("level-" + CurrentLevel);
		PlayerPrefs.SetInt("level-"+CurrentLevel,1);
	}

	public void PVPGameDone(int playerNum){
		GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().PVPGameDone (playerNum);
	}
	public void PlayerLost(){
		
		GameObject.FindGameObjectWithTag ("GameCanvas").GetComponent<GameGUI> ().PlayerLost ();
		//wonDialog.SetActive(true);
		//lostDialog.SetActive (true);
	}
	public void NextLevel(){
		PlayerPrefs.SetInt ("RESET", 1);
		print ("NextLevel-");
		int CurrentLevel = PlayerPrefs.GetInt(Constants.CurrentLevelName);
		CurrentLevel++;
		PlayerPrefs.SetInt (Constants.CurrentLevelName,CurrentLevel);


	}

}

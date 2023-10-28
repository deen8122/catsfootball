using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
//namespace Completed
//{

public class GameGUI : MonoBehaviour {
		//public static GameGUI instance = null;     //Allows other scripts to call functions from SoundManager.    
	    public GameObject pausedDialog;
		public GameObject wonDialog;
		public GameObject lostDialog;
	public GameObject wonDialogPVP;
	//	public GameObject selectObjectsMenu;
		public GameObject playGameButton;
		private bool isPlaying = false;
	    private GameManager	mGameManager = null;
	public GameObject scoreTextGo;
	private Text scoreText;
	private bool btnBinoklActive = true;

	public GameObject BinoklGameButton;
	public GameObject goalGO;
	private bool isShowGoalText = false;
	private Color C ;
	public Image leftflag;
	public Image righflag;

		
	public void UpdateBinokl(){
		

	}
	public void interactableBinokl(){	
			BinoklGameButton.GetComponent<Button>().interactable = true;	
	}
	public void SetBinokl(){


	}
    public void HideAll(){
			pausedDialog.SetActive(false);
			wonDialog.SetActive(false);
			lostDialog.SetActive (false);
		}
	public void ShowPausedMenu(){

		pausedDialog.SetActive(true);
		Time.timeScale = 0;
	}



    public void StartPlayGame(){
			//selectObjectsMenu.SetActive (false);
			playGameButton.SetActive (false);
			Time.timeScale = 1;
			isPlaying = true;
		    
		   // mGameManager.PlayGameMode();
		}


	public void HidePausedMenu(){

		
		pausedDialog.SetActive(false);
		Time.timeScale = 1;
			if (isPlaying == true) {
				Time.timeScale = 1;
			}
		
		
	}
	public void PlayerWon(){
		print ("PlayerWon");
		wonDialog.SetActive(true);
	}
	public void PlayerLost(){
		print ("PlayerLost");
		//wonDialog.SetActive(true);
		lostDialog.SetActive (true);
	}

	// Use this for initialization
	private Color opacity;
	private Color normal;
	void Start () {
			print ("GameGUI - Start");
			HideAll ();
		mGameManager = GameManager.instance;
		    C = new Color(1, 1, 1, 0.5f);
		    SetBinokl();
		scoreText = scoreTextGo.GetComponent<Text> ();
		setScoreText ();
		//goalGO = GameObject.Find ("GoalText");
		goalGO.SetActive (false);
		//PVPGameDone (0);
		if (wonDialogPVP != null) {
			wonDialogPVP.SetActive (false);
		}
		isShowGoalText = false;
		opacity = new Color (1, 1, 1, 0.4f);
		normal = new Color (1, 1, 1, 1);
		GameObject go = GameObject.Find ("flag-right");
		if (go) {
			righflag = go.GetComponent<Image> ();
			righflag.color =opacity;
		}
		 go = GameObject.Find ("flag-left");
		if (go) {
			leftflag = go.GetComponent<Image> ();
			leftflag.color = opacity;
		}


	}
	public void SetFlagActive(bool isLeft){
		if (isLeft) {
			leftflag.color = normal;
			righflag.color =opacity;
		} else {
			leftflag.color = opacity;
			righflag.color =normal;
		}
	}
	public void PVPGameDone(int playerNum){
		wonDialogPVP.SetActive (true);
		GameObject go = GameObject.Find ("scoretext");
		go.GetComponent<Text> ().text = PlayerPrefs.GetInt ("SCORE_PLAYER",0)+" : "+PlayerPrefs.GetInt ("SCORE_ENEMY",0);;
	}
	public void ShowGaolText(){
		print ("GameGUI - ShowGaolText");
		goalGO.SetActive (true);
		isShowGoalText = true;
		goalGO.transform.localScale = new Vector3(7.2f,7.2f,7.2f);

	}
	public void setScoreText(){
		scoreTextGo.GetComponent<Text> ().text = PlayerPrefs.GetInt ("SCORE_PLAYER",0)+" : "+PlayerPrefs.GetInt ("SCORE_ENEMY",0);

	}
		/*
	 * 
	 *Перезагрузка уровня! 
	 */
		public void RealoadGame(){
			this.HideAll ();
		PlayerPrefs.SetInt ("RESET", 1);
			print ("RealoadGame");
		Application.LoadLevel (Application.loadedLevel);
		   // GameManager.instance.RealoadGame ();
			//Application.LoadLevel (Application.loadedLevel);
		//
	//	Time.timeScale = 1;
			
		}
	public void NextLevel(){
		this.HideAll ();
		print ("NextLevel");
		GameManager.instance.NextLevel ();
		Application.LoadLevel ("1");
		
	}
		//В ГЛАВНОЕ МЕНЮ
		public void GoToMainMenu(){
			this.gameObject.SetActive (false);
			Application.LoadLevel("StartScene");
		}
	// Update is called once per frame
	void Update () {
		if (isShowGoalText) {
			if (goalGO.transform.localScale.x > 1) {
				Vector2 scale = goalGO.transform.localScale;
				scale.x -= 0.1f;
				scale.y -= 0.1f;
				goalGO.transform.localScale = scale;

			}
		}
	}


	/*
	void Awake(){
		wonDialog = GameObject.FindGameObjectWithTag ("dialog_won");
		lostDialog = GameObject.FindGameObjectWithTag ("dialog_lost");
		pausedDialog= GameObject.FindGameObjectWithTag ("dialog_pause");
	}
	*/
}
//}

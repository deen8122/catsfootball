using UnityEngine;
using System.Collections;
using Assets.Scripts;


public class cat2 : MonoBehaviour
{
	public float Health = 70f;
	public Sprite spr2;
	public Sprite spr3;
	public bool isEnemy = true;
	public bool isDie = false;
	public bool lookRight = true;
	public GameObject rot = null;
	public GameObject Strelka = null;
	public bool isLock = false;
	private AudioSource asMeow = null;
	public int catType = 0;
	private bool f_one_check = false;
	[HideInInspector]
	public bool isMoveWidthBall = true;
	public bool isPassed = true;
	public bool isMoved = true;
	public bool isPassBall = false;
	public bool isHasBall = false;
	private bool isCheckStoping= false;
	private SpriteRenderer[] allSprites;


	public void Init(){
		//print ("Init");
		isMoved = true;
		isPassed = true;
		isCheckStoping= false;
	}

	private Color ColorOpacity ;
	private Color ColorInit ;
	public void Unlock(){
		//print ("Unlock");
		isMoved = false;
		isPassed = false;
		isPassBall= false;
		isHasBall = false;
		isLock = false;
		for (int i = 0; i < allSprites.Length; i++) {
			allSprites [i].color = ColorInit;
		}
		//this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1f);
	}
	public void Lock(){
		//print ("Unlock");
		isMoved = true;
		isPassed = true;
		isPassBall= true;
		isHasBall = true;
		//SpriteRenderer[] arr = this.gameObject.GetComponents<SpriteRenderer> ();
		//for(int i = 0; i < arr.Length; i++)
			//arr[i].color = new Color (1, 1, 1, 0.5f);
		for (int i = 0; i < allSprites.Length; i++) {
			allSprites [i].color = ColorOpacity;
		}
	}

	//-------------------------------------------------------------------------------------
	//вызывается при начале выстрела.
	public void StartShoot ()
	{
//		print ("StartShoot catType=" + catType);
		if (catType == 1) {
			f_one_check = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range (-5, 5), Random.Range (0, 6) + 6);
			this.gameObject.layer = LayerMask.NameToLayer ("enemy_bomb");
			//GetComponent<CircleCollider2D> ().isTrigger = true;
		}
	}
	/*
	 * Анимация кота который должен стрелять.
	 */


	public void DoPass(){
		isPassed = true;
		DoneMove ();
	}
	public void DoMove(){
		isMoved = true;
		GameManager.instance.DoMove ();
		DoneMove ();
	}
	public void StopingPlayer(){
		print ("StopingPlayer");
		this.GetComponent<Fire> ().StopMove ();
		GameManager.instance.StopingPlayer ();
	}
	public void DoneMove(){
		if (isMoved && isPassed) {
			isLock = true;

			GameManager.instance.DoneMove ();

		}

	}
	public void  SetStoppedCheck(){
		if (isCheckStoping)
			return;
		isCheckStoping = true;
		//StartCoroutine (BombStoped());
	}
	void FixedUpdate()
	{
		if (!isCheckStoping)
			return;
		//if we've thrown the bird
		//and its speed is very small
		if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
		{
			isCheckStoping = false;
			StopingPlayer ();
			StartCoroutine (BombStoped());
		}
	}

	IEnumerator BombStoped() {	
		yield return new WaitForSeconds(0.5f);
		//Если после остановки не было столкновения с мячом, то пропускаем ход
		if (isPassBall == false) {
			//DoPass ();

		}
		//if(isEnableBombStop){
		//	GameManager.instance.BombStoped();
		//}

		//this.gameObject.transform.position=new Vector3(-1000,1000,this.gameObject.transform.position.z);
	}














	//SoundManager.instance.RandomizeSfx(destroySound1);
	public void AnimateSelected ()
	{

	}

	public void AnimateBombCollision ()
	{
		//GameObject rot = transform.FindChild("rot").gameObject;
		if (rot != null) {
			int deen_rot_noize = Animator.StringToHash ("deen_rot_noize");
		}
	}

	//---------------------------------------------------------------------------------





	void Start ()
	{   
		//print ("cat start...");
		Init ();
		asMeow = GetComponent<AudioSource> ();
		if (asMeow != null) {
			float randomPitch = Random.Range (0.8f, 1.8f);
			asMeow.pitch = randomPitch;
		}
		if (Strelka != null) {
			Strelka.SetActive (false);
			GetComponent<Fire> ().strleka = Strelka;

		}
			
		if (this.lookRight == false) {
			SetLookRight (lookRight);
		}
		allSprites = new SpriteRenderer[5];
		allSprites [0] = this.gameObject.GetComponent<SpriteRenderer> ();
		allSprites = this.gameObject.GetComponentsInChildren<SpriteRenderer> ();
		ColorInit = this.gameObject.GetComponent<SpriteRenderer> ().color;
		ColorOpacity = new Color (ColorInit.r, ColorInit.g, ColorInit.b, 0.6f);
		for (int i = 0; i < allSprites.Length; i++) {
			allSprites [i].color = ColorInit;
		}
	}
	void Awake() {

	}


	public void SetLookRight (bool f)
	{
		this.lookRight = f;
		if (f == false) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			this.GetComponent<Fire> ().napravlenie = -1;
		} else {
			this.transform.localScale = new Vector3 (1, 1, 1);
			this.GetComponent<Fire> ().napravlenie = 1;

		}
	}
	//----------------------------------------------------
	void OnCollisionEnter2D (Collision2D col)
	{
		if (isLock)
			return;
		if (isDie)
			return;
		if (GameManager.CurrentGameState == GameState.CREATE_OBJ) {
			return;
		}
		if (catType == 1 && f_one_check) {
			f_one_check = false;
			if (this.transform.position.x < Ball.instance.transform.position.x) {
				SetLookRight (false);
			} else {
				SetLookRight (true);
			}
		}
		if (col.gameObject.GetComponent<Rigidbody2D> () == null)
			return;

	


		float damage = col.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude * 10;
		if ( (col.gameObject.tag == Constants.PlayerTag || col.gameObject.tag == Constants.EnemyTag) && isHasBall == true) {
			//Ball.instance.hodledGO.isPassBall = false;
			float x = (transform.position.x - col.gameObject.transform.position.x) + transform.position.x;
			float y = (transform.position.y - col.gameObject.transform.position.y) + transform.position.y;
			GetComponent<cat2> ().StartShoot ();
			GetComponent<Fire> ().TouchDown ();
			GetComponent<Fire> ().SetPosAttackPosition (new Vector2(x,y));
			GetComponent<Fire> ().TouchUp ();
			GetComponent<Fire> ().fComputer = false;
		}
		if (col.gameObject.tag == "ball" && isHasBall == false) {
			//this.gameObject.layer = LayerMask.NameToLayer ("ignore_ball");
			BallHold ();
			//SpecialEffectsHelper.Instance.CatEffect (transform.position);
			//SoundManager.instance.RandomizeSfx(destroySound1);
			if (asMeow != null & SoundManager.instance.soundOn) {
				if (!asMeow.isPlaying) {

					//asMeow.Play ();
				}
			}
		}

		AnimateBombCollision ();
	
	}

	//Удерживает мячь для передачи паса
	void BallHold ()
	{
		//GameManager.instance.UnsetOthersBallPass ();
		if (!isHasBall) {
			isPassBall = true;
			isHasBall = true;
		}
		Ball.instance.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		if (Ball.instance.hodledGO!=null && Ball.instance.hodledGO!=this) {
			Ball.instance.hodledGO.isPassBall = false;
		}
		Ball.instance.hodledGO = this;
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	
	}

}

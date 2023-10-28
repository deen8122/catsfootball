using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Fire : MonoBehaviour
{
	public float stretchLimit = 1.0f;
	
	//public LineRenderer stringBack;
	//public LineRenderer stringFront;
	
	private SpringJoint2D spring;
	private bool clicked;
	private Transform slingshot;
	private Ray mouseRay;
	private Ray leftRay;
	private float stretchSquare;
	//	private float radius;
	private Vector2 velocityX;
	private int ACTION = 0;
	private static int MOVE = 1;
	Vector3 pos1;
Vector3 posA;
	public float ThrowSpeed = 22;
	public float MoveSpeed = 18;
	private float distance = 1;
	private float MoveDistacne = 0;
	//public SlingshotState mSlingshotState;
	public bool isEnemy = true;
	private LineRenderer TrajectoryLineRenderer;
	public bool fComputer = false;
	private Vector3 ENEMY_POSITION;
	public Animator AnimatorFired;
	public GameObject strleka = null;
	public int TYPE_CAT = 1;
	public int napravlenie = 1;
	private cat2 _cat;




	void OnDestroy ()
	{
		

	}
	//private SlingshotState slingshotState;
	//------------------------------------------------
	void Start ()
	{
		if (strleka != null)
			strleka.SetActive (false);
		//TrajectoryLineRenderer = GameManager.instance.TrajectoryLineRenderer;
		_cat = this.gameObject.GetComponent<cat2> ();
		
	}

	public void StopMove ()
	{
		MoveDistacne = Vector3.Distance (posA, transform.position);

	}

	public void TouchDown ()
	{
		//print("TouchDown");
		if (_cat.isMoved == true && _cat.isPassed == true) {
			//print("TouchDown 1");
			return;
		}
		if (_cat.isMoved == true && _cat.isPassBall == false) {
			//print("TouchDown 2");
			return;
		}

		GameManager.CurrentGameState = GameState.PressedObj;
		ACTION = MOVE;	
		GameManager.CurrentGameState = GameState.PressedObj;
		pos1 = gameObject.transform.position;
		if (_cat.isMoved == false) {
			posA = gameObject.transform.position;
			MoveDistacne = 0;
		}

	}

	
	public void SetEnemyAttack (Vector3 pos)
	{
		fComputer = true;
		pos1 = pos;
		
	}
	//Точка атаки! 
	public void SetPosAttackPosition (Vector3 pos)
	{
		fComputer = true;
		this.ENEMY_POSITION = pos;		
	}

	public void TouchUp ()
	{
		if (_cat.isMoved == true && _cat.isPassed == true) {
			return;
		}
		if (strleka != null)
			strleka.SetActive (false);
		GameManager.CurrentGameState = GameState.BOMB_FLYING;
		ACTION = 0;
		Vector3 location;
		if (fComputer) {
			location = ENEMY_POSITION;
		} else {
			
			location = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
		location.z = 0;
		distance = Vector3.Distance (gameObject.transform.position, location);
		if (Vector3.Distance (location, gameObject.transform.position) > 0.1f) {			
			//Если управляет комп, то нужно учитывать направление не мыщки а мяча.
			Vector3 maxPosition;
			if (fComputer) {
				maxPosition = (gameObject.transform.position - location).normalized * 0.1f + gameObject.transform.position;
			} else {
				maxPosition = (location - gameObject.transform.position).normalized * 0.1f + gameObject.transform.position;

			}
			location = maxPosition;
		} else {
			this.gameObject.transform.position = location;
		}


		Vector3 velocity = gameObject.transform.position - location;
		if (distance > 2)
			distance = 2;		
		if (_cat.isPassBall) {
			
			//Если есть мяч но еще не походил, то для удара добавим 2 единицы
			//силы.
			if (!_cat.isMoved) {
				MoveDistacne = -2;
			} else {
				if (MoveDistacne > 1)
					MoveDistacne += 1.5f;
			}
			print ("MoveDistacne=" + MoveDistacne);
			Ball.instance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y) * (ThrowSpeed - MoveDistacne) * distance;
			_cat.isPassBall = false;
			StartCoroutine (SetActiveBullet ());
			_cat.DoPass ();

		}

		if (!_cat.isMoved) {
			//print ("Move");
			_cat.DoMove ();
			this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y) * MoveSpeed * distance;
			//Если ходим и пас еще не сделан то  нужно отловить момент  остановки кота
			_cat.SetStoppedCheck ();
		}

		fComputer = false;
		SoundManager.instance.ShootSoundPlay ();
		//GameManager.instance.CatFireEvent ();
	}







	void Update ()
	{
		if (ACTION == MOVE) {
			pos1 = gameObject.transform.position;
			Vector3 location;
			if (fComputer) {
				location = ENEMY_POSITION;
			} else {
				
				location = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			location.z = 0;
			
			//we will let the user pull the bird up to a maximum distance
			if (Vector3.Distance (location, pos1) > 0.2f) {
				//basic vector maths :)
				
				var maxPosition = (location - pos1).normalized * 0.2f + pos1;
				//var maxPosition = (location - pos1).normalized * 0.2f;
				//bombTomato.transform.position = maxPosition;
				if (fComputer) {
					maxPosition = (pos1 - location).normalized * 0.1f + pos1;
				}
			} else {
				//bombTomato.transform.position = location;
			}
			
			distance = Vector3.Distance (pos1, location);
			
			if (strleka != null) {
				if (strleka != null)
					strleka.SetActive (true);
				Vector3 mouse_pos = Input.mousePosition;
				Vector3 player_pos = Camera.main.WorldToScreenPoint (this.transform.position);
				
				mouse_pos.x = mouse_pos.x - player_pos.x;
				mouse_pos.y = mouse_pos.y - player_pos.y;
				
				Vector3 dir = location;
				dir.Normalize ();
				
				float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg + 180;
				
				
				strleka.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
				//	strleka.transform.ro.RotateAround(pos1,location, angle);
				if (_cat.isPassBall) {	
					var maxPosition = -(location - pos1).normalized * 0.6f + pos1;
					Ball.instance.transform.position = maxPosition;
					//ballSprite.transform.rotation = Quaternion.Euler (new Vector3(0, 2, angle));
					//ballSprite.transform.RotateAround(transform.position,zAxis, angle);

				}
			}

			//trleka.transform.rotation = Quaternion.LookRotation(pos1, bombTomato.transform.position);
			
			if (distance > 2)
				distance = 2;
			
			/*
			if(TrajectoryLineRenderer!=null && isEnemy==false){
				if(GameManager.f_bonusPricel == true){
					DisplayTrajectoryLineRenderer2(distance);
				}
			}
*/
			//display projected trajectory based on the distance
			//Debug.Log (distance);
		}
		
	}


	
	void OnMouseDown ()
	{
		if (isEnemy == true)
			return;
		if (GameManager.CurrentGameState == GameState.CREATE_OBJ)
			return;
		if (GameManager.instance.GAME_MODE == Constants.GAME_MODE_PVS)
			return;
		this.TouchDown ();
	}

	void OnMouseUp ()
	{
		if (GameManager.instance.GAME_MODE == Constants.GAME_MODE_PVS)
			return;
		if (isEnemy == true)
			return;
		if (GameManager.CurrentGameState == GameState.CREATE_OBJ)
			return;
		this.TouchUp ();
	}
	
	/*
	void Awake () {
		spring = GetComponent<SpringJoint2D> ();
		slingshot = spring.connectedBody.transform;
		
	}
	
	void Start () {
		StringSetup ();
		mouseRay = new Ray(slingshot.position, Vector3.zero);
		leftRay = new Ray(stringFront.transform.position, Vector3.zero);
		stretchSquare = stretchLimit * stretchLimit;
		CircleCollider2D circleColl = GetComponent<Collider2D>() as CircleCollider2D;
		radius = circleColl.radius;
		
	}
	
	void Update () {
		if (clicked)
			Dragging ();
		
		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && velocityX.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				Destroy (spring);
				GetComponent<Rigidbody2D>().velocity = velocityX;
			}
			
			if (!clicked)
				velocityX = GetComponent<Rigidbody2D>().velocity;
			
			StringUpdate ();
			
		}
		else {
			stringBack.enabled = false;
			stringFront.enabled = false;
		}
	}
	
	void StringSetup () {
		stringBack.SetPosition (0, stringBack.transform.position);
		stringFront.SetPosition (0, stringFront.transform.position);
		stringBack.sortingOrder = 1;
		stringFront.sortingOrder = 5;
		stringBack.sortingLayerName = "Foreground";
		stringFront.sortingLayerName = "Foreground";
	}
	
	void OnMouseDown () {
		spring.enabled = false;
		clicked = true;
		
	}
	
	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		clicked = false;
	}
	
	void Dragging () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 fromSlingshot = mousePos - slingshot.position;
		
		if (fromSlingshot.sqrMagnitude > stretchSquare) {
			mouseRay.direction = fromSlingshot;
			mousePos = mouseRay.GetPoint(stretchLimit);
		}
		
		mousePos.z = 0f;
		transform.position = mousePos;
	}
	
	void StringUpdate () {
		Vector2 projectile = transform.position - stringFront.transform.position;
		leftRay.direction = projectile;
		Vector3 hold = leftRay.GetPoint(projectile.magnitude + radius);
		stringBack.SetPosition(1, hold);
		stringFront.SetPosition(1, hold);
	}
	*/












	IEnumerator SetActiveBullet ()
	{		
		yield return new WaitForSeconds (1f);
		this.gameObject.layer = LayerMask.NameToLayer ("player");
	}

	void DisplayTrajectoryLineRenderer2 (float distance)
	{
		//SetTrajectoryLineRenderesActive(true);
		Vector3 v2 = transform.position - this.gameObject.transform.position;
		int segmentCount = 25;
		float segmentScale = 1;
		Vector2[] segments = new Vector2[segmentCount];

		// The first line point is wherever the player's cannon, etc is
		segments [0] = this.gameObject.transform.position;

		// The initial velocity
		Vector2 segVelocity = new Vector2 (v2.x, v2.y) * ThrowSpeed * distance;

		float angle = Vector2.Angle (segVelocity, new Vector2 (1, 0));
		float time = segmentScale / segVelocity.magnitude;
		for (int i = 1; i < segmentCount; i++) {
			//x axis: spaceX = initialSpaceX + velocityX * time
			//y axis: spaceY = initialSpaceY + velocityY * time + 1/2 * accelerationY * time ^ 2
			//both (vector) space = initialSpace + velocity * time + 1/2 * acceleration * time ^ 2
			float time2 = i * Time.fixedDeltaTime * 5;
			segments [i] = segments [0] + segVelocity * time2 + 0.5f * Physics2D.gravity * Mathf.Pow (time2, 2);
		}

		TrajectoryLineRenderer.SetVertexCount (segmentCount);
		for (int i = 0; i < segmentCount; i++)
			TrajectoryLineRenderer.SetPosition (i, segments [i]);
	}
	
}

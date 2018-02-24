using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMain : MonoBehaviour {

	[SerializeField] private int rotate = 0;
	[SerializeField] private float speed = 0;
	public float bulletSpeed;
	public float shotTime = 2f;
	[SerializeField] private float eyesight = 8f;
	[SerializeField] private GameObject target = null;
	int Xvect = 1;
	public Transform childTransBullet, childTransFire;
	float shotTimeStart, timer;
	CameraManage CamManager;

	void Start () {
		shotTimeStart = shotTime;
		CamManager = GameObject.FindGameObjectWithTag ("Camera").GetComponent<CameraManage> ();
	}
	

	void Update () {
		shotTime -= Time.deltaTime;

		Ray2D ray = new Ray2D (new Vector2 (transform.position.x + .5f * Xvect  , transform.position.y),new Vector2 (Xvect, 0f));
		Ray2D rayDown = new Ray2D (new Vector2 (transform.position.x + 1f * Xvect , transform.position.y-0.5f),new Vector2 (0f, -1f));
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, eyesight);
		Debug.DrawRay (ray.origin, ray.direction);
		ray = new Ray2D (new Vector2 (transform.position.x + .5f * -Xvect  , transform.position.y),new Vector2 (-Xvect, 0f));
		RaycastHit2D hit2 = Physics2D.Raycast (ray.origin, ray.direction, eyesight);
		Debug.DrawRay (ray.origin, ray.direction);
		RaycastHit2D hitDown = Physics2D.Raycast (rayDown.origin, rayDown.direction, 0.5f);
		Debug.DrawRay (rayDown.origin, rayDown.direction);

		DownSight (hitDown);
		LeftRightSight (hit, hit2);
		ActSprite ();

	}


	void LeftRightSight(RaycastHit2D h, RaycastHit2D h2)
	{
		if (h.collider != null) {  //если есть столкновение по направлению взгляда
			if (h.collider.tag != "Ground") { // если столкновение не с землей
				target = h.collider.gameObject; //цель - столкновение
				if (shotTime < 0.5f)  // если до стрельбы меньше 0,5f 
				{
					if (target.name == "Piggy")  // и если цель Piggy
					{
						if (shotTime <= 0)   // если время до стрельбы меньше нуля
						{	
							if (Mathf.Abs ((h.collider.transform.position - transform.position).x) < eyesight - (eyesight / 3)) {
								childTransFire = TransChildAndAct (2); // активировать огонь
								childTransBullet = TransChildAndAct (3); // активировать пулю
								shotTime = shotTimeStart; // скинуть время стрельбы
							} else if (Mathf.Abs ((h.collider.transform.position - transform.position).x) < eyesight - (eyesight / 6)) 
								// если расстояние между столкновением и позицией стрелка меньше взгляда
								Move (); // то двигаться дальше 
							
							target = null; // сброс цели
						}
					} 
					else if (target.name == "Trap")
						Move (); //переделать
					else 
					{
						Move (); // если цель не Piggy и не капкан, то двигаться дальше 
						shotTime = shotTimeStart;
					}
				} else 
					target = null; // если до стрельбы больше 0,5f
			} 
			else 
			{  // если столкновение с землей
				Move ();// то двигаться дальше 
				if (Mathf.Abs ((h.collider.transform.position - transform.position).x) < 2f) Expand (); // если расстояние меньше двух, то развернуть
			}
		} 
		else 
			Move(); // если нет столкновения по направлению взгляда, то двигаться дальше 
		
		if (h2.collider != null)  // если сзади есть столкновение
		{
			if (Mathf.Abs ((h2.collider.gameObject.transform.position - transform.position).x) < eyesight
			    && h2.collider.gameObject.name == "Piggy") 
			{ 
				//  если расстояние между столкновением и позицией охотника меньше взгляда и столкновение с Piggy
				if(timer>=0)
					timer-=Time.deltaTime;
				else
					Expand (); // разворот
			}
		} else {
			timer = 1f;
		}
	}


	void DownSight(RaycastHit2D h){
		if (h.collider == null) Expand (); 
	}


	void Move(){
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}


	void Expand(){
		if (rotate == 0) {
			Xvect = -1;
			rotate = 180;
		} else {
			Xvect = 1;
			rotate = 0;
		}
		transform.localRotation = Quaternion.AngleAxis (rotate, Vector3.up);
	}

	Transform TransChildAndAct(int NumOfChild){
		transform.GetChild (NumOfChild).gameObject.SetActive (true);
		return transform.GetChild ( NumOfChild).gameObject.transform;
	}

	void ActSprite(){
		if (Mathf.Abs (transform.position.x - CamManager.ThisCamTransform.position.x) >
			GameObject.FindGameObjectWithTag ("Camera").GetComponent<Camera> ().orthographicSize * 2 + 2) {
			transform.GetChild (0).gameObject.SetActive (false);
			transform.GetChild (1).gameObject.SetActive (false);
		} else {
			transform.GetChild (0).gameObject.SetActive (true);
			transform.GetChild (1).gameObject.SetActive (true);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

		public Vector3 basePos;
		public float enemySpeed = 1;
		public GameObject ExplosionPrefab;
		public GameObject EnemyMissilePrefab;
		public bool goDown = false;
		public bool isBottom = false;
		public int score = 10;
	public AudioClip shoot;
		private string hitName;
		public bool missileActive;
		private float reloadTime;
		private GameObject Explosion;
		private GameObject enemyMissile;
		private GameManager gm;
		//private float maxBullet = 3;
		


		void OnTriggerEnter2D (Collider2D other)
		{
            if (!other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("Barrier"))
            {
						gm.score += score;
			gm.counter--;
						Destroy (this.gameObject);
						explode ();
						
						

				}

}
		void Awake ()
		{
				gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		}
		// Use this for initialization
		void Start ()
		{

				basePos = this.transform.position;
				missileActive = false;
				reloadTime = Time.time + Random.Range (0f, 10f);

				//transform.Translate (Vector3.right * Time.deltaTime * EnemySpeed);
		}
	
	
		// Update is called once per frame
		void Update ()
		{
				basePos = this.transform.position;

				//dirFlag = this.transform.position.x;
				//transform.Translate (Vector3.right * Time.deltaTime * EnemySpeed);
				if (gm.dirFlag == -1) {
						if (basePos.x > 7) {
									
								basePos.x = 7;
								gm.dirFlag = 1;
								gm.moveDown = true;
								//basePos.y = basePos.y - 0.5f;
						}

						basePos.x += enemySpeed * Time.deltaTime;
						
				} else if (gm.dirFlag == 1) {
						if (basePos.x < -7) {
									
								basePos.x = -7;
								gm.dirFlag = -1;
								gm.moveDown = true;
								//basePos.y = basePos.y - 0.5f;
						}
						basePos.x -= enemySpeed * Time.deltaTime;
				}
				if (goDown) {
						basePos.y -= 0.25f;
						goDown = false;
				}
				this.transform.position = basePos;

            if (gm.counter == 25)
            enemySpeed = 2;
         
            if (gm.counter == 1)
                enemySpeed = 10;
}
		
		void FixedUpdate ()
		{
				SeeBottom ();
				if (Time.time > reloadTime && !missileActive && isBottom) 
                {
						MakeEnemyMissile ();
			GetComponent<AudioSource>().PlayOneShot(shoot);
				}
		}

		void LateUpdate ()
		{
				if (hitName.Contains ("Monster")) {
						isBottom = false;
				} else {
						isBottom = true;
				}
		}
			



		void explode ()
		{
				Explosion = (GameObject)Instantiate (ExplosionPrefab, this.transform.position, Quaternion.identity)as GameObject;
		}
		void MakeEnemyMissile ()
		{
				
				enemyMissile = (GameObject)Instantiate (EnemyMissilePrefab, this.transform.position, Quaternion.identity)as GameObject;
				missileActive = true;
				enemyMissile.transform.parent = this.transform;
				reloadTime = Time.time + Random.Range (0f, 10f);
		}
		void SeeBottom ()
		{

				RaycastHit2D hit = Physics2D.Raycast (new Vector2 (this.transform.position.x, this.transform.position.y - 0.5f), -Vector2.up);
				Debug.DrawRay (this.transform.position, -Vector2.up);
				
				hitName = "       ";
				if (hit.collider != null) 		
						hitName = hit.collider.gameObject.name;
				
		                           




		}
}

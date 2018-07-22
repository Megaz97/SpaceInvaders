using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
		public GameObject[] EnemyPrefab;
		public int numEnemies = 11;
		public int numBarrier = 1;
		public Vector3 enemypos = Vector3.zero;
		public Vector3 secondpos = Vector3.zero;
		public Vector3 finalpos = Vector3.zero;
		public bool moveDown = false;
		public int type;
	    public int counter = 55;
		public bool gamePlay = true;
		public int location;
	    public AudioClip music;
		public int startY = 20;
		public int dirFlag = -1;
		public int score = 0;
		public GameObject ShooterPrefab;
		public int lives = 3;
		public GameObject SaucerPrefab;
		private float respawnTime = 1.0f;
		private float appearTime;
		private GameObject[] frontline;
		public GameObject BarrierPrefab;
		private GameObject[] barrier;
		private GameObject respawn;
		private GameObject saucer; 
		private Enemy em;
        public bool life = true;
        public GameObject BackGround;


		
		// Use this for initialization
		void Start ()
		{

		Time.timeScale = 0;
				
				Respawn ();
				
				
			
				frontline = new GameObject[55]; 
				
				CreateRow (4, 0);
				CreateRow (5, 0);
				CreateRow (6, 1);
				CreateRow (7, 1);
				CreateRow (8, 2);
				
				barrier = new GameObject [5];

				CreateBarriers (1, 2);
				CreateBarriers (1, 6);
				CreateBarriers (1, -2);
				CreateBarriers (1, -6);

				appearTime = Time.time + 30f;

				//respawnTime = Time.time + 3f;

				
		
		}
				
		
		void CreateRow (int location, int type)
		{
				int temp;
				for (int i = 0; i < numEnemies; i++) {
						//enemyrow ((0 * startX) + i, new Vector3 (i * 5 - (8/ 2), startY - (0 * 10)));
						//Debug.Log ("Creating enemy number: " + i);
						enemypos = new Vector3 (i - 5, location, 0);
						temp = numEnemies * (location - 4) + i;
						enemyrow (temp, enemypos, type);

				}
		}

		void CreateBarriers (int location, int Xpos)
		{
				int temp;
				for (int i = 0; i < numBarrier; i++) {
						//enemyrow ((0 * startX) + i, new Vector3 (i * 5 - (8/ 2), startY - (0 * 10)));
						//Debug.Log ("Creating enemy number: " + i);
						secondpos = new Vector3 (i - Xpos, location, 0);
						//temp = numEnemies * (location - 4) + i;
						Appear (0, secondpos);
			
						//Debug.Log (temp + " " + enemypos + " " + type); 
			
				}
		}
		// Update is called once per frame
		void Update ()
		{
          
				//Debug.Log ("score:" + score);
				
				if (gamePlay) {
						if (moveDown) {
								foreach (GameObject monster in frontline) {
										//Debug.Log ("x: " + x);
										if (monster != null)
												monster.GetComponent <Enemy> ().goDown = true;

										
										
								}
						}
						moveDown = false;
				}


				if (respawn == null && lives > -1 && life == false) {
			
						//Debug.Log (lives);
			
						Respawn ();

						lives--;

                       
			
			
				}

				if (saucer == null && Time.time > appearTime) {
						Saucer ();
				}

		if (Input.GetKeyUp ("p") && Time.timeScale == 0) {
                        BackGround.SetActive(false);
						Time.timeScale = 1;
                        GetComponent<AudioSource>().enabled = true;
				} else if (Input.GetKeyUp ("p") && Time.timeScale == 1) {
						Time.timeScale = 0;
				}


		if (lives <= -1) {
						Application.LoadLevel ("Game Over Invaders");
				}
		if (counter == 0 && Time.time > respawnTime) {
			Application.LoadLevel ("Game Over Invaders");
		}
       
        if (life == true)
        {
            respawnTime -= Time.deltaTime;
        }
        if (respawnTime <= 0)
        {
            life = false;
            respawnTime = 1.0f;
        }
        
		}


				

		

		void enemyrow (int startX, Vector3 position, int prefabType)
		{
				frontline [startX] = (GameObject)Instantiate (EnemyPrefab [prefabType], position, Quaternion.identity)as GameObject;
				frontline [startX].name = "Monster " + startX.ToString ("00");
		}


		void Appear (int startZ, Vector3 direction)
		{
				barrier [startZ] = (GameObject)Instantiate (BarrierPrefab, direction, Quaternion.identity)as GameObject;
		}

		void Respawn ()
		{
				respawn = (GameObject)Instantiate (ShooterPrefab, this.transform.position, Quaternion.identity)as GameObject;
				//respawnTime = Time.time + 3f;
			
		}

		void Saucer ()
		{
				saucer = (GameObject)Instantiate (SaucerPrefab, new Vector3 (this.transform.position.x - 7f, this.transform.position.y + 9f, this.transform.position.z), Quaternion.identity)as GameObject;
				appearTime = Time.time + 30f;

		}
		

}


using UnityEngine;
using System.Collections;

public class Saucer : MonoBehaviour
{

		public Vector3 basePos;
		public float enemySpeed = 3f;
		public int dirFlag = 1;
		public int score = 100;
	public AudioClip move;
		private GameManager gm;

		void OnTriggerEnter2D (Collider2D other)
		{	
				if (other.gameObject.CompareTag ("Missile"))
						Destroy (this.gameObject);
				gm.score += score;
			

				//Debug.LogError (other.gameObject.name);
		
		}
		void Awake ()
		{
				gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		}

		// Use this for initialization
		void Start ()
		{

				basePos = this.transform.position;
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				basePos = this.transform.position;
		
				
				if (dirFlag == 1) {
						if (basePos.x > 8) {
				
								basePos.x = 8;
								dirFlag = -1;
                                GetComponent<AudioSource>().Play();
								
						}
			
						basePos.x += enemySpeed * Time.deltaTime;
			
				} else if (dirFlag == -1) {
						if (basePos.x < -8) {
				
								basePos.x = -8;
								dirFlag = 1;
                                GetComponent<AudioSource>().Play();
			
								
						}
						basePos.x -= enemySpeed * Time.deltaTime;
				}
				

				this.transform.position = basePos;
				
				if (this.transform.position.x >= 7) {
						Destroy (this.gameObject);
				}

	
		}
}

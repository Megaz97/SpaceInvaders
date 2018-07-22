using UnityEngine;
using System.Collections;

public class shooterCS : MonoBehaviour
{
		public Vector3 basePos = new Vector3 (0, -0.3f, 0);
		public float minPos = -7;
		public float maxPos = 7;
		public float moveSpeed = 0.1f;
		public GameObject MissilePrefab;
	public AudioClip shoot;
		private GameObject missile;
        private GameManager gm;
        public bool respawn = true;
        public float respawnTime = 2.0f;


        void Awake()
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

		void OnTriggerEnter2D (Collider2D other)
		{
            if (!other.gameObject.CompareTag("Missile"))
            {
                //Debug.Log (other.gameObject.name);
                Destroy(this.gameObject);
                gm.life = true;
            }
				
		}
		// Use this for initialization
		void Start ()
		{
				this.transform.position = basePos;
		}
	
		// Update is called once per frame
		void Update ()
		{
				MoveBase ();
				createMissile ();

                if (respawn == true)
                {
                    respawnTime -= Time.deltaTime;
                }
                if (respawnTime <= 0)
                {
                    respawn = false;
                    respawnTime = 2.0f;
                }

                if (respawn == false)
                    GetComponent<Collider2D>().enabled = true;
		}
	
		void MoveBase ()
		{
				if (Input.GetKey (KeyCode.LeftArrow)) {
						basePos.x = basePos.x - moveSpeed;
			
						if (basePos.x < minPos) 
								basePos.x = minPos;
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						basePos.x = basePos.x + moveSpeed;
						if (basePos.x > maxPos)
								basePos.x = maxPos;
				}
				this.transform.position = basePos;
		}
		void MakeMissile ()
		{
				missile = (GameObject)Instantiate (MissilePrefab, new Vector3 (this.transform.position.x, this.transform.position.y + 0.311f, this.transform.position.z), Quaternion.identity)as GameObject;
		}
		void createMissile ()
		{
				if (Input.GetKey ("space") && missile == null) {
						MakeMissile ();
                        GetComponent<AudioSource>().PlayOneShot(shoot);
				}
		}



}


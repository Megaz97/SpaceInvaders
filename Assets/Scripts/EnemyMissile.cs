using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour
{
	
		public float missileSpeed = 5;
		private Enemy em;
	
	
	
		void OnTriggerEnter2D (Collider2D other)
		{	
				if (!other.gameObject.CompareTag ("Alien")) {
						DestroyMissile ();
						
				}

		}
		
		// Use this for initialization
		void Start ()
		{
		
		
		}
	
		// Update is called once per frame
		void Update ()
		{

				transform.Translate (-Vector3.up * Time.deltaTime * missileSpeed);
				if (this.transform.position.y <= -4)
						DestroyMissile ();

		}
		void DestroyMissile ()
		{
				this.transform.parent.GetComponent<Enemy> ().missileActive = false;
		
				Destroy (this.gameObject);
		}


}

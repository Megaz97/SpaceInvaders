using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
		public float missileSpeed = 10;

		
		
		void OnTriggerEnter2D (Collider2D other)
		{	
				if (!other.gameObject.CompareTag ("Player")) {		
						Destroy (this.gameObject);
				}


				
		
		}
	
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{

				transform.Translate (Vector3.up * Time.deltaTime * missileSpeed);
				if (this.transform.position.y >= 11)
						Destroy (gameObject);
		}

	
}
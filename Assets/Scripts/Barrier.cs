using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{


		void OnTriggerEnter2D (Collider2D other)
		{	
				Destroy (this.gameObject);
		}
		// Use this for initialization
		void Start ()
		{
		}

	
		// Update is called once per frame
		void Update ()
		{
		}

		
}

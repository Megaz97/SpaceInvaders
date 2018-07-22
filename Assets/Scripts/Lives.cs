using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	private GameManager gm;
	
	
	void Awake ()
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = ("Lives = " + gm.lives);

	}
}

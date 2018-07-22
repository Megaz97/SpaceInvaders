using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
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
		GetComponent<TextMesh>().text = ("Score = " + gm.score);

	}
}

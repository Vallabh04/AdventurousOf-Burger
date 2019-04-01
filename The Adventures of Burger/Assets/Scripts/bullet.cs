using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
   [SerializeField] private float speed = 20f;
   
	private Vector2 velocity;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		velocity = Vector2.right * speed * Time.deltaTime;
		transform.Translate (velocity);
	}
}


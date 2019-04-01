using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {
	[SerializeField] private GameObject bulletprefab;
	[SerializeField] private Transform muzzle;

	public float fireRate = 0.5f;

	private float timesincelastfire;
	// Use this for initialization
	void Start () {
		timesincelastfire = 0;
	}
	
	protected virtual void Update()
	{
		Shoot ();
	}

	public void Shoot () {
		if(Input.GetMouseButton(0) && (Time.time > timesincelastfire)) {
			timesincelastfire = Time.time + fireRate;
			GameObject bullet = Instantiate (bulletprefab,muzzle.position,Quaternion.identity);
			bullet.transform.SetParent (muzzle.transform);
	}
}
}
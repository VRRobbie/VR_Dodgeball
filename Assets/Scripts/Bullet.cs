using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		Destroy (gameObject);
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != null) 
		{
			int damage = Random.Range(0, 11);
			if (damage == 0) {
				damage = 50;			
			}
			health.TakeDamage (damage);
			Debug.Log (damage);
		}
	}
}
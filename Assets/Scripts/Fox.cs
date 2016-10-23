using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		
		//leave the method if not colliding with defender
		if(!obj.GetComponent<Defender>()){
			return;
		}
		
		if(obj.GetComponent<Stone>()){
			anim.SetTrigger("jumpTrigger");
		}else{
			anim.SetBool ("isAttacking", true);
			attacker.Attack(obj);
		}	
	}
}

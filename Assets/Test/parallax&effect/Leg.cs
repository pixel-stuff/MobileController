using UnityEngine;
using System.Collections;

public class Leg : MonoBehaviour {
	
	private Animator animator;
	private Vector3 normalPosition;
	
	public GameObject TreeRepere;

	// Use this for initialization
	void Awake () 
	{
		animator = GetComponent<Animator> ();
		normalPosition = this.transform.position;
	}

	public void changePositionForTree(){
		
		if (TreeRepere != null) {
			this.transform.position = TreeRepere.transform.position;
			this.transform.Rotate( new Vector3(0,180,0));
		}
		
	}
	
	public void backToNormal(){
		this.transform.position = normalPosition;
		this.transform.Rotate( new Vector3(0,180,0));
	}


	public void reset(){
		//animator.SetBool ("NoTree",false);
	}
	public void Run() {
		Debug.Log ("RUN");
	
		animator.SetBool ("StartChop",false);
		animator.SetBool ("Run",true);
	}
	
	public void prepareChop() {
		Debug.Log ("Chop");
	
		animator.SetBool ("Run",false);
		animator.SetBool ("StartChop",true);
		
	}

	public void chop(){
		animator.SetTrigger("Chop");
		
	}

	public void restart() {
		if (transform.localRotation.y == 1.0f) {
			backToNormal ();
		}
		Run ();
	}

}

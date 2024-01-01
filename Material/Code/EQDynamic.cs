using UnityEngine;
using System.Collections;

public class EQDynamic : MonoBehaviour {
	public float mass=1f;
	private void Update(){
		if(mass<=0f){
			mass=0.01f;
		}
	}
}

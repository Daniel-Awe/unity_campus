using UnityEngine;
using System.Collections;

public class EQFixed : MonoBehaviour {
	public Vector3 basePos;
	private void Awake(){
		basePos=this.transform.position;
	}
}

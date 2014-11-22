using UnityEngine;
using System.Collections;

public class PalmScript : MonoBehaviour {

    public Vector3 PalmMove;
    public Quaternion PalmRot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        PalmMove = this.transform.position;
        PalmRot = this.transform.rotation;
	}
}

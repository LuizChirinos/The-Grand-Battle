using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardOrthoCam : MonoBehaviour {

    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = transform.position - cam.transform.position;
        transform.forward = -cam.transform.forward;
	}
}

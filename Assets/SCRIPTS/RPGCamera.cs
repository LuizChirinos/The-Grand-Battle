using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGCamera : MonoBehaviour {

	Camera cam;
	Transform camDad;

	[Header("Variáveis para seguir jogador")]
	public Transform player;
	public float distToApproximate;
	public Vector3 velFollow;
	public float maxTime;
	public bool isFollowing;

	[Header("Variáveis de Zoom da Câmera")]
	public float maxZoom;
	public float minZoom;
	public float currentZoom;
	public float scrollVelocity;

    [Header("Variáveis de Rotação Vertical")]
    public float xRotMax;
    public float xRotMin;

    [Header("Variáveis para Rotação de câmera")]
	[SerializeField] float deltaX;
    [SerializeField] float deltaY;
	float yRot;
    float xRot;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		camDad = cam.transform.parent;
		currentZoom = cam.orthographicSize;
		yRot = transform.rotation.y;
        xRot = transform.rotation.x;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Vector3.Distance (transform.position, player.position));

		ScrollZoom();
		RotateCamera();
		FollowPlayer ();
	}

	private void ScrollZoom() 
	{
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
		cam.orthographicSize = currentZoom;

		currentZoom -= Input.GetAxis("Mouse ScrollWheel")*scrollVelocity;
	}

	private void RotateCamera() 
	{
		yRot += deltaX;
        xRot += deltaY;
        xRot = Mathf.Clamp(xRot, xRotMin, xRotMax);
		camDad.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        if (Input.GetMouseButton(1))
        {
            deltaX = Input.GetAxis("Mouse X");
            deltaY = Input.GetAxis("Mouse Y");
        }
        else
        {
            deltaX = 0f;
            deltaY = 0f;
        }


    }

	private void FollowPlayer()
	{
		//if (Vector3.Distance(camDad.position, player.position) > distToApproximate)
		//{
			
		//}

		if (Input.GetKeyDown (KeyCode.Space)) {
			isFollowing = !isFollowing;
		}

		if (isFollowing) {
			Vector3 playerToGo = new Vector3 (player.position.x, camDad.position.y, player.position.z);
			//camDad.position = Vector3.SmoothDamp (camDad.position, playerToGo, ref velFollow, maxTime);
			camDad.position = player.position;
		}
	}
}

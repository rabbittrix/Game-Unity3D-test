using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeArestas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cam = Camera.main;
		EdgeCollider2D colisor = GetComponent<EdgeCollider2D> ();
		Vector2 cantoInferiorEsquerdo = cam.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector2 cantoSuperiorEsquerdo = cam.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		Vector2 cantoSuperiorDireito = cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Vector2 cantoInferiorDireito = cam.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));
		colisor.points = new Vector2[5] {
			cantoInferiorEsquerdo,
			cantoSuperiorEsquerdo,
			cantoSuperiorDireito,
			cantoInferiorDireito,
			cantoInferiorEsquerdo
		}; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

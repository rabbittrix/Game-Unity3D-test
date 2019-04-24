using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

	public Vector3 Direção;
	public float Velocidade;
	public GameObject particulaBlocos;
	public ParticleSystem particulaFolhas;

	// Use this for initialization
	void Start () {
		Direção.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Direção * Velocidade * Time.deltaTime;
		
	}

	void OnCollisionEnter2D (Collision2D colisor){
		bool colisãoInvalida = false;
		Vector2 normal = colisor.contacts [0].normal;
		Plataforma plataforma = colisor.transform.GetComponent<Plataforma> ();
		GeradorDeArestas geradorDeArestas = colisor.transform.GetComponent<GeradorDeArestas> ();
		if (plataforma != null) {
			if (normal != Vector2.up) {
				colisãoInvalida = true;
			} else 
			{
				particulaFolhas.transform.position = colisor.transform.position;
				particulaFolhas.Play ();
			}
				
		} else if (geradorDeArestas != null) {
			if (normal == Vector2.up) {
				colisãoInvalida = true;
			}
		} else 
		{
			colisãoInvalida = false;
			Bounds bordasColisor = colisor.transform.GetComponent<SpriteRenderer> ().bounds;
			Vector3 posiçãoDeCriação = new Vector3 (colisor.transform.position.x + bordasColisor.extents.x, colisor.transform.position.y - bordasColisor.extents.y, colisor.transform.position.z);
			GameObject particulas = (GameObject) Instantiate (particulaBlocos, posiçãoDeCriação, Quaternion.identity);
			ParticleSystem componenteParticulas = particulas.GetComponent<ParticleSystem> ();
			Destroy (particulas, componenteParticulas.duration + componenteParticulas.startLifetime);
			Destroy (colisor.gameObject);

		}
			if (!colisãoInvalida)
			{		
				Direção = Vector2.Reflect (Direção, normal);
				Direção.Normalize ();
			}
			else
		{
			GerenciadorDoGame.FinalizarJogo ();
		}
	}
}

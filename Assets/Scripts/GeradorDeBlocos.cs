using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeBlocos : MonoBehaviour {

	public GameObject[] blocos;
	public int linhas;

	// Use this for initialization
	void Start () {
		CriarGrupoDeBlocos ();
		
	}

	void CriarGrupoDeBlocos()
	{
		Bounds limitesDoBloco = blocos [0].GetComponent<SpriteRenderer> ().bounds;
		float larguraDoBloco = limitesDoBloco.size.x;
		float alturaDoBloco = limitesDoBloco.size.y;
		float larguraDaTela, alturaDaTela, multiplicadorDaLargura;
		int colunas;
		ColetarInformaçõesDoBloco (larguraDoBloco, out larguraDaTela, out alturaDaTela, out colunas, out multiplicadorDaLargura);
		for (int i = 0; i < linhas; i++) 
		{
			for (int j = 0; j < colunas; j++) 
			{
				GameObject blocoAleatorio = blocos [Random.Range (0, blocos.Length)];
				GameObject blocoInstanciado = (GameObject)Instantiate (blocoAleatorio);
				blocoInstanciado.transform.position = new Vector3 (-(larguraDaTela * 0.5f) + (j * larguraDoBloco * multiplicadorDaLargura), (alturaDaTela * 0.5f) - (i * alturaDoBloco), 0);
				float novaLarguraDoBloco = blocoInstanciado.transform.localScale.x * multiplicadorDaLargura;
				blocoInstanciado.transform.localScale = new Vector3 (novaLarguraDoBloco, blocoInstanciado.transform.localScale.y, 1);
			}
		}
	}

	void ColetarInformaçõesDoBloco (float larguraDoBloco, out float larguraDaTela, out float alturaDaTela, out int colunas, out float multiplicadorDaLargura)
	{
		Camera c = Camera.main;
		larguraDaTela = (c.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)) - c.ScreenToWorldPoint (new Vector3 (0, 0, 0))).x;
		alturaDaTela = (c.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0)) - c.ScreenToWorldPoint (new Vector3 (0, 0, 0))).y;
		colunas = (int)(larguraDaTela / larguraDoBloco);
		multiplicadorDaLargura = larguraDaTela/(colunas * larguraDoBloco);
	}

}

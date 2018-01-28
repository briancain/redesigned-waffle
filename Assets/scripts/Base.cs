using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	[SerializeField]
	Material baseMaterial;

	[SerializeField]
	Material muteMaterial;

	[SerializeField]
	MeshRenderer cornerMesh;

	[SerializeField]
	Material playerMaterial;

	[SerializeField]
	Material babbyMaterial;

	[SerializeField]
	Transform spawnPoint;

	//[SerializeField]
	//Babby babbyPrefab;

	public Transform GetSpawnPoint() {
		return spawnPoint;
	}

	public Material GetPlayerMaterial() {
		return playerMaterial;
	}

	public void Activate() {
		// set base color
		cornerMesh.material = baseMaterial;

		// create babbies
	}
	public void Deactivate() {
		// set mute color
		cornerMesh.material = muteMaterial;

		// destroy babbies
	}
}

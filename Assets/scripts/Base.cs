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

  [SerializeField]
  Babby babbyPrefab;

  [SerializeField]
  int babbyCount;

  [SerializeField]
  Vector3 randomness;

  [SerializeField]
  float rmin;
  [SerializeField]
  float rmax;

  List<Babby> babbies;


  public Transform GetSpawnPoint() {
    return spawnPoint;
  }

  public Material GetPlayerMaterial() {
    return playerMaterial;
  }

  void Awake() {
    babbies = new List<Babby>();
  }

  public void Activate() {
    // set base color
    cornerMesh.material = baseMaterial;

    // create babbies
    for(var i=0; i < babbyCount; i++) {
      var babby = Instantiate(babbyPrefab,spawnPoint.position + new Vector3(
        Random.Range(rmin,rmax) * randomness.x,
        Random.Range(rmin,rmax) * randomness.y,
        Random.Range(rmin,rmax) * randomness.z),Quaternion.identity,transform);
      babbies.Add(babby);
    }
  }

  public void Deactivate() {
    // set mute color
    cornerMesh.material = muteMaterial;

    // destroy babbies
    if (babbies != null) {
      for(var i=0; i < babbies.Count; i++) {
        Destroy(babbies[i].gameObject);
      }

      babbies.Clear();
    }
  }
}

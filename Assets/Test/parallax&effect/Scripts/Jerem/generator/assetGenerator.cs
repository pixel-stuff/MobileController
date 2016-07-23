using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class assetGenerator : parralaxAssetGenerator {

	public GameObject prefab;

	public List<GameObject> GameObjectTabOfTypePrefab = new List<GameObject>();

	// Use this for initialization
	public override void clear(){
		GameObjectTabOfTypePrefab.Clear ();
	}


	public override GenerateAssetStruct generateGameObjectWithCode(int code){
		return generateGameObjectAtPosition ();
	}

	public override  GenerateAssetStruct generateGameObjectAtPosition() {
		GameObject asset = availableGameobject (GameObjectTabOfTypePrefab);
		if (asset == null){
			asset = Instantiate (prefab);
			GameObjectTabOfTypePrefab.Add (asset);
		}
		GenerateAssetStruct assetStruct = new GenerateAssetStruct();
		assetStruct.generateAsset = asset;
		assetStruct.code = 0;
		return assetStruct; 
	}

	private GameObject availableGameobject(List<GameObject> list){
		foreach(GameObject gameobject in list){
			if (!gameobject.activeSelf){
				gameobject.SetActive(true);
				return gameobject;
			}
		}
		return null;
	}
}

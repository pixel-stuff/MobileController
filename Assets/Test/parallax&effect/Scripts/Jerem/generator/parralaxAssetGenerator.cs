using UnityEngine;
using System.Collections;

public class GenerateAssetStruct : System.Object
{
	public GameObject generateAsset;
	public int code;
	//public float 
}


abstract public class parralaxAssetGenerator : MonoBehaviour {

	abstract public void clear ();

	abstract public GenerateAssetStruct generateGameObjectWithCode(int code);

	abstract public GenerateAssetStruct generateGameObjectAtPosition();
}

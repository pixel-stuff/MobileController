using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StockAssetStruct : System.Object
{
	public int code;
	public float dist; 
}

abstract public class parallaxPlan : MonoBehaviour {
	public float distance;
	
	public GameObject popLimitation;
	public GameObject depopLimitation;
	public float hightSpaceBetweenAsset = 0;
	public float lowSpaceBetweenAsset = 0;
    public float relativeSpeed;

	public parralaxAssetGenerator generator;

	abstract public void setSpeedOfPlan(float newSpeed);

    abstract public void refreshOnZoom();


}
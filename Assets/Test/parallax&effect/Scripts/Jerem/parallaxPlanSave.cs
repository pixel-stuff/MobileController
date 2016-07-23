using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class parallaxPlanSave : parallaxPlan {
	
	public List<GameObject> visibleGameObjectTab;
	
	public float space;
	
	private float m_initSpeed = 0.1f;
	private bool m_isInit = false;
	
	private float actualSpeed = 0.0f;
	
	private float spaceBetweenAsset = 0.0f;
	private float m_speedMultiplicator;
	
	private int speedSign = 1;

	public List<StockAssetStruct> m_stockAsset;
	public int hightId = -1;
	public int lowId = 0;
	

	// Use this for initialization
	void Start () {
		m_stockAsset = new List<StockAssetStruct>();
		actualSpeed = 1;
		setTheDistanceMultiplicator ();
		generator.clear ();
		hightId=-1;
		generateNewSpaceBetweenAssetValue();
		while (!m_isInit) {
			moveAsset (m_initSpeed);
			generateAssetIfNeeded ();
		}
	}

	void setTheDistanceMultiplicator() {
		if (distance < 0) {
			m_speedMultiplicator = 1/ -distance;//1 - (1 / (1 -distance));
		} else {
			m_speedMultiplicator = 1 +  distance/10;//1 - (1 / (1 + distance));
		}
	}
	
	// Update is called once per frame
	void Update () {
		moveAsset (actualSpeed * m_speedMultiplicator);
		generateAssetIfNeeded ();
	}
	
	void moveAsset(float speed){
		List<GameObject> temp = new List<GameObject>();
		foreach(GameObject g in visibleGameObjectTab) {
			if(!temp.Contains(g)) {
				temp.Add(g);
			}
		}

		for (int i=0; i<temp.Count; i++) {
			GameObject parrallaxAsset = temp[i];
			Vector3 positionAsset = parrallaxAsset.transform.position;
			if (!isStillVisible(parrallaxAsset)){
				if(speedSign >0){
					lowId++;
				}else {
					hightId--;
				}
				parrallaxAsset.SetActive(false);
				visibleGameObjectTab.Remove(parrallaxAsset);
				m_isInit =true;
			} else {
				positionAsset.x -= speed;
				parrallaxAsset.transform.position = positionAsset;
			}
		}
	}

	void generateNewAsset(){
		GenerateAssetStruct assetStruct = generator.generateGameObjectAtPosition();
		GameObject asset = assetStruct.generateAsset;
		asset.transform.parent = this.transform;
		if (speedSign > 0) {
			asset.transform.position = new Vector3 (popLimitation.transform.position.x + (asset.GetComponent<SpriteRenderer> ().sprite.bounds.max.x) - (space - spaceBetweenAsset), popLimitation.transform.position.y, this.transform.position.z);
		} else {
			asset.transform.position = new Vector3 (popLimitation.transform.position.x + (asset.GetComponent<SpriteRenderer> ().sprite.bounds.min.x) + (space - spaceBetweenAsset), popLimitation.transform.position.y, this.transform.position.z);
		}
		visibleGameObjectTab.Add(asset);
		StockAssetStruct stockAssetStruct = new StockAssetStruct();
		stockAssetStruct.code = assetStruct.code;
		stockAssetStruct.dist = spaceBetweenAsset;
		m_stockAsset.Add(stockAssetStruct);
		hightId ++;
		generateNewSpaceBetweenAssetValue();
	}


	void generateOldAsset(int code,float dist){
		Debug.Log("get old Hight");
		GenerateAssetStruct assetStruct = generator.generateGameObjectWithCode(code);
		GameObject asset = assetStruct.generateAsset;
		asset.transform.parent = this.transform;
		if (speedSign > 0) {
			asset.transform.position = new Vector3(popLimitation.transform.position.x + (asset.GetComponent<SpriteRenderer> ().sprite.bounds.max.x) - (space-dist),popLimitation.transform.position.y,this.transform.position.z);
		} else {
			asset.transform.position = new Vector3(popLimitation.transform.position.x + (asset.GetComponent<SpriteRenderer> ().sprite.bounds.min.x) + (space-dist),popLimitation.transform.position.y,this.transform.position.z);
		}

		visibleGameObjectTab.Add(asset);
		if (speedSign > 0) {
			hightId ++;
		} else {
			lowId--;
		}
	}
	
	void generateAssetIfNeeded(){
			if(speedSign > 0){
			//Debug.Log("Hight ID = " + hightId);
			if(hightId == m_stockAsset.Count || hightId == m_stockAsset.Count-1) {
				//Debug.Log("get Hight with space : "+ spaceBetweenLastAndPopLimitation() + " and space value "+ spaceBetweenAsset);
				if(spaceBetweenLastAndPopLimitation() > spaceBetweenAsset) {
				//	Debug.Log("generate Hight");
					generateNewAsset();

				}
				} else { // si on a une valeur 
				//Debug.Log("get old Hight with space : "+ spaceBetweenLastAndPopLimitation() + " and stock value "+ m_stockAsset[hightId +1].dist);
				if(spaceBetweenLastAndPopLimitation() > m_stockAsset[hightId +1].dist) {
				//	Debug.Log("get old Hight");
					generateOldAsset(m_stockAsset[hightId +1].code,m_stockAsset[hightId +1].dist);
				}
				}
			} else { 
				if (lowId == 0) {
				//Debug.Log("get low with space : "+ spaceBetweenLastAndPopLimitation() + " and space value "+ spaceBetweenAsset);
				if(spaceBetweenLastAndPopLimitation() > spaceBetweenAsset) {
					generateNewAsset();
				//	Debug.Log("generate low");
				}
				} else {
				///Debug.Log("get old low with space : "+ spaceBetweenLastAndPopLimitation() + " and stock value "+ m_stockAsset[lowId].dist);
				if(spaceBetweenLastAndPopLimitation() > m_stockAsset[lowId].dist) {
					generateOldAsset(m_stockAsset[lowId].code,m_stockAsset[lowId].dist);
				//	Debug.Log("get old low");
				}
			}
		}
	}
	
	
	void generateNewSpaceBetweenAssetValue(){
		spaceBetweenAsset = Random.Range (lowSpaceBetweenAsset,hightSpaceBetweenAsset);
	}
	
	
	public override void setSpeedOfPlan(float newSpeed){
        float speed = newSpeed + relativeSpeed;
		if ((speed > 0 && speedSign < 0) || (speed < 0 && speedSign > 0)) {
			swapPopAndDepop ();
			print ("Swap");
		}
		actualSpeed = speed;
	}
	
	void swapPopAndDepop(){
		GameObject temp = popLimitation;
		popLimitation = depopLimitation;
		depopLimitation = temp;
		speedSign = speedSign * -1;
	}
	
	
	bool isStillVisible (GameObject parallaxObject) {
		if (speedSign > 0) {
			return (parallaxObject.transform.position.x + (parallaxObject.GetComponent<SpriteRenderer> ().sprite.bounds.max.x ) > depopLimitation.transform.position.x);
		} else {
			return (parallaxObject.transform.position.x + (parallaxObject.GetComponent<SpriteRenderer> ().sprite.bounds.min.x ) < depopLimitation.transform.position.x);
		}
	}
	
	
	float spaceBetweenLastAndPopLimitation() {
		if (visibleGameObjectTab.Count != 0) {
			if (speedSign > 0){
				space = getMaxValue();
			}else {
				space = getMinValue();
			}
			return space;
			
		} else {
			return float.MaxValue;
		}
	}
	
	
	float getMaxValue(){
		//min
		float min = float.MaxValue;
		foreach(GameObject g in visibleGameObjectTab){
			float result  = popLimitation.transform.position.x - (g.transform.position.x +(g.GetComponent<SpriteRenderer> ().sprite.bounds.max.x));
			if (result < min){
				min = result;
			}
		}
		return min;
	}
	
	float getMinValue(){
		float min = float.MaxValue;
		foreach(GameObject g in visibleGameObjectTab){
			float result  =  (g.transform.position.x +(g.GetComponent<SpriteRenderer> ().sprite.bounds.min.x))- popLimitation.transform.position.x;
			if (result < min){
				min = result;
			}
		}
		return min;
	}


    public override void refreshOnZoom()
    {
        swapPopAndDepop();
        moveAsset(0);
        generateAssetIfNeeded();
        swapPopAndDepop();
    }
}
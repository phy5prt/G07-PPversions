using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enable max bars not working manually changing from not enabled to enabled also crashing not sure why
//for now its commented out
//its possibly due to canvases not being in canvas groups so need to research that

//architecturely i think the activation should be in platyerstartSetup
//potentially the shrink too
//if one then both because should take the enable away because it need to occur after the shrink
//so unless the shrink was a method that returns something which triggers the enable then its maybe best as is


//what is limiting the archetecture and needs researching is running a method that runs every update for a period of time and then finishes and returns a value

public class shrinkLeft : MonoBehaviour {

[Range(0f,1f)]
[SerializeField] float shrinkToPercX = 0.3f;

private float shrinkSpeedX = 1f;
private float shrinkABitX = 1f;
private float myOriginalScaleX;


private float shrinkToPercY = 0.75f;


private float shrinkSpeedY = 1f; // should be private but i want to see it
private  float shrinkABitY = 1f;
private float myOriginalScaleY;


private bool shrink = false;


private RectTransform myRectTransform;
	// Use this for initialization

[SerializeField] float divideGizmosScaleYBy = 2f;
private selectorPBGizmo[] selectorGizmos;




	void Start () {


	setUpPanelShrink ();
	setUpGizmosYShrink();

	}
	
	// Update is called once per frame
	void Update () {

		if(shrink){shrinkLeftNowX();shrinkLeftNowY();}
		
	}

	public void startShrinking(float shrinkTime = 0.7f){   //if took a time to shrink could be used in a coroutine easily when set

	shrinkSpeedX = (myOriginalScaleX - myOriginalScaleX*shrinkToPercX )/shrinkTime; //assuming x defines y
	shrink=true;
	}

	private void shrinkLeftNowX(){

		if(myRectTransform.localScale.x > shrinkToPercX*myOriginalScaleX){
			//shrinkABitX = myRectTransform.localScale.x*(Time.deltaTime*(1/shrinkSpeedX));
			shrinkABitX = (Time.deltaTime*shrinkSpeedX);

	myRectTransform.localScale = new Vector3((myRectTransform.localScale.x-shrinkABitX),myRectTransform.localScale.y, myRectTransform.localScale.z);}
		else{
				shrink=false;
				shrinkGizmosInstantly();
				//enableMaxBar();
			//enableChooseTeamStage(); // works maybe change so just fades in though
			//foreach(selectorPBGizmo selector in selectorGizmos){selector.gameObject.GetComponentInChildren<arrowTeamSelector>().gameObject.SetActive(true);}
		}}


	private void shrinkLeftNowY(){

	//shrinkY needs to be at the speed of x so 
		//shrinkSpeedY = 1/(1-shrinkToPercY)/((1-shrinkToPercX)/shrinkSpeedX));
		shrinkSpeedY = (1-shrinkToPercY)/((1-shrinkToPercX)/shrinkSpeedX);

		if(myRectTransform.localScale.y > shrinkToPercY*myOriginalScaleY){
		//	shrinkABitY = myRectTransform.localScale.y*(Time.deltaTime*(1/shrinkSpeedY));
			shrinkABitY = (Time.deltaTime*shrinkSpeedY);
			myRectTransform.localScale = new Vector3(myRectTransform.localScale.x, (myRectTransform.localScale.y-shrinkABitY), myRectTransform.localScale.z);}
	}



	void setUpPanelShrink ()
	{
		myRectTransform = GetComponent<RectTransform> ();
		myOriginalScaleX = myRectTransform.localScale.x;
		myOriginalScaleY = myRectTransform.localScale.y;
	}

	private void setUpGizmosYShrink(){

	selectorGizmos = GetComponentsInChildren<selectorPBGizmo>();   ///will this work
//	Debug.Log("I've collected this many selectorgizmos = " + selectorGizmos.Length);


	}

	private void shrinkGizmosInstantly(){

		foreach(selectorPBGizmo selector in selectorGizmos){

			selector.gameObject.GetComponent<RectTransform>().localScale = new Vector3(selector.gameObject.GetComponent<RectTransform>().localScale.x,(selector.gameObject.GetComponent<RectTransform>().localScale.y/divideGizmosScaleYBy),selector.gameObject.GetComponent<RectTransform>().localScale.z);

	}
	}

	//private void enableMaxBar(){

	//MXSBCtagSloppy[] maxBarsSCs = GetComponentsInChildren<MXSBCtagSloppy>(true); //sloppy if it gets a script on a different tag use that
	//	foreach(MXSBCtagSloppy maxBar in maxBarsSCs){maxBar.gameObject.SetActive(true);}



	//private void enableChooseTeamStage(){

//	GameObject chooseTeamStage = GameObject.Find("chooseTeamStage");
//	chooseTeamStage.gameObject.transform.GetChild(0).gameObject.SetActive(true); 


	//ehh
	}





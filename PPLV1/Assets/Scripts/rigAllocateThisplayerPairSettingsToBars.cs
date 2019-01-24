using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//now game manager running it seems this is not very necessaru as seperate code?

public class rigAllocateThisplayerPairSettingsToBars : MonoBehaviour {

//not fond of the double foreach seems wasteful especially when could just use array and fors and match array numbers

	// Use this for initialization
	//void Awake(){setupTheRigVoltBars();} //just added 20/12 1600 to see if stop error nit finding canvases on scene change

	void Start () {

	//just giving time for gm to allocate
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setupTheRigVoltBars(){

		percBarDisplay[] percBarAr = GetComponentsInChildren<percBarDisplay>();
	foreach(percBarDisplay percBarSc in percBarAr){

			foreach(thisPlayerPairSettings playerPairVolts in GameManager.shipPlayerSettingsAr){
//				Debug.Log("bar color is " + percBarSc.gameObject.tag + " static color is " + playerPairVolts.getShipPairColor());
	if(percBarSc.gameObject.tag == playerPairVolts.getShipPairColor()){percBarSc.passMeMyPlayerPairSettings(playerPairVolts);break;}
	}}
	}
}

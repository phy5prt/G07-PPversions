using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pairSetRivalMaxBar : MonoBehaviour {

//need to know best way to code something that runs once for an amount of time.


//dont really know when else gonna need two bikes in a paired bar so maybe this code should just be enabled and disabled
//and operate entirely in the update
//no bool for turning on because this is the only time however how will it no to send its data
//need a non void update

//really feel using colour enum to operate the static thisplayer setting array is the way to go, using tags is expensive but???




     //Todo replace these	
	
private float voltCurrentL;
private float voltCurrentR;


//public float GetVolt = 100f;
	private float pairVoltCurrent =20f;
	[SerializeField] float voltPerc =1f;
	[SerializeField] float voltMax = 100f;
private Image percBar;
	[SerializeField] float proportion200Bar;
	[SerializeField] Text CurrentHighestVolt;
	[SerializeField] Text CurrentVoltOutput;

	private string myShipPairColor;

	private int myShipPairArIndex;
	private int myRivalIndex;
	private Color rivalColor;
	private int checkArrayAt;
	[SerializeField] Image myRivalBGPanel;
	private string myRivalName;
	private string sabotageRunTxt;
	[SerializeField] Text sabotageRunTXTComp;
	private bool runSetMax;
	// Use this for initialization

	private float alphaOfRivalColorBackground = 0.3f; // would be better to replace this when im faster at sorting rendering orders etc. 


	private thisPlayerPairSettings rivalOrOwnPair;
	private thisPlayerPairSettings myThisPlayerPairSettings;

	void Start () {


	this.enabled = true;


	percBar = gameObject.GetComponent<Image>();

	//PSM = GameObject.Find("PlayerSetUpManager").GetComponent<PlayerSetupManager>();  
	//updateTxtAndDisplayWithRivalInfo(); //should be fed this in a method

	}


	void Update () {

		//it should delay displaying this so can exceded previous
		//should display volt number
		//or could reach the top95 % change colour when you hit it
		//line shows when you reach 90%
		if(runSetMax){

		powerBarDisplayAndSetValues ();
		setVoltsToGet100PercSpeed ();

		//send Volt Max put in it 
			
		

			}
	}

	void powerBarDisplayAndSetValues ()
	{
		CurrentVoltOutput.text = "Current Volts: " + "\r\n" + pairVoltCurrent;


		voltCurrentL = myThisPlayerPairSettings.GetmyLeftVolt();
		voltCurrentR = myThisPlayerPairSettings.GetmyRightVolt();
		pairVoltCurrent = (voltCurrentL + voltCurrentR)/2;
		if (voltMax > 0) {
			voltPerc = pairVoltCurrent / voltMax;
		}
		proportion200Bar = voltPerc;
		//so can get up to 90% of bar
		percBar.fillAmount = proportion200Bar;
		//goes up to 200% at moment hence divide by two
		if (proportion200Bar >= 0.9) {
			percBar.color = Color.cyan;
		}
		if (proportion200Bar < 0.8 && proportion200Bar >= 0.7) {
			percBar.color = Color.green;
		}
		if (proportion200Bar < 0.7 && proportion200Bar >= 0.5) {
			percBar.color = Color.yellow;
		}
		if (proportion200Bar < 0.5) {
			percBar.color = Color.red;
		}
	}

	private void setVoltsToGet100PercSpeed ()
	{




		//if too fast put on coroutine
		//Debug.Log(" setting volt max ");
		//voltCurrent = GetVolt;
		if (pairVoltCurrent > voltMax) {
			voltMax = pairVoltCurrent * 1.3f;
			CurrentHighestVolt.text = "Max Volt Set: " + "\r\n" + voltMax;
			CurrentHighestVolt.color = rivalColor;
			rivalOrOwnPair.SetVolt100Perc(voltMax);
		}
	
	}


	public void runSetMaxFor(thisPlayerPairSettings givenThisPlayerSettingsRivalOrPair){ /// if you want to feed something a static how do you do it as they dont have an instance

//	Debug.Log("I am " + tag + " I have been assigned " + givenThisPlayerSettingsRivalOrPair.getShipPairColor() );
	foreach(thisPlayerPairSettings pairSettings in GameManager.shipPlayerSettingsAr){
			if(pairSettings.getShipPairColor()==this.gameObject.tag){myThisPlayerPairSettings	= pairSettings;}}
	
	rivalOrOwnPair = givenThisPlayerSettingsRivalOrPair;
	runSetMax = true;
	updateTxtAndDisplayWithRivalInfo();
	}

	private void updateTxtAndDisplayWithRivalInfo(){
		
	myShipPairColor = tag;


	//which one am I.So I know which one is next along
	//match the color to your back panel and then find that ones index

	/*
		if(PSM.shipPlayerSettingsAr[myRivalIndex].getShipPairColor() == "RED"){rivalColor = Color.red;}
			else if(PSM.shipPlayerSettingsAr[myRivalIndex].getShipPairColor() == "YELLOW"){rivalColor = Color.yellow;}
				else if(PSM.shipPlayerSettingsAr[myRivalIndex].getShipPairColor() == "GREEN"){rivalColor = Color.green;}
					else if(PSM.shipPlayerSettingsAr[myRivalIndex].getShipPairColor() == "BLUE"){rivalColor = Color.blue;}
						 else{Debug.Log("color not assigned? or string miss match");}


		myRivalName = PSM.shipPlayerSettingsAr[myRivalIndex].GetShipPairName();
		if(myRivalName == PSM.shipPlayerSettingsAr[myShipPairArIndex].GetShipPairName()){
			sabotageRunTxt = "rowing for their lives";}

			//need to add in incase they have been asigned a friend that "is towing team mates X as fast as they can before the docks blow"

		else{sabotageRunTxt = "sabotaging " + PSM.shipPlayerSettingsAr[myRivalIndex].GetShipPairName();}
		sabotageRunTXTComp.text = sabotageRunTxt;
		myRivalBGPanel.color = rivalColor;
		*/

		if(rivalOrOwnPair.getShipPairColor() == "RED"){rivalColor = Color.red;}
		else if(rivalOrOwnPair.getShipPairColor() == "YELLOW"){rivalColor = Color.yellow;}
		else if(rivalOrOwnPair.getShipPairColor() == "GREEN"){rivalColor = Color.green;}
		else if(rivalOrOwnPair.getShipPairColor() == "BLUE"){rivalColor = Color.blue;}
						 else{Debug.Log("color not assigned? or string miss match");}


		myRivalName = rivalOrOwnPair.GetShipPairName();
		if(myRivalName == rivalOrOwnPair.GetShipPairName()){
			sabotageRunTxt = "rowing for their lives";}

			//need to add in incase they have been asigned a friend that "is towing team mates X as fast as they can before the docks blow"

		else{sabotageRunTxt = "sabotaging " + rivalOrOwnPair.GetShipPairName();}
		sabotageRunTXTComp.text = sabotageRunTxt;
		sabotageRunTXTComp.color = rivalColor;
		rivalColor = new Color(rivalColor.r,rivalColor.g,rivalColor.b,alphaOfRivalColorBackground);
		myRivalBGPanel.color = rivalColor;
		//myRivalBGPanel.color.a = alphaOfRivalColorBackground;


	}

 //it should delay displaying that the max has been increased so can see yourself exceeding your previously set max
 //so feeling of acheivement
 //this so can exceded previous

	//should display volt number
	//or could reach the top95 % change colour when you hit it
	//line shows when you reach 90%

}

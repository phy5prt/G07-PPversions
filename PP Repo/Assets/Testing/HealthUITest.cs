using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUITest : MonoBehaviour {

public GameObject GetHealth;
public float healthCurrent;
public float healthPerc;
public float healthMax;
private Image percBar;
public float proportion200Bar;


	// Use this for initialization
	void Start () {

	percBar = gameObject.GetComponent<Image>();

	}
	void Update () {

	healthCurrent = GetHealth.GetComponent<GetHealthHere>().health;

	healthPerc = healthCurrent/healthMax;
	proportion200Bar =	healthPerc/2;
	percBar.fillAmount = proportion200Bar; //goes up to 200% at moment hence divide by two


	if(proportion200Bar >= 0.75){percBar.color = Color.cyan;}      
	if(proportion200Bar <  0.75 && proportion200Bar>=0.5){percBar.color = Color.green;} 
	if(proportion200Bar <  0.5 && proportion200Bar>=0.3){percBar.color = Color.yellow;} 
	if(proportion200Bar <  0.3){percBar.color = Color.red;} 


	}
}

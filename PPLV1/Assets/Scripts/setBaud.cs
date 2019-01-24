﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setBaud : MonoBehaviour {
	private Dropdown thisDropDown;
	private arduinoReceiver arduino;
	// Use this for initialization
	void Start () {
	arduino = GameObject.Find("ArduinoHolder").GetComponent<arduinoReceiver>();
		thisDropDown = GetComponent<Dropdown>();
		thisDropDown.onValueChanged.AddListener(delegate{DropdownValueChanged(thisDropDown);});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void DropdownValueChanged(Dropdown change){
		int sendBaud =int.Parse(thisDropDown.options[thisDropDown.value].text);
			arduino.setBaud(sendBaud);

	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPins : MonoBehaviour {	

    private PinSetter pinSetter;
    private Text text;
	
	// Use this for initialization
	void Start () {
        pinSetter = GameObject.Find("PinSetter").GetComponent<PinSetter>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = pinSetter.getStandingPins().ToString();
	}
}

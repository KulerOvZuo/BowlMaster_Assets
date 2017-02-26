using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {	

    public Text text;

    private int pinsStanding = 0;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    [HideInInspector]
    public bool ballOutofPlay = false;
    private int lastSettledCount = 10;

    private GameManager GM;
    private GameObject pinsOrigin;

    // Use this for self-initialization
	void Awake() {	
	}
	
	// Use this for initialization
	void Start () {
        pinsOrigin = GameObject.Find("PinsOrigin");
        pinsStanding = CountStandingPins();
        GM = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        pinsStanding = CountStandingPins();
        text.text = pinsStanding.ToString();

        if(ballOutofPlay){
            text.color = Color.red;
            UpdateStandingCountAndSettle();
        }
	}

    public int CountStandingPins(){
        int standing = 0;
        foreach(Pin child in pinsOrigin.GetComponentsInChildren<Pin>()){
            if(child.IsStanding())
                standing++;
        }
        return standing;
    }
    public int getStandingPins(){
        return pinsStanding;
    }
    void UpdateStandingCountAndSettle(){
        int currentStanding = CountStandingPins();
        if(currentStanding != lastStandingCount){
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if((Time.time - lastChangeTime) > settleTime){
            PinsHaveSetteled();
        }
    }
    void PinsHaveSetteled(){
        int pinFall = lastSettledCount - CountStandingPins();
        lastSettledCount = lastSettledCount - pinFall;
        GM.Bowl(pinFall);
        ballOutofPlay = false;
        lastStandingCount = -1;
        text.color = Color.green;
    }
    public void Reset(GameObject pinsOrigin){
        this.pinsOrigin = pinsOrigin;
        lastSettledCount = 10;
    }
    public void Reset(){
        lastSettledCount = 10;
    }
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.name == "Ball")
            ballOutofPlay = true;
    }
}

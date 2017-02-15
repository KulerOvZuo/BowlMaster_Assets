using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {	

    private int lastStandingCount = -1;
    private float lastChangeTime;
    private bool ballEnteredBox = false;
    public float dostanceToRaise = 40f;

    public GameObject pinsPrefab;

    private Ball ball;

    private GameObject pinsOrigin;
    public Text text;  

    private int pinsStanding = 0;
	
	// Use this for initialization
	void Start () {
        pinsOrigin = GameObject.Find("PinsOrigin");
        pinsStanding = CountStandingPins();
        ball = GameObject.Find("Ball").GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        pinsStanding = CountStandingPins();
        text.text = pinsStanding.ToString();

        if(ballEnteredBox){
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

    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Ball>()){
            ballEnteredBox = true;
            text.color = Color.red;   
        }    
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.GetComponentInParent<Pin>())
            Destroy(other.gameObject.transform.parent.gameObject);
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
        ball.Reinstantiate();
        ballEnteredBox = false;
        lastStandingCount = -1;
        text.color = Color.green;
    }

    public void RaisePins(){//standing pins
        foreach(Pin child in pinsOrigin.GetComponentsInChildren<Pin>()){
            if(child.IsStanding()){
                child.gameObject.transform.position += new Vector3(0,dostanceToRaise,0);
                child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
    public void LowerPins(){
        foreach(Pin child in pinsOrigin.GetComponentsInChildren<Pin>()){
            if(child.IsStanding()){
                child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                child.gameObject.transform.position -= new Vector3(0,dostanceToRaise,0);
            }
        }
    }
    public void RenewPins(){
        GameObject lastPins = GameObject.FindGameObjectWithTag("Pins");
        if(lastPins)
            Destroy(lastPins);
        pinsOrigin = Instantiate(pinsPrefab,new Vector3(0,0,1859),Quaternion.identity) as GameObject;
        RaisePins();
    }

}

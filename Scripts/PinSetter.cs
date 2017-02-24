using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {	

    public GameObject pinsPrefab;
    private GameObject pinsOrigin; 
    public float dostanceToRaise = 40f;      

    private GameManager GM;
	private PinCounter pinCounter;
    private Animator animator;
	// Use this for initialization
	void Start () {
        pinsOrigin = GameObject.Find("PinsOrigin");
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
        GM = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PerformAction(ActionMaster.Action action){
        switch(action){
            case ActionMaster.Action.Tidy: animator.SetTrigger("tidy"); break;
            case ActionMaster.Action.Reset: animator.SetTrigger("reset"); break;
            case ActionMaster.Action.EndTurn: animator.SetTrigger("reset"); break;
            case ActionMaster.Action.EndGame: animator.SetTrigger("reset"); break;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.GetComponentInParent<Pin>())
            Destroy(other.gameObject.transform.parent.gameObject);
    }


    public void RaisePins(){//standing pins
        foreach(Pin child in pinsOrigin.GetComponentsInChildren<Pin>()){
            if(child.IsStanding()){
                child.gameObject.transform.position += new Vector3(0,dostanceToRaise,0);
                child.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                child.transform.rotation = Quaternion.Euler(0f,0f,0f);
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
        GM.Ball_isLaunched(false);
    }
    public void RenewPins(){
        GameObject lastPins = GameObject.FindGameObjectWithTag("Pins");
        if(lastPins)
            Destroy(lastPins);
        pinsOrigin = Instantiate(pinsPrefab,new Vector3(0,0,1859),Quaternion.identity) as GameObject;
        pinCounter.Reset(pinsOrigin);
        RaisePins();
    }

}

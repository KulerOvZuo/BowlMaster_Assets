using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {	

    public float launchSpeed;
    private Vector3 startingPosition;
    private Rigidbody thisRigidbody;
    private AudioSource audioSource;

    private bool isLaunched = false;
    // Use this for self-initialization
	void Awake() {
        thisRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        thisRigidbody.useGravity = false;
        startingPosition = transform.position;
	}

    public void Launch(Vector3 velocity){
        if(!isLaunched){
            thisRigidbody.velocity = velocity;
            thisRigidbody.useGravity = true;
            isLaunched = true;
            audioSource.Play();
        }
    }

    public void MoveStart(float pos){
        if(!isLaunched){
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + pos,-40,40),transform.position.y,transform.position.z);
        }
    }
    public void Reinstantiate(){
        thisRigidbody.velocity = thisRigidbody.angularVelocity = Vector3.zero;
        isLaunched = false;
        thisRigidbody.useGravity = false;
        transform.position = startingPosition;
    }
}

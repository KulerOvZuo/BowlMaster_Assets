using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {	

    private float standingThreshold = 5f;

    void Update(){
    }
    public bool IsStanding(){
        float tiltInX = transform.rotation.eulerAngles.x;
        float tiltInZ = transform.rotation.eulerAngles.z;
        if(tiltInX > standingThreshold && tiltInX < 360-standingThreshold)
            return false;
        if(tiltInZ > standingThreshold && tiltInZ < 360-standingThreshold)
            return false;
        return true;
    }
}

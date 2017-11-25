using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swiper : MonoBehaviour {

    public UnityEvent OnSwipe;

	// Use this for initialization
	void Start () {
        SimpleGesture.OnSwipe(OnSwipe.Invoke);
	}
	
}

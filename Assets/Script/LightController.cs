using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    Light _light;
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
        _light.intensity = 0.1f;
	}
}

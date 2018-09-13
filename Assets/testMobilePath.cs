using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testMobilePath : MonoBehaviour {

    public Text txt;
	// Use this for initialization
	void Start () {
        string streamingPath = Application.streamingAssetsPath;
        string persisitent = Application.persistentDataPath;
        txt.text = streamingPath + "\n" + persisitent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

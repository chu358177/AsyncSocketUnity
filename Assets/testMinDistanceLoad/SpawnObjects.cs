using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    public GameObject go;
    public int GoNum = 100;
    List<GameObject> listGo = new List<GameObject>();

    float visibleDis = 5;
    
	// Use this for initialization
	void Start () {

        Spawns();
	}

    void Spawns()
    {
        for (int i = 0; i < GoNum; i++)
        {
            Vector3 p = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            listGo.Add(Instantiate(go, p, Quaternion.identity));        
        }

    }

  void loadGo()
    {
        foreach(GameObject g in listGo)
        {
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

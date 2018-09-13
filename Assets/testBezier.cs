using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBezier : MonoBehaviour {
    public Transform point1, point2, point3, point4;
    float count;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        count += Time.deltaTime * 0.1f;
        Debug.Log(count);

        Vector3 p = Bezier(point1.position, point2.position, point3.position, Mathf.Clamp01(count));
        point4.transform.position = p;
	}

    // 线性
    Vector3 Bezier(Vector3 p0, Vector3 p1, float t)
    {
        return (1 - t) * p0 + t * p1;
    }

    // 二阶曲线
    Vector3 Bezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 p0p1 = (1 - t) * p0 + t * p1;
        Vector3 p1p2 = (1 - t) * p1 + t * p2;
        Vector3 result = (1 - t) * p0p1 + t * p1p2;
        return result;
    }
}

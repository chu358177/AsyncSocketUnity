using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testVectorRotate : MonoBehaviour {
    public Transform target;
    public float speed;

    public Transform o;
    public Transform p1, p2;

    Vector3 dir1, dir2;

    //void Update()
    //{
    //    dir1 = p1.position - o.position;
    //    dir2 = p2.position - o.position;

    //    float step = speed * Time.deltaTime;
    //    Vector3 newDir = Vector3.RotateTowards(dir1, dir2, step, 0.0F);
    //    Debug.DrawRay(o.position, newDir, Color.cyan);
    //    //transform.rotation = Quaternion.LookRotation(newDir);
    //}
    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


    //   public Transform o;
    //   public Transform p1, p2;

    //   Vector3 dir1,dir2;

    //   Vector3 rotateDir;
    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {
    //       dir1 = p1.position - o.position;
    //       dir2 = p2.position - o.position;

    //       float step =+ Time.deltaTime;
    //       rotateDir = Vector3.RotateTowards(dir1, dir2, step, 5.0f);
    //       Debug.DrawRay(o.position, rotateDir, Color.cyan);

    //   }

    //   void OnDrawGizmos()
    //   {
    //       Gizmos.color = Color.red;

    //       Gizmos.DrawRay(o.position, dir1);
    //       Gizmos.DrawRay(o.position, dir2);

    //       Gizmos.color = Color.green;
    //       // Gizmos.DrawSphere(player.transform.position + PlayerToOrigin * distanceToPlayer, 1);

    //       //Gizmos.DrawSphere(rotateDir,1);
    //   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Camera cam;
    Transform mySP;
    Rigidbody myBod;
    LineRenderer myLine; //quiz

    public float speed;
    public float bulletSpeed;
    public float camRubberBand;
    public GameObject bulletPrefab;

    Vector3 startTouch;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mySP = transform.Find("SpawnPoint");
        myBod = GetComponent<Rigidbody>();
        myLine = GetComponent<LineRenderer>(); //quiz
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touches.Length > 0) {
            Touch t1 = Input.touches[0];
            if(t1.phase == TouchPhase.Began) {
                startTouch = getTouchPosInWorld();
            }
            else if(t1.phase == TouchPhase.Moved) {
                //show the line
                Vector3 tp = getTouchPosInWorld(); //quiz
                myLine.enabled = true; //quiz
                myLine.SetPosition(0, startTouch); //quiz
                myLine.SetPosition(1, tp); //quiz
            }
            else if(t1.phase == TouchPhase.Ended) {
                myLine.enabled = false; //quiz

                Vector3 endTouch = getTouchPosInWorld();
                Vector3 v = endTouch - startTouch;
                transform.forward = v;
                //shoot bullet
                GameObject g = Instantiate(bulletPrefab, mySP.position, mySP.rotation);
                g.GetComponent<Rigidbody>().velocity = v * bulletSpeed;
                myBod.velocity = -1 * v;            
            }
        }

        //camera follow player
        Vector3 goPoint = new Vector3(
            transform.position.x, cam.transform.position.y, transform.position.z);

        cam.transform.position = Vector3.Lerp(cam.transform.position, goPoint, 
            Time.deltaTime * camRubberBand);
    }

    public Vector3 getTouchPosInWorld() {
        RaycastHit hitInfo;
        Ray r = cam.ScreenPointToRay(Input.touches[0].position);
        if(Physics.Raycast(r, out hitInfo)) {
            Vector3 h = hitInfo.point;
            h.y = 1;
            return h;
        }
        return Vector3.zero;
    }
}

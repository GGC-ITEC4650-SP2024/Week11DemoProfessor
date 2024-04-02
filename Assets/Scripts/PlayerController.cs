using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    Transform mySP;

    public float speed;
    public float bulletSpeed;
    public float camRubberBand;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mySP = transform.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //player move with acccelorometers
        Vector3 a = Input.acceleration;
        //print(a);
        Physics.gravity = new Vector3(a.x, 0, a.y) * speed;

        //check for touches
        if(Input.touches.Length > 0) {

            //rotate player
            RaycastHit hitInfo;
            Ray r = cam.ScreenPointToRay(Input.touches[0].position);
            if(Physics.Raycast(r, out hitInfo)) {
                Vector3 h = hitInfo.point;
                h.y = 1;

                //move towards touch
                //Vector3 dir = hitInfo.point - transform.position;
                //transform.position += dir.normalized * Time.deltaTime;
                //myBod.addForce(...); or myBod.velocity = ...
                
                
                //if(hitInfo.collider.name == "Alien 1") {
                    //kill Alien1
                //}
                
                transform.LookAt(h); 
            }

            //shoot bullet
            if(Input.touches.Length >= 2 && Input.touches[1].phase == TouchPhase.Began) {
                GameObject g = Instantiate(bulletPrefab, mySP.position, mySP.rotation);
                g.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
        }

        //camera follow player
        Vector3 goPoint = new Vector3(
            transform.position.x, cam.transform.position.y, transform.position.z);

        cam.transform.position = Vector3.Lerp(cam.transform.position, goPoint, 
            Time.deltaTime * camRubberBand);

        
    }
}

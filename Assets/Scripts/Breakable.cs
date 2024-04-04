using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Collider myCol;
    Renderer myRend;
    public Material transParentMat;
    Material origMat;
    public float hideTime;

    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<Collider>();
        myRend = GetComponent<Renderer>();
        origMat = myRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideMe() {
        myCol.enabled = false;
        myRend.material = transParentMat;
        Invoke("showMe", hideTime);
    }

    void showMe() {
        myCol.enabled = true;
        myRend.material = origMat;
    }

    void OnCollisionEnter(Collision c) {
        if(c.gameObject.tag == "Bullet") {
            //hideMe();
        }
    }
}

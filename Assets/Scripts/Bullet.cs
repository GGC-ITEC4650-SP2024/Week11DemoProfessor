using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float lifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, lifeSpan);
        Invoke("DestroyMe", lifeSpan);
    }

    void DestroyMe() {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

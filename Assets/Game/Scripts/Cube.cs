using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour,ICollectable
{
    public void DoCollect()
    {
        PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y + 50, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z + 50);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

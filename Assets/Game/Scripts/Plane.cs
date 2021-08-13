using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour,ICollectable
{
    public void DoCollect()
    {

        PlayerController.Instance.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        UIManager.leveFail?.Invoke();

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

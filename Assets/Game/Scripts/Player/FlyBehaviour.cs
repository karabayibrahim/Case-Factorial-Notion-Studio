using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour,IStrategy
{
    public void DoStrategy()
    {
        Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 0);
        ObjectPool.Instance.targetcam.SetActive(true);
        //Camera.main.gameObject.GetComponent<CamFollow>().enabled = true;
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

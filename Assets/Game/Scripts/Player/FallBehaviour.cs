using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBehaviour : MonoBehaviour,IStrategy
{
    public void DoStrategy()
    {
        Camera.main.transform.localRotation = Quaternion.Euler(0, 0, 0);
        ObjectPool.Instance.targetcam.SetActive(true);
        Physics.gravity = new Vector3(0, -20f, 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);


    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.flyEvent?.Invoke();
        }
        transform.Rotate(2, 0, 0);

    }
}

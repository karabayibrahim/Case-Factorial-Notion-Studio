using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cylinder : MonoBehaviour, ICollectable
{
    public void DoCollect()
    {
        UIManager.Instance.TextAnim();

        ObjectPool.Instance.Xtext.GetComponent<Text>().text = "X2";


        PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y + 100, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z + 100);
        gameObject.GetComponent<Collider>().enabled = false;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z-PlayerController.Instance.gameObject.transform.position.z<-150f)
        {
            GameManager.Instance.cylinderList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

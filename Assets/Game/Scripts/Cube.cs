using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cube : MonoBehaviour,ICollectable
{
    public void DoCollect()
    {
        UIManager.Instance.TextAnim();

        ObjectPool.Instance.Xtext.GetComponent<Text>().text = "X1";
        PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y + 50, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z + 50);
        gameObject.GetComponent<Collider>().enabled = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z - PlayerController.Instance.gameObject.transform.position.z < -150f)
        {
            GameManager.Instance.cubeList.Remove(gameObject);

            Destroy(gameObject);
        }
    }
}

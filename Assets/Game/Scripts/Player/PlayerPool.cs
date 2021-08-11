using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoSingleton<PlayerPool>
{
    public GameObject mainPlayer;
    public GameObject stick;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in PlayerController.Instance.gameObject.GetComponentsInChildren<Transform>())
        {
            if (item.name== "ArmaturePlayer")
            {
                mainPlayer = item.gameObject;
            }
        }
        stick = PlayerController.Instance.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

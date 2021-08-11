using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoSingleton<PlayerController>
{
    // Start is called before the first frame update
    public static Action fallEvent;
    public static Action flyEvent;
    IStrategy myStrategy;
    public enum MYSTATUS
    {
        FIRST,FLY,FALL
    }
    MYSTATUS mySTATUS;
    void Start()
    {
        Transtiton<FirstBehaviour>(MYSTATUS.FIRST);
        fallEvent += Fall;
        flyEvent += Fly;
    }
    private void OnDestroy()
    {
        fallEvent -= Fall;
        flyEvent -= Fly;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Fall()
    {
        Transtiton<FallBehaviour>(MYSTATUS.FALL);
    }
    void Fly()
    {
        Transtiton<FlyBehaviour>(MYSTATUS.FLY);
    }
    public void Transtiton<T>(MYSTATUS mySt)
    {
        Component c = gameObject.GetComponent<IStrategy>() as Component;
        if (c != null)
        {
            Destroy(c);
        }
        myStrategy = gameObject.AddComponent(typeof(T)) as IStrategy;
        myStrategy.DoStrategy();
        mySTATUS = mySt;
    }
}

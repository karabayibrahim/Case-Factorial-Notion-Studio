using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectPool : MonoSingleton<ObjectPool>
{
    public GameObject targetcam;
    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Plane;
    [Header("UI")]
    public GameObject startClose;
    public GameObject levelFail;
    public Button nothanks;
    public GameObject Xtext;
}

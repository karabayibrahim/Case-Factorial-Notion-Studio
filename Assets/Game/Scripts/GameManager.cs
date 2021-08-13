using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoSingleton<GameManager>
{
    
    int countCube;
    int countCylinder;
    Vector3 tempCube;
    Vector3 tempCylinder;
    float cubeX;
    float cubeY;
    float cubeZ;
    float cylinderX;
    float cylinderY;
    float cylinderZ;
    public float playerTempZ;
    public Action spawnEvetn;
    public List<GameObject> cubeList = new List<GameObject>();
    public List<GameObject> cylinderList = new List<GameObject>();
    float distance = 20;
    
    void Start()
    {

        

        spawnEvetn += ReSpawn;
        
        SpawnCube();
        SpawnCylinder();
        playerTempZ = PlayerController.Instance.gameObject.transform.position.z;
    }
    private void OnDestroy()
    {
        spawnEvetn -= ReSpawn;

    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.transform.position.z>playerTempZ+500f)
        {
            spawnEvetn?.Invoke();
        }
    }
    void ReSpawn()
    {
        GameObject newPlane = Instantiate(ObjectPool.Instance.Plane, new Vector3(0, -12.84f, PlayerController.Instance.gameObject.transform.position.z + 600f), Quaternion.identity);
        SpawnCube();
        SpawnCylinder();
        playerTempZ = PlayerController.Instance.gameObject.transform.position.z;
    }
    public void SpawnCube()
    {
        countCube = UnityEngine.Random.Range(15, 35);
        
        for (int i = 0; i < countCube; i++)
        {
            
            cubeX = UnityEngine.Random.Range(-400, 400);
            cubeY = UnityEngine.Random.Range(-20, -3);
            cubeZ = UnityEngine.Random.Range(PlayerController.Instance.gameObject.transform.position.z + 200, PlayerController.Instance.gameObject.transform.position.z + 1000);
            while (Vector3.Distance(tempCube,new Vector3(cubeX,cubeY,cubeZ))<distance)
            {
                cubeX = UnityEngine.Random.Range(-400, 400);
                cubeY = UnityEngine.Random.Range(-20, -3);
                cubeZ = UnityEngine.Random.Range(PlayerController.Instance.gameObject.transform.position.z + 200, PlayerController.Instance.gameObject.transform.position.z + 1000);
                if (Vector3.Distance(tempCube, new Vector3(cubeX, cubeY, cubeZ)) > distance)
                {
                    break;
                }
            }
            
            GameObject newCube = Instantiate(ObjectPool.Instance.Cube, new Vector3(cubeX, cubeY, cubeZ), Quaternion.identity);
            cubeList.Add(newCube);
            tempCube = new Vector3(cubeX, cubeY, cubeZ);

        }
    }
    public void SpawnCylinder()
    {
        //countCylinder = UnityEngine.Random.Range(10, 20);

        for (int i = 0; i < countCube; i++)
        {
            cylinderX = UnityEngine.Random.Range(-400, 400);
            cylinderY = UnityEngine.Random.Range(-25, 7);
            cylinderZ= UnityEngine.Random.Range(PlayerController.Instance.gameObject.transform.position.z + 200, PlayerController.Instance.gameObject.transform.position.z + 1000);
            while (Vector3.Distance(tempCylinder, new Vector3(cylinderX, cylinderY, cylinderZ)) < distance)
            {
                cylinderX = UnityEngine.Random.Range(-400, 400);
                cylinderY = UnityEngine.Random.Range(-25, 7);
                cylinderZ = UnityEngine.Random.Range(PlayerController.Instance.gameObject.transform.position.z + 200, PlayerController.Instance.gameObject.transform.position.z + 1000);
                if (Vector3.Distance(tempCube, new Vector3(cubeX, cubeY, cubeZ)) > distance)
                {
                    break;
                }
            }
            
            GameObject newCylinder = Instantiate(ObjectPool.Instance.Cylinder, new Vector3(cylinderX, cylinderY, cylinderZ), Quaternion.identity);
            cylinderList.Add(newCylinder);

            while (Vector3.Distance(cubeList[i].transform.position, cylinderList[i].transform.position) < distance)
            {
                Destroy(newCylinder);
                cylinderX = UnityEngine.Random.Range(-400, 400);
                cylinderY = UnityEngine.Random.Range(-25, 7);
                cylinderZ = UnityEngine.Random.Range(PlayerController.Instance.gameObject.transform.position.z + 200, PlayerController.Instance.gameObject.transform.position.z + 1000);
                if (Vector3.Distance(cubeList[i].transform.position, cylinderList[i].transform.position) > distance)
                {
                    GameObject newCylinder2 = Instantiate(ObjectPool.Instance.Cylinder, new Vector3(cylinderX, cylinderY, cylinderZ), Quaternion.identity);
                    break;
                }

            }
            tempCylinder = new Vector3(cylinderX, cylinderY, cylinderZ);

        }
    }

}

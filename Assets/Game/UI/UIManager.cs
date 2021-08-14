using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
    

    public static Action leveFail;
    void Start()
    {
        

        ObjectPool.Instance.nothanks.onClick.AddListener(RestartGame);
        leveFail += LevelFail;
    }
    private void OnDestroy()
    {

        leveFail -= LevelFail;
        try
        {
            ObjectPool.Instance.nothanks.onClick.RemoveListener(RestartGame);
        }
        catch 
        {

           
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void TextAnim()
    {
        StartCoroutine(XtextTimer());
    }
    void RestartGame()
    {
        

        GameManager.Instance.SpawnCube();
        GameManager.Instance.SpawnCylinder();
        GameManager.Instance.playerTempZ = PlayerController.Instance.gameObject.transform.position.z;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
       

    }

    void LevelFail()
    {
        

        StartCoroutine(FailTimer());
    }
    IEnumerator FailTimer()
    {
        GameManager.Instance.cubeList.Clear();
        GameManager.Instance.cylinderList.Clear();

        yield return new WaitForSeconds(0.5f);
        ObjectPool.Instance.levelFail.SetActive(true);
    }
    IEnumerator XtextTimer()
    {
        ObjectPool.Instance.Xtext.SetActive(true);
        yield return new WaitForSeconds(2f);
        ObjectPool.Instance.Xtext.SetActive(false);

    }
}

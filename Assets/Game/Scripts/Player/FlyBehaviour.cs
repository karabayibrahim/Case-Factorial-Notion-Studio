using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour, IStrategy
{
    public Animator anim;
    public float swerveSpeed = 2f;
    public float runSpeed;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    float swerveAmount;
    public float MoveFactorX => _moveFactorX;
    public void DoStrategy()
    {
        anim = PlayerController.Instance.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Fly");
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y-20, gameObject.GetComponent<Rigidbody>().velocity.z - 20f);
        Physics.gravity = new Vector3(0, -5f, 0);

        //Camera.main.gameObject.GetComponent<CamFollow>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(90, 90, 90);
        swerveAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ControllerMove();

        MovementInput();
        swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("NoFly");

            PlayerController.fallEvent?.Invoke();
        }
        Debug.Log(swerveAmount);

    }
    void ControllerMove()
    {
        if (swerveAmount!=0&&swerveAmount<1f)
        {
            
            PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.x + (swerveAmount * 10f), PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y - 0.01f, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z);
            gameObject.transform.eulerAngles = new Vector3(PlayerController.Instance.transform.eulerAngles.x + (swerveAmount*5f), 90f, 90f);


        }

        //if (Input.mousePosition.x < 1080 / 2f && Input.mousePosition.x >= 0)
        //{



        //}
        //else if (Input.mousePosition.x > 1080 / 2f && Input.mousePosition.x <= 1080f)
        //{
        //    PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.x + swerveAmount * 5f, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y - 0.01f, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z);










        //}

    }
    void MovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}

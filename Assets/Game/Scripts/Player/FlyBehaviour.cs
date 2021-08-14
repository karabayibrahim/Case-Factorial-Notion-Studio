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
    Vector2 lookUnput, screenCenter, mouseDistance;
    public float MoveFactorX => _moveFactorX;
    public void DoStrategy()
    {
       
        gameObject.transform.localRotation = Quaternion.Euler(90f, 90f, 90f);
        //gameObject.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, 0);
        anim = PlayerController.Instance.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Fly");
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y*0.5f, gameObject.GetComponent<Rigidbody>().velocity.z * 0.8f);
        Physics.gravity = new Vector3(0, -2f, 0);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
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
        //Debug.Log(swerveAmount);
        //Debug.Log(MoveFactorX);
    }
    void ControllerMove()
    {


        if (swerveAmount != 0 && swerveAmount < 1f)
        {
            PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.x + (MoveFactorX * Time.deltaTime * 50f), PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.y - 0.01f, PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z - 0.01f);

            //v3 = new Vector3(PlayerController.Instance.transform.localRotation.eulerAngles.x + (swerveAmount * 5f), 90f, 90f);
            //gameObject.transform.eulerAngles = v3;
            //gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, Quaternion.Euler((90f + MoveFactorX*10f), gameObject.transform.rotation.y, gameObject.transform.rotation.z), 0.1f);

            //var rotation = Quaternion.Euler(-(MoveFactorX * 20f), 90, 90f);
            //gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, rotation, Time.deltaTime*2f);
            //gameObject.transform.GetChild(0).localRotation = Quaternion.Slerp(gameObject.transform.GetChild(0).localRotation, rotation, Time.deltaTime * 2f);
            transform.Rotate(0, -MoveFactorX * Time.deltaTime * 20f, -MoveFactorX * Time.deltaTime * 20f, Space.Self);

            //lookUnput.x = Input.mousePosition.x;
            //lookUnput.y = Input.mousePosition.y;
            //mouseDistance.x = (lookUnput.x - screenCenter.x) / screenCenter.x;
            //mouseDistance.y = (lookUnput.y - screenCenter.y) / screenCenter.y;
            //mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
            //transform.Rotate(0, -mouseDistance.x * 500f * Time.deltaTime, 0, Space.Self);



        }



    }
    void MovementInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            
            if (Input.mousePosition.x<=Screen.width&&Input.mousePosition.x>=0)
            {
                
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
                Debug.Log(_moveFactorX);
            }
            else
            {
                _moveFactorX = 0;
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}

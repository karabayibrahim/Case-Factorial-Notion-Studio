using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static SwerveMovement Instance;
    public float swerveSpeed;
    public float runSpeed;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Update()
    {
        //Debug.Log(MoveFactorX);
        MovementInput();
        float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        //Debug.Log(swerveAmount);
        transform.Translate(swerveAmount, 0, 0);
        //gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * runSpeed;
        //gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
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


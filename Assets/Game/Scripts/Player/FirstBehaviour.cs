using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBehaviour : MonoBehaviour, IStrategy
{
    //float _moveFactorX;
    float _lastFrameFingerPositionX;

    public Animator animator;
    Rigidbody rb;
    public void DoStrategy()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        animator = PlayerController.Instance.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        rb = PlayerController.Instance.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();

    }
    void Fly()
    {
        PlayerController.fallEvent?.Invoke();
        rb.useGravity = true;
        PlayerPool.Instance.mainPlayer.transform.SetParent(null);
        PlayerController.Instance.transform.localPosition = PlayerPool.Instance.mainPlayer.transform.localPosition;
        PlayerPool.Instance.mainPlayer.transform.localRotation = Quaternion.Euler(0, 0, 0);
        PlayerPool.Instance.mainPlayer.transform.SetParent(PlayerController.Instance.gameObject.transform);
        Destroy(PlayerPool.Instance.stick);
        PlayerController.Instance.transform.localRotation = Quaternion.Euler(90, 0, 0);
        float amount = 1080 - Input.mousePosition.x;
        amount /= 500f;
        rb.velocity = new Vector3(0, amount, amount) * 20f;
    }
    void Controller()
    {
        //_moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;


        if (Input.GetMouseButton(0))
        {

            



            if (Input.mousePosition.x < 1080 / 4f && Input.mousePosition.x >= 0)
            {
                //AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

                //float playbackTime = currentState.normalizedTime;
                //animator.CrossFadeInFixedTime("Armature|Bend_Stick",playbackTime);
                float amount = 1080 - Input.mousePosition.x;
                animator.SetFloat("Speed", (amount + Input.mousePosition.x) / 1080f);

                //animator.Play(0);
                //animator.SetFloat("Speed", -amount);


            }
            else if (Input.mousePosition.x > 1080 / 4f && Input.mousePosition.x <= 1080f)
            {
                //animator.CrossFadeInFixedTime("Armature|Bend_Stick", animator.playbackTime - amount);
                //AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

                //float playbackTime = currentState.normalizedTime;
                //animator.CrossFadeInFixedTime("Armature|Bend_Stick", playbackTime -1f);
                float amount = 1080 - Input.mousePosition.x;

                animator.SetFloat("Speed", amount / 1080f);









            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Fly();
        }


        //else
        //{
        //    //animator.SetFloat("Speed", 0f);
        //    //animator.CrossFadeInFixedTime("Armature|Bend_Stick",0);
        //    animator.SetFloat("Speed",0);






        //}
    }
}

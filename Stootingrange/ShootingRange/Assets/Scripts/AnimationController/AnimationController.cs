using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator m_Anmimator; 
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVolecity = 0.5f;
    public float maximunRunVolecity = 2.0f;

    int VelocityZHash;
    int VelocityXHash;

    private void Start()
    {
        m_Anmimator= GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("Velocity z");
        VelocityXHash = Animator.StringToHash("Velocity x");


    }

    void changeVelocity(bool forwardPressed, bool backPressed, bool leftPressed, bool rightPressed,  bool runPressed, float currentMaxVelocity)
    {
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        if (backPressed && velocityZ > -currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }

        if (!backPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;

        }
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
    }

    void lockOrResetVelocity(bool forwardPressed, bool backPressed, bool leftPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {

        if (!backPressed && !forwardPressed && velocityZ != 0.0f & (velocityZ > -0.5f && velocityZ < 0.0f))
        {
            velocityZ = 0.0f;
        }

        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.5f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05))
        {
            velocityZ = currentMaxVelocity;
        }

        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if(velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }else if (leftPressed && velocityX > -currentMaxVelocity && velocityX <(-currentMaxVelocity + 0.05))
        {
            velocityX = -currentMaxVelocity;
        }if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }else if (rightPressed && velocityX > currentMaxVelocity + 0.05)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05))
            {

            velocityX = currentMaxVelocity;
            }
        }else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }

    }


    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);


        float currentMaxVelocity = runPressed ? maximunRunVolecity : maximumWalkVolecity;

        changeVelocity(forwardPressed, backPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);
        lockOrResetVelocity(forwardPressed, backPressed, leftPressed, rightPressed, runPressed, currentMaxVelocity);

        m_Anmimator.SetFloat(VelocityZHash, velocityZ);
        m_Anmimator.SetFloat(VelocityXHash, velocityX);

    }
    

}

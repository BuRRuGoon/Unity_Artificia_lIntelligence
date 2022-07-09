using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;
    private Rigidbody aRigidbody;

    void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
        aRigidbody = GetComponent<Rigidbody>();
    }

    public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }

    public virtual void Update()
    {
        if(aRigidbody == null)
        {   
            return;
        }

        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        // 회전값이 0~360도 사이로 제한
        if(orientation < 0.0f)
        {
            orientation += 360.0f;
        }
        else if(orientation > 360.0f)
        {
            orientation -= 360.0f;
        }
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
    }

    public virtual void LateUpdate()
    {
        if(aRigidbody == null)
        {   
            return;
        }

        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if(velocity.magnitude > maxSpeed)
        {
            // 벡터 정규화
            velocity.Normalize();
        } 

        if(steering.angular == 0.0f)
        {
            rotation = 0.0f;
        }

        if(steering.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }

        steering = new Steering();

        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        if(orientation < 0.0f)
        {
            orientation += 360.0f;
        }
        else if(orientation > 360.0f)
        {
            orientation -= 360.0f;
        }

        aRigidbody.AddForce(displacement, ForceMode.VelocityChange);
        Vector3 orientationVector = OriToVec(orientation);
        aRigidbody.rotation = Quaternion.LookRotation(orientationVector, Vector3.up);
    }

    // 방향을 벡터로 변환
    public Vector3 OriToVec(float orientation)
    {
        Vector3 vector = Vector3.zero;
        vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
        vector.y = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;
        return vector.normalized;
    }
}

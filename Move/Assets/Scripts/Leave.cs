using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : AgentBehaviour
{
    public float escapeRadius;
    public float dangerRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        // 두 반경 변수에 따라 거리에 따른 속도 계산
        Steering steering = new Steering();
        Vector3 direction = transform.position - target.transform.position;
        float distance = direction.magnitude;
        if(distance > dangerRadius)
        {
            return steering;
        }
        float reduce;
        if(distance < escapeRadius)
        {
            reduce = 0f;
        }
        else
        {
            reduce = distance / dangerRadius * agent.maxSpeed;
        }
        float targetSpeed = agent.maxSpeed - reduce;
        
        // Steering 값을 설정 최대 속도로 값을 제한
        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - agent.velocity;
        steering.linear /= timeToTarget;
        if(steering.linear.magnitude > agent.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= agent.maxAccel;
        }
        
        return steering;
    }
    
}

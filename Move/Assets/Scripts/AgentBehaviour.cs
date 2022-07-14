using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agent 행위에 대한 템플릿 클래스
public class AgentBehaviour : MonoBehaviour
{
    // 행위를 수행할 대상
    public GameObject target;
    protected Agent agent;

    public virtual void Awake() 
    {
        agent = gameObject.GetComponent<Agent>();
    }

    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }

    public virtual Steering GetSteering()
    {
        return new Steering();
    }

    public float MapToRange(float rotation)
    {
        rotation %= 360.0f;
        if(Mathf.Abs(rotation) > 180.0f)
        {
            if(rotation < 0.0f)
            {
                rotation += 360.0f;
            }
            else
            {
                rotation -= 360.0f;
            }
        }
        return rotation;
    }

    public Vector3 OriToVec (float orientation) {
        Vector3 vector  = Vector3.zero;
        vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
        vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;
        return vector.normalized;
    }
}

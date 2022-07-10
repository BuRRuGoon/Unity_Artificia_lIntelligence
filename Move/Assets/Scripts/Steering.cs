using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agent의 이동 및 회전을 저장
public class Steering
{
    public float angular;
    public Vector3 linear;
    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }
}

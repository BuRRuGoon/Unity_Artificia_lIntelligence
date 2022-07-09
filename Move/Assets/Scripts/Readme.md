## Agent
Agent는 행위를 하게될 대상 오브젝트에 사용하는 스크립트이다.  
행동을 하는 오브젝트에게 해당 스크립트를 사용하면 된다.  
- 스크립트의 퍼블릭 변수인 MaxSpeed(최대 스피드), MaxAccel(최고 가속도) 설정  
- Rigidbody는 필수적으로 있어야된다.  

## Seek & Pursue
추격을 하는 행동 알고리즘이다.  
- Target을 이용해 추격하고 싶은 오브젝트를 설정하면된다.  

Pursue에 경우 기존 Seek에서 예측이 추가된 스크립트이다.  

## Flee & Evade
회피를 하는 행동 알고리즘이다.  
- Target을 이용해 회피하고 싶은 오브젝트를 설정하면된다.  

Evade에 경우 기존 Flee에서 예측이 추가된 스크립트이다.  
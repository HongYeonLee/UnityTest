using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed =10f;
    private float minY = -7;

    public void SetMoveSpeed(float moveSpeed)//public은 어디에서든 메소드를 사용할 수 있게함
    {
         this.moveSpeed = moveSpeed; //this.뒤에 오는 변수는 이 클래스 내에서 정의된 변수를 말함, 뒤에 변수는 전달값으로 받은 변수
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY) // 적이 -7보다 밑으로 내려가면 사라지게 함
        {
            Destroy(gameObject);
        }
    }
}

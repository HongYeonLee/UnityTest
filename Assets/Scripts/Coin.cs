using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f; //코인이 화면밖으로 나갔을 때의 최소 y값
    // Start is called before the first frame update
    void Start() // 시작하자마자 (코인이 만들어지자마자) 점프라는 메소드 호출, 점프는 밑에서 정의
    {
        Jump();
    }

    void Jump(){
        //Rigidbody2D라는 새로운 객체에 Rigidbody2D라는 컴포넌트를 가져옴
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //코인이 받을 힘은 실수형으로 랜덤하게 받음
        float randomJumpForce = Random.Range(4f, 8f);
        //받은 힘을 up에다가 곱해서 위로 올라가게 하는 것이 jumpVelocity임
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;
        jumpVelocity.x = Random.Range(-2f, 2f);
        //AddForce는 특정 방향으로 힘을 주는 것임 (x, y기준으로 얼마만큼의 힘을, 모드를 어떻게 할 것인지)
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY){// 적이 -7보다 밑으로 내려가면 사라지게 함
            Destroy(gameObject);
        }
    }
}

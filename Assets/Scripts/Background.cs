using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{   
    private float moveSpeed = 3f; //다른 클래스에서 변수에 접근하지 못하게 private 사용
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; // .으로 구분되는 것은 전부 구조체, time은 성능이 다른 pc마다 동일한 거리만큼의 포지션을 이동시키기 위해 곱함
        if (transform.position.y<-10)
        {
            transform.position += new Vector3(0, 20f, 0); // Vector3 (x, y, z) y값 20만큼 더해서 위로 오브젝트 이동
        }
    }
}

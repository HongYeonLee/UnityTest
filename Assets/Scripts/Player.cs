using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // moveSpeed 값을 유니티 안에서 플레이어 오브젝트의 스크립트 컴포넌트안에서 조정할 수 있게함
    private float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f); // vector3라는 구조체의 이름은 moveTo이며 x, y, z 방향으로 어떻게 움직일지를 입력받은 값에 따라 움직이는 걸 정의
        transform.position += moveTo * moveSpeed * Time.deltaTime;

    //     Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0 , 0); // moveSpeed는 기본적으로 양수라 오른쪽으로 이동함
    //     if (Input.GetKey(KeyCode.LeftArrow)) //입력한 값이 키보드의 왼쪽 방향키라면
    //         transform.position -= moveTo;
    //     else if (Input.GetKey(KeyCode.RightArrow)) // 입력한 값이 키보드의 오른쪽 방향키라면
    //         transform.position += moveTo;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // moveSpeed 값을 유니티 안에서 플레이어 오브젝트의 스크립트 컴포넌트안에서 조정할 수 있게함
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;
    
    [SerializeField]
    private float shootInterval = 0.05f; //미사일 발사 간격
    private float lastShootTime = 0f; //마지막으로 미사일 쏜 시간

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); // vector3라는 구조체의 이름은 moveTo이며 x, y, z 방향으로 어떻게 움직일지를 입력받은 값에 따라 움직이는 걸 정의
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0 , 0); // moveSpeed는 기본적으로 양수라 오른쪽으로 이동함
        // if (Input.GetKey(KeyCode.LeftArrow)) //입력한 값이 키보드의 왼쪽 방향키라면
        //     transform.position -= moveTo;
        // else if (Input.GetKey(KeyCode.RightArrow)) // 입력한 값이 키보드의 오른쪽 방향키라면
        //     transform.position += moveTo;

        //마우스로 움직이기
        // Debug.Log(Input.mousePosition); Debug.Log()를 이용하면 콘솔창에서 마우스의 실시간 좌표를 확일할 수 있다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스의 좌표를 캐릭터의 실제 좌표와 동일화
        //Debug.Log(mousePos); 좌표 변경됐나 확인
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); //마우스가 화면밖으로 나갔을 때 캐릭터가 화면을 벗어나지 않도록 x좌표 최소, 최대 값 지정
        transform.position = new Vector3(toX, transform.position.y, transform.position.z); // +=가아니라 =로 해야지 마우스 위치를 바로바로 따라올 수 있음 +=는 점진적으로 더해가기 때문임. 또한 y와 z는 움직이지 않으니 원래의 값을 따름

        Shoot();
    }

    void Shoot() //void는 shoot이라는 동작을 하고나서 반환값이 없다는 뜻
    {   
        if (Time.time - lastShootTime > shootInterval)
        {   
            Instantiate(weapon, shootTransform.position, Quaternion.identity); //instantiate는 유니티 내에서 게임오브젝트를 만들어줌 (어떤오브젝트를만들지, 어떤위치에만들지, 회전은어떻게할지)//회전을 할 생각이 없으면 quaternion.identity를 쓰면댐
            lastShootTime = Time.time;
        
        }

        

    }

}

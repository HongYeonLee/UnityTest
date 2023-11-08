using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin; //에너미가 코인이라는 객체를 알게함, 유니티에서 에너미 컴포넘트 중 스크립트에 코인 프리펩을 집어넣을 수 있음

    [SerializeField]
    private float moveSpeed =10f; //에너미가 떨어지는 속도
    private float minY = -7f; //에너미가 화면밖으로 나갔을 때의 최소 y값
    [SerializeField]
    private float hp = 1f;

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
    // is trigger 옵션 체크되있을 때 사용하는 메소드 (충돌을 감지만함)
    // 실제 물리적인 충돌이 필요하면 private void OnCollisionEnter2D(collision2D other) 사용
    // 충돌이 일어나면 이 메소드가 호출되고 other로 충돌대상이 전달됨
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon"){ //충돌한 대상의 태그가 Weapon이면 
            //Weapon이라는 클래스에서 weapon이라는 객체를 가져오는데, 충돌한 대상(미사일)의 게임오브젝트로부터 Weapon이라는 컴포넌트를 가져온다
            Weapon weapon = other.gameObject.GetComponent<Weapon>(); 
            hp -= weapon.damage;
            if (hp <= 0){
                if (gameObject.tag == "Boss"){ //에너미의 hp가 0이하가 됐는데 그 에너미가 보스였다면
                    GameManager.instance.SetGameWin(); //게임 매니저의 SetGameWin 호출
                }
                Destroy(gameObject); //에너미가 미사일을 맞아서 hp가 0이하가 되면 사라짐
                Instantiate(coin, transform.position, Quaternion.identity); //에너미가 사라진 그 자리에서 위에서 정의한 코인을 생성함
            }
            Destroy(other.gameObject);//충돌 대상인 미사일은 에너미와 맞으면 무조건 사라짐
        }
    }




}

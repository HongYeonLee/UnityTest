using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; //미사일이 움직이는 속도
    public float damage = 1f; //미사일의 데미지, 에너미 클래스에서 접근하게 public으로 작성해야함
    // Start is called before the first frame update
    void Start() // 게임 객체가 만들어진 후 처음 한번만 호출되는 함수 (게임 객체가 비활성했다가 다시 호출된 경우에도 호출됨)
    {
        Destroy(gameObject, 1f);//게임오브젝트를 시작 후 1초뒤에 삭제함
    }

    // Update is called once per frame
    void Update() // 플레이할 때마다 호출되는 함수
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime; // up은 (0, 1, 0)을 나타낸다. 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; //유니티내에 enemies라는 배열을 만들고 거기에 7개의 에너미를 넣어둠

    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f}; //몹들이 나올 x좌표를 배열로 저장함
    
    [SerializeField]
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start() //EnemySpawner라는 객체가 만들어지면서 Start라는 메소드가 호출됨
    {
        StartEnemyRoutine(); //StartEnemyRoutine호출
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine"); //StartCoroutine을 통해 EnemyRoutine이라는 동작이 실햄됨
        //Coroutine은 기다리는 동작과 동시에 다른 동작을 할 수 있게함
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); //메소드가 호출되면 3초정도 기다렸다가 밑에 반복문 실행

        int enemyIndex = 0;
        int spawnCount = 0;
        float moveSpeed = 5f;

        while (true)
        {    foreach (float posX in arrPosX) //여기서 posX값 선언 및 초기화
            {
                //int index = Random.Range(0, enemies.Length); // 인덱스는 enemies에 들어있는 7개의 랜덤 몹들 중에서 하나 (0~6)값을 받는 값
                SpawnEnemy(posX, enemyIndex, moveSpeed); //게임을 시작할 때 SpawnEnemy를 호출함 SpawnEnemy의 형식은 밑에서 정의함
            }

            spawnCount++; // 에너미가 한번 생성될 때마다 카운트를 올림
            //생성된 횟수가 10단위로 커질 때마다 에너미의 종류를 한 단계씩 높임 + 속도도 높임
            if(spawnCount % 10 == 0) 
            {
                enemyIndex += 1;
                moveSpeed += 2;
            }

            yield return new WaitForSeconds(spawnInterval); //spawnIntervla 정도 기다렸다가 다시 while문돌림 
        }
    }

    //spawnenemy라는 메소드가 호출될 때 전달되는 값들, posX는 반복문에 의해 arrPosX중 하나로 받고 index 또한 랜덤함수로 인해 전달받음
    
    void SpawnEnemy(float posX, int index, float moveSpeed) 
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z); //객체가 생성되는 위치 (x, y, z)
        
        if (Random.Range(0, 5) == 0) // 20%의 확률로 한단계 높은 에너미가 나오도록 설정
        {
            index += 1;
        }

        if (index >= enemies.Length) // 인덱스가 너무 높아져서 생성할 에너미가 없는 경우 방지
        {
            index -= enemies.Length -1;
        }

        // 생성된 객체를 enemyObject에 넘음
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity); 

        //Enemy라는 클래스로부터 만들어진 객체 enemy에 Enemy라는 컴포넌트를 얻어옴
        Enemy enemy = enemyObject.GetComponent<Enemy>(); 
        enemy.SetMoveSpeed(moveSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProUGUI를 사용하겠다
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; 
    // instance라는 이름으로 GamaManager객체를 만드는데 정의는 static이며 빈 값이다

    [SerializeField]
    private TextMeshProUGUI text; //유니티 내에서 Text오브젝트를 GameManager 안에 넣을 수 있음

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject gameWinPanel; 
    private int coin = 0; //코인 정의 및 초기화

    [HideInInspector] //serializeField와 정반대의 개념, 유니티 내 인스펙터에서 나타나지 않게함
    public bool isGameOver = false; //아직 게임이 끝나지 않음을 의미

    void Awake(){
    //start메소드보다 한 단계 빠르게 호출되는 메소드
    //싱글턴이라는 디자인 패턴
        if (instance == null){
            instance = this;
            //instance가 비어있으면 거기에 GameManager를 넣어주겠다
            //다른 클래스에서 GameManager.instance.~을 쓸 수 있게됨
        }
    }

    public void IncreseCoin(){
        coin += 1;
        text.SetText(coin.ToString());

        if (coin % 30 == 0){ //코인을 30단위로 먹었을 때
            Player player = FindObjectOfType<Player>(); //플레이어를 찾아와서 upgrade 불러올 예정
            if (player != null){
                player.Upgrade();
            //플레이어를 제대로 불러왔다면 upgrade 메소드 호출 -> 무기 인덱스 증가
            } 
        }
    }

    public void SetGameOver(){ //게임이 끝났을 때 하는 동작들

        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) { //널 일때 불러와서 오류생기는 것 방지
            enemySpawner.StopEnemyRoutine(); //EnemySpawner의 StopEnemyRoutine 호출 -> 에너미 스폰 멈춤
        }
        Invoke("ShowGameOverPanel", 0.8f); //어떤 메소드를 몇 초뒤에 호출할 것인지
    }

    public void SetGameWin(){ //게임이 끝났을 때 하는 동작들

        isGameOver = true;
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null) { //널 일때 불러와서 오류생기는 것 방지
            enemySpawner.StopEnemyRoutine(); //EnemySpawner의 StopEnemyRoutine 호출 -> 에너미 스폰 멈춤
        }
        Invoke("ShowGameWinPanel", 0.8f); //어떤 메소드를 몇 초뒤에 호출할 것인지
    }
    void ShowGameOverPanel() {
        
        gameOverPanel.SetActive(true); //비활성화된 게임오버패널을 활성화시킴
    }

    void ShowGameWinPanel() {
        
        gameWinPanel.SetActive(true); //비활성화된 게임윈패널을 활성화시킴
    }

    public void PlayAgain(){
        SceneManager.LoadScene("UnityTest");
    }
}
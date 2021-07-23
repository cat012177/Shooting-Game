using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 일정(생성)시간에 한번씩 적을 생성.
//필요속성: 생성시간, 적 공장, 경과 시간
//필요속성: 구간!! 최소, 최대시간
public class EnemyManager : MonoBehaviour
{
    float createTime;
    float currentTime;
    public GameObject enemyFactory;

    public float minTime = 1;
    public float maxTime = 5;
    // Start is called before the first frame update
    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    void Start()
    {
        //태어날 때 적 생성시간 설정.
        createTime = Random.Range(minTime, maxTime);
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("count : " + enemyObjectPool.Count);
        //목표: 일정(생성)시간에 한번씩 적을 생성.
        //1.시간이 흐름
        currentTime += Time.deltaTime;
        
        //2.경과시간이 됨.
        if (currentTime > createTime)
        {
            if(enemyObjectPool.Count>0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemy.SetActive(true);

                enemyObjectPool.RemoveAt(0);
                enemyObjectPool.Add(enemy);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }
            //3.적을 공장에서 생성해야한다.
            
            //4.적을 배치.
            //경과시간이 초기화
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}

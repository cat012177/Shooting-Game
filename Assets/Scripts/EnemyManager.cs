using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ����(����)�ð��� �ѹ��� ���� ����.
//�ʿ�Ӽ�: �����ð�, �� ����, ��� �ð�
//�ʿ�Ӽ�: ����!! �ּ�, �ִ�ð�
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
        //�¾ �� �� �����ð� ����.
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
        //��ǥ: ����(����)�ð��� �ѹ��� ���� ����.
        //1.�ð��� �帧
        currentTime += Time.deltaTime;
        
        //2.����ð��� ��.
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
            //3.���� ���忡�� �����ؾ��Ѵ�.
            
            //4.���� ��ġ.
            //����ð��� �ʱ�ȭ
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}

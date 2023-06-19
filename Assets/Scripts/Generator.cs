using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    Ball ball;
    [SerializeField]
    int numOfBall;
    GameObject[] markObject;
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector3 minPos;
    [SerializeField]
    Vector3 maxPos;
    [SerializeField]
    int[] numOfObjects;


    void Start()
    {
        markObject = GameObject.FindGameObjectsWithTag("Mark");
        if (markObject[0].transform.position.x > markObject[1].transform.position.x)
        {
            minPos = markObject[1].transform.position;
            maxPos = markObject[0].transform.position;
        }
        else
        {
            minPos = markObject[0].transform.position;
            maxPos = markObject[1].transform.position;
        }
        Generate();
    }
    
    void Generate()
    {
        for(int i=0; i<numOfBall; i++)
        {
            var pos = RandomPos();
            do
            {
                if (Vector2.Distance(pos, player.position) > 1.5f)
                {
                    break;
                }
                pos = RandomPos();

            } while (true);

            if (i==0 || i==1 || i == 2)
            {       
                var temp = Instantiate(ball, pos, Quaternion.identity);
                temp.id = i;
                numOfObjects[i]++;
                temp.PainColor();
            }
            else
            {
                var temp = Instantiate(ball, pos, Quaternion.identity);
                int id = Random.Range(0, 3);
                temp.id = id;
                numOfObjects[id]++;
                temp.PainColor();
            }
        }
    }

    Vector3 RandomPos()
    {
        float x = Random.Range(minPos.x, maxPos.x);
        float z = Random.Range(minPos.z, maxPos.z);
        Vector3 pos = new (x, 0.5f, z);
        return pos;
    }

    public IEnumerator CreateBall(int id)
    {
        numOfObjects[id]--;
        yield return new WaitForSeconds(1f);
        var temp = Instantiate(ball, RandomPos(), Quaternion.identity);
        int tempInt = CheckBalls();
        if(tempInt == 3)
        {
            tempInt = Random.Range(0, 3);
        }
        temp.id = tempInt;
        temp.PainColor();
        yield return null;
    }

    int CheckBalls()
    {
        foreach (var i in numOfObjects)
        {
            if (i == 0)
            {
                return i;
            }
        }
        return 3;
    }
}

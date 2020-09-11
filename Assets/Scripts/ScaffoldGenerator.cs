using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldGenerator : MonoBehaviour
{
    public GameObject Scaffold;

    GameObject Player;

    GameObject GameController;

    public int level = 1;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player(Clone)");

        GameController = GameObject.Find("GameController(Clone)");

        //for (int i = 0; i < 20; i++)
        //{
        //    //int kind = Random.Range(1, 8);
        //    int kind = Random.Range(0, 3);

        //    for (int j = 0; j < 3; j++)
        //    {
        //        //if (kind % 2 == 1)
        //        //{
        //        //    GameObject a = Instantiate(Scaffold) as GameObject;
        //        //    a.transform.position = new Vector2(-2 + 2 * j, 2.5f * i);
        //        //}

        //        //kind = (kind >> 1);

        //        if (j == kind)
        //        {
        //            GameObject a = Instantiate(Scaffold) as GameObject;
        //            a.transform.position = new Vector2(-2 + 2 * j, 2.5f * i);
        //        }

        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateScaffold(int Level)
    {
        if (level == Level)
        {
            //level++;
            Player.GetComponent<PlayerController>().level++;

            int kind = GameController.GetComponent<GameController>().kind[level - 1];

            for (int j = 0; j < 3; j++)
            {
                if (kind % 2 == 1)
                {
                    GameObject a = Instantiate(Scaffold) as GameObject;
                    a.GetComponent<ScaffoldGenerator>().level = Level + 1;
                    a.transform.position = new Vector2(-2 + 2 * j, 2 + 4f * Level);
                }

                kind = (kind >> 1);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGene : MonoBehaviour
{
    public static bool[,] pointExist = new bool[24, 7];


    public static bool[,,] playerPath = new bool[24, 7, 5];

    [SerializeField] GameObject buttonPrefab;
    public static GameObject[] buttons =new GameObject[3];
    public static int[,,] nextYPos = new int[24, 7, 5]; 
    [SerializeField] GameObject pointPrefab;
    [SerializeField] float dx;
    [SerializeField] float dy;
    [SerializeField] GameObject unit;

    private void Start()
    {
        pointExist[0, 2] = true;
        pointExist[1, 1] = true; pointExist[1, 3] = true;
        playerPath[0, 2, 1] = true; playerPath[0, 2, 3] = true;
        pointGene();
        DrawLine(new Vector3(0, 2 * dy, 0), new Vector3(1 * dx, dy, 0));
        DrawLine(new Vector3(0, 2 * dy, 0), new Vector3(1 * dx, 3 * dy, 0));
        
    }

    private void Update()
    {
        
    }

    public void pointGene()
    {
        for (int i = 0; i < pointExist.GetLength(0); i++)
        {
            int half = Random.Range(0, 2);

            if (i % 5 == 0 && i != 0)
            {
                if (half % 2 == 0)
                {
                    pointExist[i, 0] = true; pointExist[i, 1] = true;
                }
                else
                {
                    pointExist[i, 3] = true; pointExist[i, 4] = true;
                }
            }
            else if (i == 1 || i == 0)
            {

            }
            else
            {
                //ポイント2個
                if (half % 2 == 0)
                {
                    int num1 = Random.Range(0, 5);
                    int num2;

                    do
                    {
                        num2 = Random.Range(0, 5);
                    } while (num1 == num2);

                    pointExist[i, num1] = true;
                    pointExist[i, num2] = true;
                }
                //ポイント3個
                else
                {
                    int num1 = Random.Range(0, 5);
                    int num2;
                    int num3;

                    do
                    {
                        num2 = Random.Range(0, 5);
                    } while (num1 == num2);

                    do
                    {
                        num3 = Random.Range(0, 5);
                    } while (num1 == num3 || num2 == num3);


                    pointExist[i, num1] = true;
                    pointExist[i, num2] = true;
                    pointExist[i, num3] = true;
                }
            }
            for (int j = 0; j < 5; j++)
            {
                if (pointExist[i, j])
                {
                    Instantiate(pointPrefab, new Vector3(i * dx, j * dy, 0), Quaternion.identity);
                }
            }
        }
        lineGene();

    }

    public void lineGene()
    {
        int startCount = 0;
        int endCount = 0;
        Vector3[] pointsPos = new Vector3[6];
        Vector2Int[] gridCIE = new Vector2Int[6];
        int k = 0;

        for (int i = 1; i < pointExist.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (pointExist[i, j])
                {
                    startCount++;
                    pointsPos[k] = new Vector3(i * dx, j * dy, 0);
                    gridCIE[k] = new Vector2Int(i, j);
                    k++;
                }

            }
            for (int j = 0; j < 5; j++)
            {
                if (pointExist[i + 1, j])
                {
                    endCount++;
                    pointsPos[k] = new Vector3((i + 1) * dx, j * dy, 0);
                    gridCIE[k] = new Vector2Int(i, j);
                    k++;

                }

            }
            
            if (k == 4)
            {
                DrawLine(pointsPos[0], pointsPos[2]);
                playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[2].y] = true;
                DrawLine(pointsPos[1], pointsPos[3]);
                playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;


                int reci3 = Random.Range(0, 3);
                if (reci3 % 3 == 0)
                {
                    DrawLine(pointsPos[0], pointsPos[3]);
                    playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[3].y] = true;
                }
                else if (reci3 % 3 == 1)
                {
                    DrawLine(pointsPos[1], pointsPos[2]);
                    playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[2].y] = true;
                }
            }
            else if (k == 5)
            {
                int reci3 = Random.Range(0, 3);
                if (startCount == 2)
                {
                    DrawLine(pointsPos[0], pointsPos[2]);
                    playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[2].y] = true;
                    DrawLine(pointsPos[1], pointsPos[4]);
                    playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[4].y] = true;
                    if (reci3 == 0)
                    {
                        DrawLine(pointsPos[0], pointsPos[3]);
                        playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[3].y] = true;
                        DrawLine(pointsPos[1], pointsPos[3]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                    }
                    if (reci3 == 1)
                    {
                        DrawLine(pointsPos[0], pointsPos[3]);
                        playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[3].y] = true;
                    }
                    if (reci3 == 2)
                    {
                        DrawLine(pointsPos[1], pointsPos[3]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                    }
                }
                else
                {
                    DrawLine(pointsPos[0], pointsPos[3]);
                    playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[3].y] = true;
                    DrawLine(pointsPos[2], pointsPos[4]);
                    playerPath[(int)gridCIE[2].x, (int)gridCIE[2].y, (int)gridCIE[4].y] = true;
                    if (reci3 == 0)
                    {
                        DrawLine(pointsPos[1], pointsPos[3]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                        DrawLine(pointsPos[1], pointsPos[4]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[4].y] = true;
                    }
                    if (reci3 == 1)
                    {
                        DrawLine(pointsPos[1], pointsPos[3]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                    }
                    if (reci3 == 2)
                    {
                        DrawLine(pointsPos[1], pointsPos[4]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[4].y] = true;
                    }
                }
            }
            else if (k == 6)
            {
                DrawLine(pointsPos[0], pointsPos[3]);
                playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[3].y] = true;
                DrawLine(pointsPos[2], pointsPos[5]);
                playerPath[(int)gridCIE[2].x, (int)gridCIE[2].y, (int)gridCIE[5].y] = true;
                DrawLine(pointsPos[1], pointsPos[4]);
                playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[4].y] = true;

                int reci6 = Random.Range(0, 6);
                if (reci6 == 0 || reci6 == 1)
                {
                    DrawLine(pointsPos[0], pointsPos[4]);
                    playerPath[(int)gridCIE[0].x, (int)gridCIE[0].y, (int)gridCIE[4].y] = true;
                    if (reci6 == 1)
                    {
                        DrawLine(pointsPos[1], pointsPos[5]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[5].y] = true;
                    }
                }
                else if (reci6 == 2 || reci6 == 3)
                {
                    DrawLine(pointsPos[2], pointsPos[4]);
                    playerPath[(int)gridCIE[2].x, (int)gridCIE[2].y, (int)gridCIE[4].y] = true;
                    if (reci6 == 3)
                    {
                        DrawLine(pointsPos[1], pointsPos[3]);
                        playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                    }
                }
                else if (reci6 == 4)
                {
                    DrawLine(pointsPos[1], pointsPos[3]);
                    playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[3].y] = true;
                }
                else
                {
                    DrawLine(pointsPos[1], pointsPos[5]);
                    playerPath[(int)gridCIE[1].x, (int)gridCIE[1].y, (int)gridCIE[5].y] = true;
                }
            }
            //Debug.Log("kは" + k);
            //Debug.Log(" startCountは" + k);
            //Debug.Log("endCountは" + k);
            k = 0;
            startCount = 0;
            endCount = 0;
        }


    }

    void DrawLine(Vector3 startPoint, Vector3 endPoint)
    {
        // ラインの座標を設定
        GameObject lineObject = new GameObject("LineObject");

        // Line Renderer コンポーネントを追加
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();


        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);

        // その他のラインレンダラーの設定（必要に応じて）
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.red;
    }

    public void SelectPath()
    {
        Debug.Log(GameMane.playerMapPos);
        unit.transform.position = new Vector3(GameMane.playerMapPos.x * dx, GameMane.playerMapPos.y * dy, 0);
        int j = 1;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i+"は"+playerPath[GameMane.playerMapPos.x, GameMane.playerMapPos.y, i]);
            if (playerPath[GameMane.playerMapPos.x, GameMane.playerMapPos.y, i])
            {
                buttons[j] = Instantiate(buttonPrefab, new Vector3((GameMane.playerMapPos.x + 1) * dx, i * dy, 0), Quaternion.identity);
                buttons[j].name = "button" + j;
                nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, j-1] = i;
                
                j++;
            }
        }


    }

    public static void deleteButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
        }
        
    }

    public void selectedButton()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "button1")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1, nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 0]);
        }
        else if (buttonName == "button2")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1, nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 1]);
        }
        else if (buttonName == "button3")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1, nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 2]);
        }
    }




}

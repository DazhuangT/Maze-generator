using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MazeGenerator : MonoBehaviour
{
    public int col;
    public int row;
    public int end;
    public bool[,] wall = new bool[62, 62];
    public bool[,] visited = new bool[62, 62];
    public Tilemap wallLyer;
    public TileBase tile;
    public TileBase tile2;
    public int[] ran = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        //markBordedr();

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                wall[i, j] = true;
                
            }
        }
        mazeAlgorithm();
        //if()
        if (end == 1)
        {
            ran = new int[] { 2, 3, 4 ,3};
        }
        else if (end == 2)
        {
            ran = new int[] { 1, 3, 4,4 };
        }
        else if (end == 3)
        {
            ran = new int[] { 1, 2, 4,1 };
        }
        else if(end == 4)
        {
            ran = new int[] { 1, 2, 3,2 };
        }
        Endpoint();

        for (int ii = 0; ii < col; ii++)
        {
            for (int jh = 0; jh < row; jh++)
            {
                //wall[ii, jh] = true;
                if (wall[ii, jh])
                {
                    wallLyer.SetTile(new Vector3Int(-40 + ii, -40 + jh, 0), tile);
                }
            }
        }

        
    }

    //This is a method that check is all wall in the maze was visited.
    public bool allVisited()
    {
        int count = 0;
        //bool res = false;
        for (int x = 1; x < col - 1; x += 2)
        {
            for (int y = 1; y < row - 1; y += 2)
            {
                //wall[x, y] = false;
                if (!visited[x, y])
                {
                    count++;
                }
            }
        }
        return (count == 0);
    }

    void markBordedr()
    {
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                wall[0, y] = true;
                wall[x, 0] = true;
                wall[col - 1, y] = true;
                wall[x, row - 1] = true;
            }
        }
    }

    void startPoint()
    {
        System.Random r = new System.Random();
        int rm = r.Next(1, 5);
        //int rm = 3;
        switch (rm)
        {
            case 1:
                wall[1, 1] = false;
                wall[0, 1] = false;
                visited[1, 1] = true;
                end = rm;
                break;

            case 2:
                wall[1, row - 2] = false;
                wall[1, row - 1] = false;
                visited[1, row - 2] = true;
                end = rm;
                break;

            case 3:
                wall[col - 2, row - 2] = false;
                wall[col - 1, row - 2] = false;
                visited[col - 2, row - 2] = true;
                end = rm;
                break;

            case 4:
                wall[col - 2, 1] = false;
                wall[col - 2, 0] = false;
                visited[col - 2, 1] = true;
                end = rm;
                break;
        }
    }

    void mazeAlgorithm()
    {
        startPoint();
        System.Random rr = new System.Random();
        while (!allVisited())
        {
            for (int x = 1; x < col - 1; x += 2)
            {
                for (int y = 1; y < row - 1; y += 2)
                {
                    if (!wall[x, y] & visited[x, y])
                    { 
                        int rmm = rr.Next(1, 5);
                        if (rmm == 1)
                        {
                            if(x+2 < col - 1)
                            {
                                if (!visited[x + 2, y])
                                {
                                    wall[x + 2, y] = false;
                                    wall[x + 1, y] = false;
                                    visited[x + 2, y] = true;
                                }
                            }
                        }else if (rmm == 2)
                        {
                            if (x - 2 > 0)
                            {
                                if(!visited[x - 2, y])
                                {
                                    wall[x - 2, y] = false;
                                    wall[x - 1, y] = false;
                                    visited[x - 2, y] = true;
                                }
                               
                            }
                        }else if (rmm == 3)
                        {
                            if(y - 2 > 0)
                            {
                                if(!visited[x , y - 2])
                                {
                                    wall[x , y-2] = false;
                                    wall[x , y-1] = false;
                                    visited[x, y-2] = true;
                                }

                            }
                        }
                        else
                        {
                            if (y + 2 <row -1)
                            {
                                if (!visited[x, y + 2])
                                {
                                    wall[x, y + 2] = false;
                                    wall[x, y + 1] = false;
                                    visited[x, y + 2] = true;
                                }
                            }

                        }
                    }
                }
            }
            //return wall;
        }       
    }

    void Endpoint()
    {
        System.Random rrr = new System.Random();
        int rmr = rrr.Next(4);

        if (ran[rmr] == 1)
        {
            wall[0, 1] = false;
            //wall[-1, 1] = true;
        }
        else if (ran[rmr] == 2)
        {
            wall[1, row - 1] = false;
           // wall[1, row] = true;
        }
        else if (ran[rmr] == 3)
        {
            wall[col - 1, row - 2] = false;
            //wall[col, row - 2] = true;
        }
        else if (ran[rmr] == 4)
        {
            wall[col - 2, 0] = false;
            //wall[col - 2, -1] = true;
        }

    }

    void Update()
    {
        //bool swaped = false;
        if (Input.GetKey(KeyCode.U))
        {
            wallLyer.SwapTile(tile, tile2);
            
        }else if (Input.GetKey(KeyCode.I))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            
        }else if (Input.GetKey(KeyCode.O))
        {
            wallLyer.SwapTile(tile2, tile);
        }
    }           
}


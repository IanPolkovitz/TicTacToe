using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    public Button b1, b2, b3, b4, b5, b6, b7, b8, b9;
    public int turn = 1;
    public GameObject x;
    public GameObject o;
    static int[] board = new int[9];

    void Start()
    {
        InitializeBoard();
    }
    public void b1Press()
    {
        Instantiate(x, new Vector3(-3, 3, 0), Quaternion.identity);
        turn++;
        board[0] = -1;
        Checkwin();
        b1.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b2Press()
    {
        Instantiate(x, new Vector3(0, 3, 0), Quaternion.identity);
        turn++;
        board[1] = -1;
        Checkwin();
        b2.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b3Press()
    {
        Instantiate(x, new Vector3(3, 3, 0), Quaternion.identity);
        turn++;
        board[2] = -1;
        Checkwin();
        b3.enabled = false;
        Invoke("AIMove", 1);
    }
   
    public void b4Press()
    {
        Instantiate(x, new Vector3(-3, 0, 0), Quaternion.identity);
        turn++;
        board[3] = -1;
        Checkwin();
        top.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b5Press()
    {
        Instantiate(x, new Vector3(0, 0, 0), Quaternion.identity);
        turn++;
        board[4] = -1;
        Checkwin();
        b5.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b6Press()
    {
        Instantiate(x, new Vector3(3, 0, 0), Quaternion.identity);
        turn++;
        board[5] = -1;
        Checkwin();
        b6.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b7Press()
    {
        Instantiate(x, new Vector3(-3, -3, 0), Quaternion.identity);
        turn++;
        board[6] = -1;
        Checkwin();
        b7.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b8Press()
    {
        Instantiate(x, new Vector3(0, -3, 0), Quaternion.identity);
        turn++;
        board[7] = -1;
        Checkwin();
        b8.enabled = false;
        Invoke("AIMove", 1);
    }
    public void b9Press()
    {
        Instantiate(x, new Vector3(3, -3, 0), Quaternion.identity);
        turn++;
        board[8] = -1;
        Checkwin();
        b9.enabled = false;
        Invoke("AIMove", 1);
    }
    



    static void AIMove()
    {
        
        int[] bestMove = GetBestMove();
        if (bestMove[0] == 0)
        {
            Instantiate(o, new Vector3(-3, 3, 0), Quaternion.identity);
            turn++;
            board[0] = 1;
            Checkwin();
            b1.enabled = false;
        }
        else if (bestMove[0] == 1)
        {
            Instantiate(o, new Vector3(0, 3, 0), Quaternion.identity);
            turn++;
            board[1] = 1;
            Checkwin();
            b2.enabled = false;
        }
        else if (bestMove[0] == 2)
        {
            Instantiate(o, new Vector3(3, 3, 0), Quaternion.identity);
            turn++;
            board[2] = 1;
            Checkwin();
            b3.enabled = false;
        }
        else if (bestMove[0] == 3)
        {
            Instantiate(o, new Vector3(-3, 0, 0), Quaternion.identity);
            turn++;
            board[3] = 1;
            Checkwin();
            b4.enabled = false;
        }
        else if (bestMove[0] == 4)
        {
            Instantiate(o, new Vector3(0, 0, 0), Quaternion.identity);
            turn++;
            board[4] = 1;
            Checkwin();
            b5.enabled = false;
        }
        else if (bestMove[0] == 5)
        {
            Instantiate(o, new Vector3(3, 0, 0), Quaternion.identity);
            turn++;
            board[5] = 1;
            Checkwin();
            b6.enabled = false;
        }
        else if (bestMove[0] == 6)
        {
            Instantiate(o, new Vector3(-3, -3, 0), Quaternion.identity);
            turn++;
            board[6] = 1;
            Checkwin();
            b7.enabled = false;
        }
        else if (bestMove[0] == 7)
        {
            Instantiate(o, new Vector3(0, -3, 0), Quaternion.identity);
            turn++;
            board[7] = 1;
            Checkwin();
            b8.enabled = false;
        }
        else
        {
            Instantiate(o, new Vector3(3, -3, 0), Quaternion.identity);
            turn++;
            board[8] = 1;
            Checkwin();
            b9.enabled = false;
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = 0;
        }
    }

    static int[] GetBestMove()
    {
        int bestScore = int.MinValue;
        int[] bestMove = new int[1];

        for (int i = 0; i < 9; i++)
        {
            if (board[i] == 0)
            {
                board[i] = 1;
                int score = MiniMax(board, 0, int.MinValue, int.MaxValue, false);
                board[i] = 0;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove[0] = i;
                }
            }
        }

        return bestMove;
    }

    static int MiniMax(int[] board, int depth, int alpha, int beta, bool isMaximizing)
    {
        if (Checkwin())
        {
            return (isMaximizing) ? -1 : 1;
        }
        else if (IsBoardFull(board))
        {
            return 0;
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 0)
                {
                    board[i] = 1;
                    int score = MiniMax(board, depth + 1, alpha, beta, false);
                    board[i] = 0;   
                    bestScore = Math.Max(score, bestScore);
                    alpha = Math.Max(alpha, bestScore);
                    if (beta <= alpha)
                        break;
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 0)
                {
                    board[i] = -1;
                    int score = MiniMax(board, depth + 1, alpha, beta, true);
                    board[i] = 0;
                    bestScore = Math.Min(score, bestScore);
                    beta = Math.Min(beta, bestScore);
                    if (beta <= alpha)
                        break;
                }
            }
            return bestScore;
        }
    }
    public int Checkwin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2] && board[i * 3] != 0 && turn <= 9)
            {
                return board[i * 3];
            }
            else if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i] != 0 && turn <= 9)
            {
                return board[i];
            }
        }
        if (board[0] == board[4] && board[4] == board[8] && board[0] != 0 && turn <= 9)
        {
            return board[0];
        }
        else if (board[2] == board[4] && board[4] == board[6] && board[2] != 0 && turn <= 9)
        {
            return board[2];
        }
        return 0;
    }

    static bool IsBoardFull()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 0)
            {
                return false;
            }
        }
        return true;
    }
}

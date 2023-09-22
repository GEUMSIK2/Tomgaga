using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Puzzle1 puzzle1;
    public Puzzle2 puzzle2;
    public AudioClip puzzleClearAudioClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PuzzleClear()
    {
        SoundManagaer.instance.PlaySFX(puzzleClearAudioClip);
    }

    // �÷��̾� ������ �� �� ����, Ʈ�� ����.
    public void PuzzlesReset()
    {
        if (!puzzle1.IsCoimpleted)
        {
            puzzle1.ResetPuzzle();
        }
        else if (!puzzle2.IsCompleted)
        {
            puzzle2.ResetPuzzle();
        }
    }
}

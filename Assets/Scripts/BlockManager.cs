using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject block;
    public Grid grid;

    void Start()
    {
        int length = 13;   // ��� ���� �� ���� �ǹ�
        for (int i = 0; i < length; i++) // ��� ����� for ��
        {
            int tileCount = GetTileCount(); // Ÿ�� ���� ���� ��
            int[] positionX = GetRandomGridPosition(tileCount); // Ÿ�� ���� ��ǥ
            for (int j = 0; j < tileCount; j++) // Ÿ�� ������ŭ ��ǥ�� Ÿ�� ����
            {
                Vector3 randomPos = new Vector3(-3.5f + positionX[j] * 0.5f, 6.5f + i * 2, 0);
                Instantiate(block, randomPos, Quaternion.identity);
            }
        }
    }

    // Ÿ�� ���� ��ǥ
    private int[] GetRandomGridPosition(int tileCount)
    {
        List<int> availableNumbers = new List<int>();
        for(int i =0; i<19; i++)
        {
            availableNumbers.Add(i);
        }

        int[] positionX = new int[tileCount]; // ���� ��ǥ ��� ���� �迭
        for (int i = 0; i < tileCount; i++)
        {
            positionX[i] = PickNumber(availableNumbers); // ����� ������ ��ǥ�� ��ġ���� Ȯ��
        }

        return positionX;
    }

    // ����� ������ ��ǥ�� ��ġ���� Ȯ��
    private int PickNumber(List<int> availableNumbers)
    {
        int pickedNumber;
        bool isValidNumber;

        do
        {
            int index = Random.Range(0, availableNumbers.Count); // ���ڸ� �������� 1�� ����
            pickedNumber = availableNumbers[index];
            isValidNumber = CheckIfValidNumber(pickedNumber, availableNumbers); // ���� ���ڰ� �Ȱ�ġ���� Ȯ��

        } while (!isValidNumber);

        RemoveNumbersInRange(pickedNumber, availableNumbers); // ���� ���ڸ� ��ġ�� �ʵ��� �迭���� �� ����
        return pickedNumber;
    }

    private bool CheckIfValidNumber(int number, List<int> availableNumbers)
    {
        for (int i = 0; i < 4; i++) // ���� ���ڸ� �������� ����� ��ġ�� �ʰ� �� �� �ִ��� Ȯ��
        {
            int numToCheck = (number + i) % 19;
            if (!availableNumbers.Contains(numToCheck))
            {
                return false;
            }
        }
        return true;
    }

    private void RemoveNumbersInRange(int number, List<int> availableNumbers)
    {
        for (int i = -1; i < 5; i++) // ���� ���� �������� 6ĭ�� ���� (��� 4ĭ + �¿� 2ĭ)
        {
            int numToRemove = (number + i) % 19;
            availableNumbers.Remove(numToRemove);
        }
    }

    private int GetTileCount()
    {
        return Random.Range(2, 4);
    }

    void Update()
    {
    }    
}

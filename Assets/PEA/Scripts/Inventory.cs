using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject > items = new List<GameObject>();

    public Transform inventoryContents;
    private GameObject[] itemSlots;

    void Start()
    {
        itemSlots = new GameObject[inventoryContents.childCount];
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = inventoryContents.GetChild(i).gameObject;
            print(itemSlots[i].name);
        }

        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    // �κ��丮�� ���� ���
    public void PutItemIntoInventory(GameObject item)
    {
        items.Add(item);
        SetInventory();
    }

    // �κ��丮�� ��� ���ǵ� UI�� �־��ֱ�
    public void SetInventory()
    {
        int i = 0;
        foreach (GameObject item in items)
        {
            item.transform.SetParent(itemSlots[i].transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale = Vector3.one * 30f;
            i++;
        }
    }

    // �κ��丮�� �ִ� ������ ������
    public void TakeItemOut(GameObject item)
    {
        print("������");
        items.Remove(item);
        item.transform.SetParent(null);
        item.transform.position = Vector3.zero;
        item.transform.localScale = Vector3.one;
        SetInventory();
    }
}

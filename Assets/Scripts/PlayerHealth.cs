using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxLives = 3;                            //�ִ� �����
    public int currentLives = 1;                        //���� �����

    public float invincibleTime = 1.0f;                 //�ǰ� �� ���� �ð�
    public bool isInvincible = false;                   //���� ������ ��

    // Start is called before the first frame update
    void Start()
    {
        currentLives = MaxLives;                        //����� �ʱ�ȭ
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)         //Ʈ���� ���� �ȿ� ���Դٸ� �����ϴ� �Լ�
    {
        //�̻��� �浹 �˻�
        if (other.CompareTag("Missile"))
        {
            currentLives--;
            Destroy(other.gameObject);                                            //�̻��� ������Ʈ�� �����Ѵ�.
            if (currentLives <= 0)
            {
                GameOver();
            }                                       //�̻��ϰ� �浹�� 1�� ������� ���� �Ѵ�.
        }
    }

    public void GameOver()              //���� ���� ó��
    {
        gameObject.SetActive(false);                        //�÷��̾� ��Ȱ��ȭ
        Invoke("RestartGame", 3.0f);                        //3�� �� ���� �� �����
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //���� �� �����
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoomFloorTrap : MonoBehaviour
{
    // ===== public =====

    [Tooltip("�ٴ� Ʈ�� ��ü�� ��� ����")]
    public GameObject trap;

    [Tooltip("Ʈ���� ����/�ö���� �ּ� �ð�")]
    public float minMoveTimes = 0.3f;

    [Tooltip("Ʈ���� ����/�ö���� �ִ� �ð�")]
    public float maxMoveTimes = 0.9f;

    [Tooltip("Ʈ�� �ּ� �ẹ �ð�")]
    public float minHiddenTimes = 1.5f;

    [Tooltip("Ʈ�� �ִ� �ẹ �ð�")]
    public float maxHiddenTimes = 4.0f;

    [Tooltip("Ʈ�� �ּ� ���� �ð�")]
    public float minProtrusionTimes = 1.2f;

    [Tooltip("Ʈ�� �ִ� ���� �ð�")]
    public float maxPortrusionTimes = 2.25f;

    // ===== private =====

    // Ʈ�� �ẹ �ð� ( �ּ� �ẹ �ð��� �ִ� �ẹ �ð� ���̿��� ���������� ����. )
    private float hiddenTimes = 0f;

    // Ʈ�� ���� �ð� ( �ּ� ���� �ð��� �ִ� ���� �ð� ���̿��� ���������� ����. )
    private float protrusionTimes = 0f;

    // Ʈ�� �̵� �ð� ( �ּ� �̵� �ð��� �ִ� �̵� �ð� ���̿��� ���������� ����. )
    private float moveTimes = 0f;

    // ���� �ð�
    private float maintainenceTime = 0f;

    // ���� ����/�ö���� �� ��� �������� Ȯ��
    private bool bIsLiftingOff = false;

    // ���� ���¸� �����ϴ��� Ȯ���ϴ� ����
    private bool bIsMaintainence = false;

    // ���� Ʈ�� ����
    private float height = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // ���������� �ʱ�ȭ
        hiddenTimes = Random.Range(minHiddenTimes, maxHiddenTimes);
        protrusionTimes = Random.Range(minProtrusionTimes, maxPortrusionTimes);
        moveTimes = Random.Range(minMoveTimes, maxMoveTimes);
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ������ ��
        if(bIsMaintainence)
        {
            // ���� �ð��� ���� �Ǵ� �ẹ �ð����� �� �� ��
            if((bIsLiftingOff ? protrusionTimes : hiddenTimes) < maintainenceTime)
            {
                // ���� ���� ����
                bIsMaintainence = false;

                // ���� ���� �ð� �ʱ�ȭ
                maintainenceTime = 0f;

                // ���� ������ �ݴ�� ����.
                bIsLiftingOff = !bIsLiftingOff;
            }

            else
            {
                maintainenceTime += Time.deltaTime;
            }

        }

        // ���� ���� ������ �ƴ� ��
        else
        {
            // ���� �ö���� ���̶��
            if(bIsLiftingOff)
            {
                // Ʈ���� �ִ� ���̱��� �ö�Դٸ�
                if(height > 0.0f)
                {
                    // ���� ����
                    height = 0.0f;

                    // ���� ���·� ����
                    bIsMaintainence = true;
                }
                // Ʈ���� �ִ� ���̱��� �ö���� �ʾҴٸ�
                else
                {
                    // ���� �ø���
                    height += 0.06f / moveTimes * Time.deltaTime;
                }
                // ��ġ ����
                trap.transform.localPosition = new Vector3(trap.transform.localPosition.x, height, trap.transform.localPosition.z);
            }

            // ���� ���� ���̶��
            else
            {
                // Ʈ���� �ִ� ���̱��� �ö�Դٸ�
                if (height < -0.3f)
                {
                    // ���� ����
                    height = -0.3f;

                    // �� ���·� ����
                    bIsMaintainence = true;
                }
                // Ʈ���� �ּ� ���̱��� �������� �ʾҴٸ�
                else
                {
                    // ���� ������
                    height -= 0.06f / moveTimes * Time.deltaTime;
                }
                // ��ġ ����
                trap.transform.localPosition = new Vector3(trap.transform.localPosition.x, height, trap.transform.localPosition.z);
            }
        }
    }
}

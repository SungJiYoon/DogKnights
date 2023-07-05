using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRoomFloorButton : MonoBehaviour
{
    // ===== public =====

    [Tooltip("��ư�� Material ������ ��� ��ü")]
    public Material buttonMaterial;

    [Tooltip("�÷��̾�� �������� ��, ����Ǵ� ����")]
    public Color InteractToColor;

    // ===== private =====
    private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {

        renderer = gameObject.GetComponent<MeshRenderer>();

        // renderer.material.color = InteractToColor;

        // renderer.material.SetColor("_EmissionColor", InteractToColor);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Box Collider�� Player�� �浹���� ���� �۵��ǵ��� ����.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            // Albedo�� Emissive Color�� ���ÿ� ����.
            renderer.material.color = InteractToColor;

            renderer.material.SetColor("_EmissionColor", InteractToColor);
        }
    }
}

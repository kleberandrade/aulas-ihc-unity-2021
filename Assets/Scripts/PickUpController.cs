using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject m_CollectableItem;
    public bool m_UseHintText = true;
    public GameObject m_Slot;
    public float m_DropDistance = 2.0f;

    public void PickUp()
    {
        m_CollectableItem.transform.parent = m_Slot.transform;
        m_CollectableItem.transform.position = Vector3.zero;
        m_CollectableItem.SetActive(false);
    }

    public void Drop()
    {
        if (m_Slot.transform.childCount == 0) return;
        GameObject collectableItem = m_Slot.transform.GetChild(0).gameObject;

        var position = transform.position + transform.TransformDirection(transform.forward) * m_DropDistance;

        collectableItem.transform.parent = null;
        collectableItem.transform.position = position;
        collectableItem.gameObject.SetActive(true);
    }

    public void Use()
    {
        if (m_Slot.transform.childCount == 0) return;
        GameObject collectableItem = m_Slot.transform.GetChild(0).gameObject;
        // Lógica para usar o item
        Destroy(collectableItem);
    }

    public void Equip()
    {

    }

    public void Update()
    {
        if (m_CollectableItem && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

    public void ShowHintText()
    {
        if (!m_UseHintText) return;
        HintText.Instance.Show();
    }

    public void HideHintText()
    {
        if (!m_UseHintText) return;
        HintText.Instance.Hide();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Collectable")) return;
        m_CollectableItem = other.gameObject;
        ShowHintText();
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Collectable")) return;
        m_CollectableItem = null;
        HideHintText();
    }
}

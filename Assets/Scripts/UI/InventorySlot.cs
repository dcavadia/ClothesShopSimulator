using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : ItemSlot, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    private bool isSelected;
    private GameObject iconGhost;
    private Image slotImage;
    private UIManager UIManager;

    [SerializeField] private Color selectedColor;

    private bool isPointerDown;
    private float clickTimer;

    private const float CLICK_DURATION_THRESHOLD = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        UIManager = UIManager.Instance;
        iconGhost = UIManager.ShopPanel.iconGhost;
        slotImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (isPointerDown)
        {
            clickTimer += Time.deltaTime;
        }
    }

    // Triggered when the inventory slot is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {

            isSelected = !isSelected;

            if (UIManager.isShopPanelOpen())
            {
                UIManager.ShopPanel.shopInfoPanel.ShowInventoryItemInfo(item);
            }
            else if (UIManager.isInventoryPanelOpen())
            {
                UIManager.InventoryPanel.ShowEquipButton();
            }

            UIManager.InventoryPanel.SelectSlot(this);
            UIManager.ShopPanel.SelectSlot(null);
            UIManager.EquipPanel.SelectSlot(null);
            UpdateSlotColor();
        }
    }

    // Triggered when a pointer is pressed on the inventory slot
    public void OnPointerDown(PointerEventData eventData)
    {
        if (item == null)
            return;

        isPointerDown = true;
        clickTimer = 0f;
    }

    // Triggered when a pointer is released on the inventory slot
    public void OnPointerUp(PointerEventData eventData)
    {
        if (item == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    // Triggered when the inventory slot is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        if (item == null)
            return;

        if (isPointerDown && clickTimer >= CLICK_DURATION_THRESHOLD)
        {
            iconGhost.GetComponent<Image>().sprite = itemIcon.sprite;
            iconGhost.SetActive(true);
            itemIcon.enabled = false;

            iconGhost.transform.position = eventData.position;
        }
    }

    // Triggered when the dragging of the inventory slot ends
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    // Triggered when the inventory slot is dropped onto another slot
    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot sourceSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        InventorySlot destinationSlot = this;

        if (sourceSlot != null && sourceSlot.item != null && destinationSlot != null && sourceSlot != destinationSlot)
        {
            ItemData sourceItem = sourceSlot.item.data;
            string sourceUid = sourceSlot.item.uid;

            if (destinationSlot.item == null)
            {
                sourceSlot.ClearSlot();
                destinationSlot.SetItem(sourceUid, sourceItem);
                iconGhost.SetActive(false);
            }
            else
            {
                sourceSlot.SetItem(destinationSlot.item.uid, destinationSlot.item.data);
                destinationSlot.SetItem(sourceUid, sourceItem);
            }

            UIManager.InventoryPanel.SelectSlot(null);
        }
    }

    // Updates the color of the inventory slot based on its selection state
    private void UpdateSlotColor()
    {
        slotImage.color = isSelected ? selectedColor : Color.white;
    }

    public override void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateSlotColor();
    }
}


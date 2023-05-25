using Unity.VisualScripting;
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

    private void LateUpdate()
    {
        
        //isPointerDown = false;
        //clickTimer = 0f;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            clickTimer += Time.deltaTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemData != null)
        {
            if (clickTimer < CLICK_DURATION_THRESHOLD)
            {
                // Handle short click here
                Debug.Log("Short Click");
            }

            isSelected = !isSelected;

            if (UIManager.isShopPanelOpen())
            {
                UIManager.ShopPanel.shopInfoPanel.ShowInventoryItemInfo(itemData);
            }
            else if (UIManager.isInventoryPanelOpen())
            {
                UIManager.InventoryPanel.ShowEquipButton();
            }

            UIManager.InventoryPanel.SelectSlot(this);
            UpdateSlotColor();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        isPointerDown = true;
        clickTimer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        if (isPointerDown && clickTimer >= CLICK_DURATION_THRESHOLD)
        {
            iconGhost.GetComponent<Image>().sprite = itemIcon.sprite;
            //iconGhost.transform.position = 
            iconGhost.SetActive(true);
            itemIcon.enabled = false;

            Debug.Log("Draggin!");
            iconGhost.transform.position = eventData.position;
        }



    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemData == null)
            return;

        iconGhost.SetActive(false);
        itemIcon.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot sourceSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        InventorySlot destinationSlot = this;

        if (sourceSlot != null && sourceSlot.itemData != null && destinationSlot != null && sourceSlot != destinationSlot)
        {
            ItemData sourceItem = sourceSlot.itemData;
            string sourceUid = sourceSlot.itemUid;

            if (destinationSlot.itemData == null)
            {
                sourceSlot.ClearSlot();
                destinationSlot.SetItem(sourceUid, sourceItem);
                iconGhost.SetActive(false);
            }
            else
            {
                sourceSlot.SetItem(destinationSlot.itemUid, destinationSlot.itemData);
                destinationSlot.SetItem(sourceUid, sourceItem);
            }
        }
    }

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


using UnityEngine;

public class PlayerCustomizationManager : SingletonComponent<PlayerCustomizationManager>
{
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Sprite defaultPlayerSkin;

    private ItemData currentSkin;

    private void LateUpdate()
    {
        if (currentSkin != null)
        {
            SetSkinSprites();
        }
    }

    // Set the current skin for the player
    public void SetSkin(ItemData itemData)
    {
        currentSkin = itemData;
    }

    // Remove the current skin for the player
    public void RemoveSkin()
    {
        currentSkin = null;
    }

    // Get the sprite of the current skin
    public Sprite GetSkinPicture()
    {
        if (currentSkin != null)
        {
            return currentSkin.sprites[0];
        }
        else
        {
            return defaultPlayerSkin;
        }
    }

    // Set the sprite of the player based on the current skin
    private void SetSkinSprites()
    {
        if (playerSpriteRenderer.sprite != null && playerSpriteRenderer.sprite.name.Contains("rpg_sprite_walk"))
        {
            string spriteName = playerSpriteRenderer.sprite.name;
            spriteName = spriteName.Replace("rpg_sprite_walk_", "");
            int spriteNumber;

            // Check if the sprite number is valid and within the range of the skin sprites array
            if (int.TryParse(spriteName, out spriteNumber) && spriteNumber >= 0 && spriteNumber < currentSkin.sprites.Length)
            {
                playerSpriteRenderer.sprite = currentSkin.sprites[spriteNumber];
            }
        }
    }
}

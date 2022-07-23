using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public partial class GridTest : MonoBehaviour
{
    [SerializeField]
    private Vector3Int select;

    public Vector3Int Select
    {
        get => this.select;

        set
        {
            // 复原old选择
            this.tilemap.SetColor(this.select, this.normalColor);
            this.select = value;
            // 记录初始颜色
            this.normalColor = this.tilemap.GetColor(this.select);
            // 高亮new选择
            this.tilemap.SetColor(this.select, this.highlightColor);
            this.tilemap.RefreshAllTiles();
        }
    }

    public Tilemap tilemap;
    public Color highlightColor;
    public Color normalColor;

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerClick");
    //     
    //     // 仅左键选择
    //     if (eventData.button != PointerEventData.InputButton.Left)
    //     {
    //         return;
    //     }
    //     // 获取世界坐标
    //     var pos = eventData.pointerCurrentRaycast.worldPosition;
    //     // 世界坐标 -> cell坐标
    //     var posInt = tilemap.WorldToCell(pos);
    //     // 可通过GetTile()获取对应位置tilebase
    //     Debug.Log(tilemap.GetTile(posInt));
    //
    //     // RuleTile可以通过SetColor方法改变颜色
    //     this.Select = posInt;
    //
    //     // 默认的Tile类型可以直接改变颜色，但是会影响所有Tile资源
    //     //if (tilemap.GetTile(posInt) is Tile tile)
    //     //{
    //     //    tile.color = this.highlightColor;
    //     //    this.tilemap.RefreshAllTiles();
    //     //}
    // }
    private void Start()
    {
        // 防止(0,0,0)处Tile被错误的设置颜色
        if (this.tilemap.HasTile(this.select))
        {
            this.normalColor = tilemap.GetColor(this.select);
            this.tilemap.SetColor(this.select, this.normalColor);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         
            var tpos = this.tilemap.WorldToCell(worldPoint);

            // Try to get a tile from cell position
            var tile = this.tilemap.GetTile(tpos);

            if(tile)
            {
                Debug.Log(this.tilemap.HasTile(tpos));
                this.tilemap.SetColor(tpos, this.highlightColor);
                this.tilemap.RefreshAllTiles();
            }
        }
    }
}
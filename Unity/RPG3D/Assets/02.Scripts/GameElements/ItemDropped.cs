using RPG.Collections;
using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.GameElements
{
    public class ItemDropped : MonoBehaviour
    {
        [SerializeField]private int _itemID;
        [SerializeField]private int _itemNum;
        private MeshFilter _filter;
        private MeshRenderer _renderer;
        private bool _hasPickedUp;
        private Vector3 _rendererLocation;

        public static ItemDropped Create(int itemID, int itemNum, Vector3 position)
        {
            GameObject gameObjcet = new GameObject("ItemDropped");
            gameObjcet.transform.position = position;
            gameObjcet.layer = LayerMask.NameToLayer("ItemDropped");
            gameObjcet.AddComponent<BoxCollider>().isTrigger = true;
            ItemDropped itemDropped = gameObjcet.AddComponent<ItemDropped>();
            GameObject child = new GameObject("Renderer");
            child.transform.SetParent(gameObjcet.transform);
            itemDropped._filter = child.AddComponent<MeshFilter>();
            itemDropped._renderer = child.AddComponent<MeshRenderer>();

            ItemData itemData = ItemDataRepository.instance[itemID];
            child.transform.localPosition = itemData.droppedRenderLocation;
            child.transform.localRotation = Quaternion.Euler(itemData.droppedRenderRotation);
            child.transform.localScale = itemData.droppedRenderScale;
            itemDropped._filter.sharedMesh = itemData.model.GetComponent<MeshFilter>().sharedMesh;
            itemDropped._renderer.sharedMaterials = itemData.model.GetComponent<MeshRenderer>().sharedMaterials;

            itemDropped._itemID = itemID;
            itemDropped._itemNum = itemNum;

            return itemDropped;
        }


        public void PickUp()
        {
            if (_hasPickedUp)
                return;

            _hasPickedUp = true;

            if(DataModelManager.instance.TryGet<InventoryData>(out InventoryData dataModel))
            {
                ItemData itemData = ItemDataRepository.instance[_itemID];
                int remains = 0;

                switch (itemData.type)
                {
                    case ItemType.Equipment:
                        remains = FillInventoryData(dataModel.equipmentSlotDatum, itemData);
                        break;
                    case ItemType.Spend:
                        remains = FillInventoryData(dataModel.spendSlotDatum, itemData);
                        break;
                    case ItemType.ETC:
                        remains = FillInventoryData(dataModel.etcSlotDatum, itemData);
                        break;
                    default:
                        break;
                }

                if (remains > 0)
                {
                    _itemNum = remains;
                    _hasPickedUp = false;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        /// <summary>
        /// Fills Inventory Data and returns remains
        /// </summary>
        /// <returns> remains </return>
        private int FillInventoryData<T>(ObservableCollection<T> slotDatum, ItemData itemData)
            where T : InventoryData.ItemSlotData
        {
            

            int remains = _itemNum;

            for (int i = 0; i < slotDatum.Count; i++)
            {
                var slotData = slotDatum[i];

                if (slotData.isEmpty ||
                    (slotData.itemID == _itemID && slotData.itemNum < itemData.numMax))
                {
                    int expected = remains - itemData.numMax + slotData.itemNum;
                    if (expected > 0)
                    {
                        slotData.itemID = itemData.id;
                        slotData.itemNum = itemData.numMax;
                        slotDatum[i] = slotData;
                        remains = expected;
                    }
                    else
                    {
                        slotData.itemNum = slotData.itemNum + remains;
                        slotDatum[i] = slotData;
                        remains = 0;
                        break;
                    }
                }
            }

            return remains;
        }


        private void Start()
        {
            _rendererLocation = transform.GetChild(0).localPosition;
            StartCoroutine(Pop());
        }

        IEnumerator Pop()
        {
            Vector3 dir = new Vector3(Random.Range(-1f,1f), 1.0f,Random.Range(-1f,1f)).normalized;
            dir.y = dir.y * 5f;
            float speed = 1f;
            float drag = 0.1f;

            LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");

            while (true)
            {
                Collider[] grounds = Physics.OverlapBox(transform.position, Vector3.one / 2.0f, Quaternion.identity, groundMask);
                if(grounds.Length > 0)
                {
                    dir.x = 0f;
                    dir.z = 0f;

                    if (Physics.Raycast(transform.position,Vector3.down,1.0f,groundMask))
                    {
                        break;
                    }
                }


                transform.position += new Vector3(dir.x * speed, dir.y, dir.z * speed) * Time.deltaTime;
                dir.y -= 9.81f * Time.deltaTime;
                

                if (speed > 0f)
                    speed -= drag * Time.deltaTime;

                yield return null;
            }
        }

        private void Update()
        {
            Transform child = transform.GetChild(0);
            child.localPosition = _rendererLocation + 0.1f*Vector3.up * Mathf.Sin(Time.time);
        }
    }
}

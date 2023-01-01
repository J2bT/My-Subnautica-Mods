#if SUBNAUTICA
using RecipeData = SMLHelper.V2.Crafting.TechData;
#elif BELOWZERO
using System.Collections;
#endif
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace J2bT.ControlChipMod
{
    public class MapRoomControlChip : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
        public MapRoomControlChip() : base("MapRoomControlChip", "Scanner Room Chip MK2", "Streams data from scanner rooms to the HUD and sends data back.")
        {
            OnFinishedPatching += () =>
            {
                TechTypeID = this.TechType;
            };
        }
        public override EquipmentType EquipmentType => EquipmentType.Chip;
        public override TechType RequiredForUnlock => TechType.MapRoomHUDChip;
        public override TechGroup GroupForPDA => TechGroup.Workbench;
        public override TechCategory CategoryForPDA => TechCategory.Workbench;
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override float CraftingTime => 1f;
        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        protected override RecipeData GetBlueprintRecipe()
        {
            return new RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>(new Ingredient[]
                    {
                        new Ingredient(TechType.MapRoomHUDChip, 1),
                        new Ingredient(TechType.CopperWire, 1)
                    }
                )
            };
        }
#if ASYNC
        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.MapRoomHUDChip);
            yield return task;
            GameObject origibalPrefab = task.GetResult();
            GameObject resultPrefab = Object.Instantiate(origibalPrefab);
            gameObject.Set(resultPrefab);
        }
#else
        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(TechType.MapRoomHUDChip);
            var obj = GameObject.Instantiate(prefab);
            return obj;
        }
#endif
    }
}
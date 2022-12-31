using System;
using UnityEngine;

namespace J2bT.ControlChipMod.MonoBehaviours
{
    public class uGUI_ResourceIcon : MonoBehaviour
    {
        public uGUI_ResourceIcon()
        {
        }

        public static uGUI_ResourceIcon main;
        public Vector2 iconSize = new Vector2(60f, 60f);
        public float timeIn = 1f;
        public float timeOut = 0.5f;
        public float oscReduction = 100f;
        public float oscFrequency = 5f;
        public float oscScale = 2f;
        public float oscDuration = 2f;
        private uGUI_ItemIcon icon;
        private Sequence sequence = new Sequence();
        private bool show;
        private float oscSeed;
        private float oscTime;
        private GameObject go;

        private void Awake()
        {
            if (main == null)
            {
                main = this;
                go = new GameObject("ResourceIcon");
                icon = go.AddComponent<uGUI_ItemIcon>();
                icon.Init(null, transform, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
                icon.SetSize(iconSize);
                icon.SetBackgroundSprite(SpriteManager.GetBackground(CraftData.BackgroundType.Normal));
                icon.SetBackgroundRadius(Mathf.Min(iconSize.x, iconSize.y) * 0.5f);
                Color color = new Color(10f, 100f, 160f, 2f);
                icon.SetBackgroundColors(color, color, color);
                SetAlpha(0f);
                sequence.ForceState(false);
                
                return;
            }
            Destroy(this);
        }

        private void Update()
        {
            if (ControlChipMono.mapRooms.Count > 0 && ControlChipMono.mapRooms[ControlChipMono.roomIndex].mapRoom.typeToScan != TechType.None && ControlChipMono.ChipIsInSlot())
            {
                icon.SetForegroundSprite(SpriteManager.Get(SpriteManager.Group.Item, ControlChipMono.mapRooms[ControlChipMono.roomIndex].mapRoom.typeToScan.AsString()));
                go.transform.position = new Vector3(0f, -0.4f, 1.0f);
            }
        }

        private void LateUpdate()
        {
            if (sequence.target != show)
            {
                if (show && sequence.t == 0f)
                {
                    oscTime = Time.time;
                    oscSeed = UnityEngine.Random.value;
                }
                sequence.Set(show ? timeIn : timeOut, show);
            }
            if (sequence.active)
            {
                if (sequence.t > 0f)
                {
                    float num = 0f;
                    float num2 = 0f;
                    float t = Mathf.Clamp01((Time.time - oscTime) / oscDuration);
                    MathExtensions.Oscillation(oscReduction, oscFrequency, oscSeed, t, out num, out num2);
                    icon.rectTransform.localScale = new Vector3(1f + num * oscScale, 1f + num2 * oscScale, 1f);
                }
                sequence.Update();
            }
            SetAlpha(sequence.target ? 1f : sequence.t);
            show = false;
        }

        private void SetAlpha(float alpha)
        {
            icon.SetAlpha(alpha, alpha, alpha);
        }

        public void Show()
        {
            show = true;
        }
    }
}
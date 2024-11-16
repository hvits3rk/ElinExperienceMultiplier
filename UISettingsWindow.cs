using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ExperienceMultiplier;

public class LayerPluginConfig : ELayer
{
    public Slider sliderMaster;
    public Slider sliderBGM;
    public Slider sliderSFX;
    public Slider sliderAMB;
    public Slider sliderBrightness;
    public Slider sliderContrast;
    public Slider sliderSaturation;
    public Slider sliderVibrance;
    public Slider sliderScrollSense;
    public Slider sliderScale;
    public Slider sliderSharpen;
    public Slider sliderSharpen2;
    public Slider sliderBlur;
    public UISelectableGroup groupVSync;
    public UISelectableGroup groupLang;
    public UIButton toggleVsync;
    public UIButton toggleFixedResolution;
    public UIButton toggleOpenLastTab;
    public UIButton toggleRightClickClose;
    public UIButton toggleFullscreen;
    public UIButton togglePixelPerfectUI;
    public UIButton toggleBloom;
    public UIButton toggleHDR;
    public UIButton toggleBlur;
    public UIButton toggleAutoscale;
    public UIButton toggleDynamicBrightness;
    public UIButton toggleKuwahara;
    public UIButton toggleBlizzard;
    public UIButton toggleDisableShake;
    public UIButton toggleFirefly;
    public UIButton toggleSecureWidth;
    public UIButton toggleGradientWater;
    public UIButton toggleGodray;
    public UIButton toggleShowFloatButtons;
    public UIButton toggleAllyLight;
    public UIButton toggleBalloon;
    public UIItem fontUI;
    public UIItem fontChatbox;
    public UIItem fontBalloon;
    public UIItem fontDialog;
    public UIItem fontWidget;
    public UIItem fontNews;
    public UIDropdown ddPostEffect;
    public UIButton buttonReset;
    public Slider sliderUIBrightness;
    public Slider sliderUIContrast;
    public Slider sliderBalloon;
    public LayoutGroup layoutLanguage;
    public UIButton moldLanguage;
    public UIButton buttonApplyScreenSize;
    public InputField inputW;
    public InputField inputH;

    public override string GetTextHeader(Window window)
    {
        return "_configOf".lang(base.GetTextHeader(window));
    }

    public override void OnBeforeAddLayer()
    {
        windows[0].setting.tabs[5].disable = !core.config.other.showTestOptions;
    }

    public override void OnInit()
    {
        inputW.text = config.graphic.w.ToString();
        inputH.text = config.graphic.h.ToString();
        config.graphic.fullScreen = Screen.fullScreen;
        windows[0].AddBottomSpace();
        buttonReset = windows[0].AddBottomButton("", (UnityAction)(() =>
            Dialog.YesNo("dialogResetConfigTab".lang(windows[0].CurrentTab.idLang.lang()), (Action)(() =>
            {
                Close();
                if (windows[0].idTab == 0)
                    CoreConfig.ResetGeneral();
                else if (windows[0].idTab == 1)
                    CoreConfig.ResetGraphics();
                else if (windows[0].idTab == 2)
                    CoreConfig.ResetGame();
                else if (windows[0].idTab == 3)
                    CoreConfig.ResetInput();
                else if (windows[0].idTab == 4)
                    CoreConfig.ResetOther();
                else
                    CoreConfig.ResetTest();
                ui.AddLayer<LayerConfig>();
            }))));
        windows[0].AddBottomButton("resetConfig", (UnityAction)(() => Dialog.YesNo("dialogResetConfig",
            (Action)(() =>
            {
                Close();
                CoreConfig.Reset();
                ui.AddLayer<LayerConfig>();
            }))));
        ddPostEffect.SetList(config.graphic.idPostProfile,
            Resources.LoadAll<PostEffectProfile>(
                    "Scene/Profile/PostEffect/").Where((Func<PostEffectProfile, bool>)(p => !p.disable))
                .ToList(), (Func<PostEffectProfile, int, string>)((a, b) => a.name),
            (Action<int, PostEffectProfile>)((a, b) =>
            {
                config.graphic.idPostProfile = b.name;
                b.OnChangeProfile();
                sliderSharpen.value = config.graphic.sharpen;
                sliderSharpen2.value = config.graphic.sharpen2;
                sliderBlur.value = config.graphic.blur;
                toggleKuwahara.SetCheck(config.graphic.kuwahara);
                config.ApplyGrading();
            }), false);
        Refresh();
    }

    public override void OnSwitchContent(Window window)
    {
        buttonReset.mainText.SetText("resetConfigTab".lang(windows[0].CurrentTab.idLang.lang()));
        windows[0].rectBottom.RebuildLayout(true);
        windows[0].CurrentContent.RebuildLayout(true);
    }

    private void Update()
    {
        if (inputW.isFocused || inputH.isFocused)
            return;
        ValidateResolution();
    }

    public void ValidateResolution()
    {
        int num1 = Mathf.Clamp(inputW.text.ToInt(), 800, Display.main.systemWidth);
        int num2 = Mathf.Clamp(inputH.text.ToInt(), 600, Display.main.systemHeight);
        inputW.text = num1.ToString() ?? "";
        inputH.text = num2.ToString() ?? "";
        core.config.graphic.w = inputW.text.ToInt();
        core.config.graphic.h = inputH.text.ToInt();
    }

    public override void OnKill()
    {
        core.config.graphic.w = inputW.text.ToInt();
        core.config.graphic.h = inputH.text.ToInt();
        core.config.Save();
        core.config.Apply();
    }

    public void Refresh()
    {
        config.ignoreApply = true;
        SetSlider(sliderMaster, config.sound.volumeMaster, a =>
        {
            config.sound.volumeMaster = a;
            config.ApplyVolume();
            return Lang.Get("MASTER") + "(" + ((int)(a * 100.0)) + "%)";
        });
        SetSlider(sliderBGM, config.sound.volumeBGM, a =>
        {
            config.sound.volumeBGM = a;
            config.ApplyVolume();
            return Lang.Get("BGM") + "(" + ((int)(a * 100.0)) + "%)";
        });
        SetSlider(sliderSFX, config.sound.volumeSFX, a =>
        {
            config.sound.volumeSFX = a;
            config.ApplyVolume();
            return Lang.Get("SFX") + "(" + ((int)(a * 100.0)) + "%)";
        });
        SetSlider(sliderAMB, config.sound.volumeAMB, (Func<float, string>)(a =>
        {
            config.sound.volumeAMB = a;
            config.ApplyVolume();
            return Lang.Get("AMB") + "(" + ((int)(a * 100.0)) + "%)";
        }));
        SetSlider(sliderBrightness, config.graphic.brightness, (Func<float, string>)(a =>
        {
            config.graphic.brightness = a;
            config.ApplyGrading();
            return Lang.Get("brightness") + "(" + ((int)(a * 100.0)) + "%)";
        }));
        SetSlider(sliderContrast, config.graphic.contrast, (Func<float, string>)(a =>
        {
            config.graphic.contrast = a;
            config.ApplyGrading();
            return Lang.Get("contrast") + "(" + ((int)(a * 100.0)) + "%)";
        }));
        SetSlider(sliderSaturation, config.graphic.saturation, (Func<float, string>)(a =>
        {
            config.graphic.saturation = a;
            config.ApplyGrading();
            return Lang.Get("saturation") + "(" + ((int)(a * 100.0)) + "%)";
        }));
        SetSlider(sliderVibrance, config.graphic.vibrance, (Func<float, string>)(a =>
        {
            config.graphic.vibrance = a;
            config.ApplyGrading();
            return Lang.Get("vibrance") + "(" + ((int)(a * 100.0)) + "%)";
        }));
        SetSlider(sliderSharpen, config.graphic.sharpen, (Func<float, string>)(a =>
        {
            config.graphic.sharpen = (int)a;
            config.ApplyGrading();
            return Lang.Get("sharpen") + "(" + ((int)a) + "%)";
        }));
        SetSlider(sliderSharpen2, config.graphic.sharpen2, (Func<float, string>)(a =>
        {
            config.graphic.sharpen2 = (int)a;
            config.ApplyGrading();
            return Lang.Get("sharpen2") + "(" + ((int)a) + "%)";
        }));
        SetSlider(sliderBlur, config.graphic.blur, (Func<float, string>)(a =>
        {
            config.graphic.blur = (int)a;
            config.ApplyGrading();
            return Lang.Get("blur") + "(" + ((int)a) + "%)";
        }));
        SetSlider(sliderScrollSense, config.ui.scrollSens, (Func<float, string>)(a =>
        {
            config.ui.scrollSens = a;
            UIScrollView.sensitivity = config.ui.ScrollSensitivity;
            return Lang.Get("scrollSens") + "(" + ((int)(a * 100.0)) + ")";
        }));
        SetSlider(sliderScale, config.ui.scale, (Func<float, string>)(a =>
        {
            config.ui.scale = (int)a;
            config.ApplyScale();
            core.OnChangeResolution();
            return Lang.Get("uiScale") + "(" + (a * 5f) + "%)";
        }));
        SetSlider(sliderUIBrightness, config.ui.brightness, (Func<float, string>)(a =>
        {
            config.ui.brightness = (int)a;
            config.ApplyGrading();
            return Lang.Get("uiBrightness") + "(" + a + "%)";
        }));
        SetSlider(sliderUIContrast, config.ui.contrast, (Func<float, string>)(a =>
        {
            config.ui.contrast = (int)a;
            config.ApplyGrading();
            return Lang.Get("uiContrast") + "(" + a + "%)";
        }));
        SetSlider(sliderBalloon, config.ui.outlineAlpha, (Func<float, string>)(a =>
        {
            config.ui.outlineAlpha = (int)a;
            config.Apply();
            return Lang.Get("outlineAlpha") + "(" + a + "%)";
        }));
        SetGroup(groupVSync, config.graphic.fps, (UnityAction<int>)(a =>
        {
            config.graphic.fps = a;
            config.Apply();
        }));
        if (!(bool)(Object)moldLanguage)
            moldLanguage = layoutLanguage.CreateMold<UIButton>();
        layoutLanguage.DestroyChildren();
        int num = 0;
        List<LangSetting> list = new List<LangSetting>();
        foreach (LangSetting langSetting in MOD.langs.Values)
        {
            Util.Instantiate(moldLanguage, layoutLanguage).mainText.text =
                langSetting.name + "(" + langSetting.name_en + ")";
            if (config.lang == langSetting.id)
                num = list.Count;
            list.Add(langSetting);
        }

        layoutLanguage.RebuildLayout();
        SetGroup(groupLang, num, (UnityAction<int>)(a =>
        {
            if (!(config.lang != list[a].id))
                return;
            config.lang = list[a].id;
            core.SetLang(config.lang);
            Close();
            foreach (IChangeLanguage componentsInChild in ui.GetComponentsInChildren<IChangeLanguage>())
                componentsInChild.OnChangeLanguage();
            ui.AddLayer<LayerConfig>();
            Dialog.Ok("dialogChangeLang");
            config.Save();
        }));
        toggleGradientWater.SetToggle(config.graphic.gradientWater, (Action<bool>)(on =>
        {
            config.graphic.gradientWater = on;
            scene.ApplyZoneConfig();
        }));
        toggleVsync.SetToggle(config.graphic.vsync, (Action<bool>)(on =>
        {
            config.graphic.vsync = on;
            config.Apply();
        }));
        toggleAutoscale.SetToggle(config.ui.autoscale, (Action<bool>)(on =>
        {
            config.ui.autoscale = on;
            core.OnChangeResolution();
            config.ApplyScale();
        }));
        toggleOpenLastTab.SetToggle(config.ui.openLastTab, (Action<bool>)(on =>
        {
            config.ui.openLastTab = on;
            config.Apply();
        }));
        toggleBalloon.SetToggle(config.ui.balloonBG, (Action<bool>)(on =>
        {
            config.ui.balloonBG = on;
            config.Apply();
        }));
        toggleRightClickClose.SetToggle(config.ui.rightClickClose, (Action<bool>)(on =>
        {
            config.ui.rightClickClose = on;
            config.Apply();
        }));
        toggleFullscreen.SetToggle(config.graphic.fullScreen, (Action<bool>)(on =>
        {
            config.graphic.fullScreen = on;
            config.Apply();
        }));
        togglePixelPerfectUI.SetToggle(config.graphic.pixelperfectUI, (Action<bool>)(on =>
        {
            config.graphic.pixelperfectUI = on;
            config.Apply();
        }));
        toggleFixedResolution.SetToggle(config.graphic.fixedResolution, (Action<bool>)(on =>
        {
            config.graphic.fixedResolution = on;
            config.Apply();
        }));
        toggleBloom.SetToggle(config.graphic.bloom, (Action<bool>)(on =>
        {
            config.graphic.bloom = on;
            config.Apply();
        }));
        toggleHDR.SetToggle(config.graphic.hdr, (Action<bool>)(on =>
        {
            config.graphic.hdr = on;
            config.Apply();
        }));
        toggleKuwahara.SetToggle(config.graphic.kuwahara, (Action<bool>)(on =>
        {
            config.graphic.kuwahara = on;
            config.ApplyGrading();
        }));
        toggleDisableShake.SetToggle(config.graphic.disableShake,
            (Action<bool>)(on => config.graphic.disableShake = on));
        toggleFirefly.SetToggle(config.graphic.firefly, (Action<bool>)(on =>
        {
            config.graphic.firefly = on;
            screen.RefreshSky();
        }));
        toggleGodray.SetToggle(config.graphic.godray, (Action<bool>)(on =>
        {
            config.graphic.godray = on;
            screen.RefreshSky();
        }));
        toggleBlizzard.SetToggle(config.graphic.blizzard, (Action<bool>)(on =>
        {
            config.graphic.blizzard = on;
            screen.RefreshSky();
        }));
        toggleAllyLight.SetToggle(config.graphic.drawAllyLight, (Action<bool>)(on =>
        {
            config.graphic.drawAllyLight = on;
            if (!core.IsGameStarted)
                return;
            _map.RefreshFOVAll();
        }));
        toggleBlur.SetToggle(config.ui.blur, (Action<bool>)(on => config.ui.blur = on));
        toggleDynamicBrightness.SetToggle(config.ui.dynamicBrightness, (Action<bool>)(on =>
        {
            config.ui.dynamicBrightness = on;
            config.RefreshUIBrightness();
        }));
        toggleSecureWidth.SetToggle(config.ui.secureMinWidth,
            (Action<bool>)(on => config.ui.secureMinWidth = on));
        toggleShowFloatButtons.SetToggle(config.ui.showFloatButtons,
            (Action<bool>)(on => config.ui.showFloatButtons = on));
        buttonApplyScreenSize.SetOnClick((Action)(() =>
        {
            ValidateResolution();
            config.ApplyResolution(true);
        }));
        List<string> stringList1 = new List<string>
        {
            "none",
            "focus",
            "focusPause"
        };
        List<string> stringList2 = new List<string>
        {
            "ani0",
            "ani1",
            "ani2",
            "ani3",
            "ani4"
        };
        SetFont(config.font.fontUI, fontUI, "fontUI");
        SetFont(config.font.fontChatbox, fontChatbox, "fontChatbox");
        SetFont(config.font.fontBalloon, fontBalloon, "fontBalloon");
        SetFont(config.font.fontDialog, fontDialog, "fontDialog");
        SetFont(config.font.fontWidget, fontWidget, "widget");
        SetFont(config.font.fontNews, fontNews, "fontNews");
        config.ignoreApply = false;
    }

    public void SetFont(SkinManager.FontSaveData data, UIItem item, string lang)
    {
        item.text1.SetLang(lang);
        UIDropdown componentInChildren = item.GetComponentInChildren<UIDropdown>();
        UIButtonLR button1 = item.button1 as UIButtonLR;
        List<string> stringList = new List<string>
        {
            "sizeS",
            "sizeDefault",
            "sizeL",
            "sizeLL",
            "sizeLLL",
            "sizeLLLL"
        };
        SkinManager skins = ui.skins;
        int size = data.size;
        List<string> langs = stringList;
        Action<int> onSelect = i =>
        {
            data.size = i;
            ApplyFont();
        };
        button1.SetOptions(size, langs, onSelect, false);
        componentInChildren.options.Clear();
        for (int index = 0; index < skins.FontList.Count; ++index)
        {
            FontSource font = skins.FontList[index];
            componentInChildren.options.Add(new Dropdown.OptionData
            {
                text = font._name
            });
            if (index == data.index)
                componentInChildren.value = index;
        }

        componentInChildren.onValueChanged.RemoveAllListeners();
        componentInChildren.onValueChanged.AddListener((UnityAction<int>)(i =>
        {
            data.index = i;
            ApplyFont();
        }));
    }

    public void ApplyFont()
    {
        config.ApplyFont();
        this.RebuildLayout(true);
    }

    public void SetSlider(Slider slider, float value, Func<float, string> action, bool notify = false)
    {
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener((UnityAction<float>)(a =>
            slider.GetComponentInChildren<UIText>(true).text = action(a)));
        if (notify)
            slider.value = value;
        else
            slider.SetValueWithoutNotify(value);
        slider.GetComponentInChildren<UIText>(true).text = action(value);
    }

    public void SetGroup(UISelectableGroup group, int value, UnityAction<int> action)
    {
        group.Init(value, action);
    }
}
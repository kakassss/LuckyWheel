using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpinRewardsEditor : EditorWindow 
{
    private SpinRewardsDataSO _rewardsDataSo;

    private Vector2 scrollPos;
    
    private SerializedObject serializedRewardData;
    private SerializedProperty rewardsProperty;

    [MenuItem("Custom Editors/SpinRewards Editor")]
    public static void ShowWindow()
    {
        GetWindow<SpinRewardsEditor>("Spin Rewards Editor");
    }

    private void OnEnable()
    {
        _rewardsDataSo = AssetDatabase.LoadAssetAtPath<SpinRewardsDataSO>("Assets/Resources/SpinRewardsData.asset");
    }

    private void DrawTitle(string title)
    {
        GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
        titleStyle.fontSize = 14; 
        titleStyle.fontStyle = FontStyle.Bold;
        
        EditorGUILayout.LabelField(title, titleStyle);

        Rect rect = EditorGUILayout.GetControlRect(false, 2);
        EditorGUI.DrawRect(rect, Color.gray);
        GUILayout.Space(4);
    }
    private void DrawRewardList(string title, List<SpinRewardData> list)
    {
        DrawTitle(title);
        EditorGUILayout.Space(4);

        for (int i = 0; i < list.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");

            list[i].RewardName = EditorGUILayout.TextField("Reward Name", list[i].RewardName);
            list[i].Icon = (Sprite)EditorGUILayout.ObjectField("Icon", list[i].Icon, typeof(Sprite), false);
            
            list[i].HasAmount = EditorGUILayout.Toggle("Has Amount", list[i].HasAmount);
            
            if (list[i].HasAmount)
            {
                list[i].Amount = EditorGUILayout.IntField("Amount", list[i].Amount);
            }

            if (GUILayout.Button("Remove Reward", GUILayout.Width(110), GUILayout.Height(25)))
            {
                list.RemoveAt(i);
                EditorGUILayout.EndVertical();
                break;
            }

            EditorGUILayout.EndVertical();
        }

        if (list.Count != 8)
        {
            EditorGUILayout.HelpBox("Data should be 8 rewards.", MessageType.Error);
        }
        
        if (GUILayout.Button($"Add {title}"))
        {
            list.Add(new SpinRewardData());
        }
    }
    private void OnGUI()
    {
        _rewardsDataSo = (SpinRewardsDataSO)EditorGUILayout.ObjectField("Spin Rewards Data", _rewardsDataSo, typeof(SpinRewardsDataSO), false);

        if (_rewardsDataSo == null)
        {
            EditorGUILayout.HelpBox("Please select a SpinRewardsData asset to edit.", MessageType.Info);
            return;
        }
        
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        DrawRewardList("Bronze Spin Rewards", _rewardsDataSo._bronzeSpinRewards);
        EditorGUILayout.Space(10);
        DrawRewardList("Silver Spin Rewards", _rewardsDataSo._goldenSpinRewards);
        EditorGUILayout.Space(10);
        DrawRewardList("Golden Spin Rewards", _rewardsDataSo._silverSpinRewards);

        EditorGUILayout.EndScrollView();
        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(_rewardsDataSo);
        }
    }
}


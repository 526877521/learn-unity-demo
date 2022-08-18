// using System;
// using System.IO;
// using Unity.VisualScripting;
// using UnityEditor;
// using UnityEngine;


using System;
using System.IO;
using Data.EditorTool;
using UnityEditor;
using UnityEngine;

namespace Data
{
    public class ExcelBuild
    {
        
        [MenuItem("CustomEditor/CreateItemBase")]
        public static void CreateItemBase()
        {
            string sourceDirectory = ExcelConfig.newExcelsFolderPath;
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.xlsx");
            
                foreach (string currentFile in txtFiles)
                {
                    Debug.Log("string currentFile in txtFiles");
                   // string fileName= Path.GetFileNameWithoutExtension(currentFile);
                   // string fileNameAndExt= Path.GetFileName(currentFile);
                   ExcelTool.CreateBaseClassWithExcel(currentFile);
                   
                    // string fileName = currentFile.Substring(sourceDirectory.Length,currentFile.Length-5);
                    // Debug.Log("fileName="+fileName);
                    // Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
            
            
            // CreateClass.BuildClass("TestA",new []{"A","B","C"});
            // ItemManager manager = ScriptableObject.CreateInstance<ItemManager>();
            //赋值
             // manager.dataArray = ExcelTool.CreateItemArrayWithExcel(ExcelConfig.excelsFolderPath + "ItemType.xlsx");
             // ExcelTool.CreateObjDataWithExcel(ExcelConfig.excelsFolderPath + "ItemType.xlsx");
            // Debug.Log(manager.dataArray.Length);
            //确保文件夹存在
            // if (!Directory.Exists(ExcelConfig.assetPath))
            // {
            //     Directory.CreateDirectory(ExcelConfig.assetPath);
            // }
            //
            // //asset文件的路径 要以"Assets/..."开始，否则CreateAsset会报错
            // string assetPath = string.Format("{0}{1}.asset", ExcelConfig.assetPath, "Item");
            // //生成一个Asset文件
            // AssetDatabase.CreateAsset(manager, assetPath);
            // AssetDatabase.SaveAssets();
            // AssetDatabase.Refresh();

        }
        
        
        [MenuItem("CustomEditor/CreateItemAsset")]
        public static void CreateItemAsset()
        {
            string sourceDirectory = ExcelConfig.newExcelsFolderPath;
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.xlsx");
            
                foreach (string currentFile in txtFiles)
                {
                   // string fileName= Path.GetFileNameWithoutExtension(currentFile);
                   // string fileNameAndExt= Path.GetFileName(currentFile);
                   ExcelTool.CreateBaseDataWithExcel(currentFile);
                   
                    // string fileName = currentFile.Substring(sourceDirectory.Length,currentFile.Length-5);
                    // Debug.Log("fileName="+fileName);
                    // Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
            
            
            // CreateClass.BuildClass("TestA",new []{"A","B","C"});
            // ItemManager manager = ScriptableObject.CreateInstance<ItemManager>();
            //赋值
             // manager.dataArray = ExcelTool.CreateItemArrayWithExcel(ExcelConfig.excelsFolderPath + "ItemType.xlsx");
             // ExcelTool.CreateObjDataWithExcel(ExcelConfig.excelsFolderPath + "ItemType.xlsx");
            // Debug.Log(manager.dataArray.Length);
            //确保文件夹存在
            // if (!Directory.Exists(ExcelConfig.assetPath))
            // {
            //     Directory.CreateDirectory(ExcelConfig.assetPath);
            // }
            //
            // //asset文件的路径 要以"Assets/..."开始，否则CreateAsset会报错
            // string assetPath = string.Format("{0}{1}.asset", ExcelConfig.assetPath, "Item");
            // //生成一个Asset文件
            // AssetDatabase.CreateAsset(manager, assetPath);
            // AssetDatabase.SaveAssets();
            // AssetDatabase.Refresh();

        }
        
        
    }
}
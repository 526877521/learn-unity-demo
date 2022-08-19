
using System;
using System.IO;
using Data.EditorTool;
using UnityEditor;
using UnityEngine;
using XFramework.ExcelData.Editor;

namespace ExcelTool.EditorTool
{
    public class ExcelConvertTool
    {
        [MenuItem("Tools/Excel/Excel表转为Class")]
        public static void GenerateClass()
        {
            string excelPath = ExcelConfig.execlsFolderPath;
            if (!Directory.Exists(excelPath))
            {
                Directory.CreateDirectory(excelPath);
            }

            new ExcelConvertRequest().GenerateAllClass(excelPath);
        }


        [MenuItem("Tools/Excel/Excel表转为Asset")]
        public static void GenerateAsset()
        {
           
            string excelPath = ExcelConfig.execlsFolderPath;
            if (!Directory.Exists(excelPath))
            {
                Directory.CreateDirectory(excelPath);
            }

            new ExcelConvertRequest().GenerateAllAsset(excelPath);
        }


        [MenuItem("CustomEditor/CreateItemAsset")]
        public static void CreateItemAsset()
        {
            string sourceDirectory = ExcelConfig.execlsFolderPath;
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.xlsx");

                // foreach (string currentFile in txtFiles)
                // {
                //     // string fileName= Path.GetFileNameWithoutExtension(currentFile);
                //     // string fileNameAndExt= Path.GetFileName(currentFile);
                //     ExcelTool.CreateBaseDataWithExcel(currentFile);
                //
                //     // string fileName = currentFile.Substring(sourceDirectory.Length,currentFile.Length-5);
                //     // Debug.Log("fileName="+fileName);
                //     // Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
                // }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
        }
    }
}
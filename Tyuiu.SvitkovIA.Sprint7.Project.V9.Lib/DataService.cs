using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Tyuiu.SvitkovIA.Sprint7.Project.V9.Lib
{
    public class DataService
    {
        public string[,] LoadFromDataFile(string path)
        {
            string[] num = File.ReadAllLines(path, Encoding.GetEncoding(1251));
            int columns = num[0].Split(';').Length;
            int rows = num.Length;
            string[,] matrix = new string[rows, columns];
            for (int i = 0; i < num.Length; i++)
            {
                string numIndex = num[i];
                string[] numArray = numIndex.Split(';');
                for (int j = 0; j < numArray.Length; j++) matrix[i, j] = numArray[j];
            }
            return matrix;
        }
    }
}




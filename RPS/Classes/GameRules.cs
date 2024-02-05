using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Classes
{
    internal class GameRules
    {
        public readonly string[] gameValues;
        public readonly int valuesAmount;
        public GameRules(string[] GameValues) 
        {
            gameValues = GameValues;
            valuesAmount = gameValues.Length;
        }
        public void ShowGameValues()
        {
            for (int i = 0; i < valuesAmount; i++)
            {
                Console.WriteLine($"{i + 1} - {gameValues[i]}");
            }
        }
        public string GetGameValue(int idVal)
        {
            return gameValues[idVal];
        }
        public string GetGameResult(int playerMove, int pcMove)
        {
            if (playerMove < 0 || pcMove < 0 || playerMove >= valuesAmount || pcMove >= valuesAmount)
                throw new ArgumentException("Values must be positive and less than valuesAmount!");
            if (playerMove == pcMove)
                return "Draw";
            int dist = valuesAmount / 2;
            if ((playerMove - pcMove + valuesAmount) % valuesAmount <= dist)
                return "Win";
            return "Lose";
        }
        public void DrawHelpTable()
        {
            string[] headerVals = gameValues.Prepend("v PC\\User >").ToArray();
            TableGenerator tableGenerator = new TableGenerator();
            tableGenerator.FillHeader(headerVals);
            int count = valuesAmount;
            for (int i = 0; i < count; i++)
            {
                string[] row = new string[count + 1];
                row[0] = gameValues[i];
                for (int j = 0; j < count; j++)
                {
                    row[j + 1] = GetGameResult(j, i);
                }
                tableGenerator.AddRow(row);
            }
            tableGenerator.DrawTable();
        }
    }
}

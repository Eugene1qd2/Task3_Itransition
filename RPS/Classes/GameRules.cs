using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Classes
{
    internal class GameRules
    {
        public readonly string[] gameValues;
        public readonly int valuesAmount;
        private string[] GAME_RESULTS = { "Draw", "Win", "Lose" };
        public GameRules(string[] GameValues)
        {
            argsPrecheck(GameValues);
            gameValues = GameValues;
            valuesAmount = gameValues.Length;
        }
        private static void argsPrecheck(string[] args)
        {
            if (args.Length <= 1 || args.Length % 2 == 0)
            {
                throw new ArgumentException("Wrong params amount inputed!");
            }
            foreach (string arg in args)
            {
                if (args.Count(x => x == arg) > 1)
                {
                    throw new ArgumentException("Arguments should not be repeated!");
                }
            }
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
        public string GetGameResult(int playerMove, int computerMove)
        {
            if (playerMove < 0 || computerMove < 0 || playerMove >= valuesAmount || computerMove >= valuesAmount)
                throw new ArgumentException("Values must be positive and less than valuesAmount!");
            int dist = valuesAmount / 2;
            int result = (playerMove - computerMove + valuesAmount) % valuesAmount - dist+1;
            return GAME_RESULTS[result];
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

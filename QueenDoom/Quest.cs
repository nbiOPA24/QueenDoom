using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QueenDoom
{
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EndGoal { get; set; }
        public string Reward { get; set; }
        public bool IsCompleted { get; set; }

        public Quest(string name, string description, string endgoal, string reward)
        {
            Name = name;
            Description = description;
            EndGoal = endgoal;
            Reward = reward;
            IsCompleted = false;
        }

        public void QuestDoneOrNot(Player player, Enemy enemy, List<Item> inventory)
        {
            if (EndGoal == $"Defeat {enemy.Name}" && !enemy.IsAlive())
            {
                CheckQuest(player);
            }
        }
            private void CheckQuest(Player player)
            {
                Console.WriteLine($"Quest is Done: {Name} - {Reward}");
                IsCompleted = true;

            if (Reward.Contains("Health"))
            {
                player.Health += 20;
                if (player.Health > 100) player.Health = 100;
                Console.WriteLine($"{player.Name} You was rewarded 20 hp for Completed quest: {player.Health}");
                }
                }
    }
}

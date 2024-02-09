// Exceeding requirements:
// 1. Changed the implementation of goal storage: I chose an Dictionary (associated array) instead of a List. 
//      This gives us the opportunity to store several goals of the same type and access them not by index, but by key (goal name).
// 2. Added the opportunity to clear goal list and score.
// 3. Added User input validation while "Recording Event"
// 4. The goal selection menu for the recording only shows unfinished goals.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
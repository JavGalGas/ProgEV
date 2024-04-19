namespace rugby_JGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Match match1 = new Match();
            Character striker;
            Character defender;
            Character sp_defender;

            for (int i = 0; i < 4; i++)
            {
                striker = new Striker("Juan" + i);
                match1.characterList.Add(striker);
            }
            for (int i = 0; i < 4; i++)
            {
                striker = new Striker("Alberto" + i);
                match1.characterList.Add(striker);
            }
            for (int i = 0; i < 4; i++)
            {
                defender = new Defender("Álvaro" + i);
                match1.characterList.Add(defender);
            }
            for (int i = 0; i < 4; i++)
            {
                defender = new Defender("Roberto" + i);
                match1.characterList.Add(defender);
            }
            for (int i = 0; i < 2; i++)
            {
                sp_defender = new SpecialDefender("Alba" + i);
                match1.characterList.Add(sp_defender);
            }
            for (int i = 0; i < 2; i++)
            {
                sp_defender = new SpecialDefender("Juana" + i);
                match1.characterList.Add(sp_defender);
            }
            match1.Start();
            match1.Execute();

        }
    }
}
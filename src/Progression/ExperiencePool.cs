using System;

namespace Ares.Progression
{
    public class ExperiencePool
    {
        private const int Minimum = 0;

        public event EventHandler<Level>? LeveledUp;

        public Level Level { get; private set; }
        public int Points { get; private set; }

        public static int Maximum => ((int)Math.Pow(Level.Maximum, 2) + Level.Maximum) / 2 * 100 - (Level.Maximum * 100);

        public ExperiencePool(int points)
        {
            if (points < Minimum || points > Maximum)
                throw new ArgumentException($"{nameof(points)}:{points} is not within the range {Minimum} - {Maximum}.");

            (Points, Level) = (points, CalculateLevel(points));
        }

        public void Gain(int points)
        {
            if (points > Minimum)
            {
                Points = Points + points >= Maximum
                    ? Maximum
                    : Points + points;

                var level = CalculateLevel(Points);
                if (level.Value > Level.Value) LeveledUp?.Invoke(this, level);

                Level = level;
            }
            else throw new ArgumentException($"{nameof(points)}:{points} cannot be less than {Minimum}.");
        }

        private Level CalculateLevel(int experience) =>
            new Level((int)Math.Floor(Math.Sqrt(100 * (2 * experience + 25)) + 50) / 100);
    }
}
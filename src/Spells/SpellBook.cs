using System;
using System.Collections.Generic;
using System.Linq;

namespace Ares.Spells
{
    public class SpellBook
    {
        private readonly IList<Spell> spells;

        public IEnumerable<Spell> Spells => spells;

        public SpellBook() =>
            spells = new List<Spell>();

        public bool Contains(Spell spell) =>
            Spells.Contains(spell);

        public void Add(Spell spell)
        {
            if (!Contains(spell)) spells.Add(spell);
            else throw new InvalidOperationException($"{nameof(SpellBook)} already contains {nameof(Spell)}:{spell}.");
        }
    }
}
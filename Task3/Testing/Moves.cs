using FsCheck;

namespace Task3.Testing
{
    public static class MovesArbitrary
    {
        public static Arbitrary<Move> Move()
        {
            var genMove = from x in Arb.Generate<int>()
                          from y in Arb.Generate<int>()
                          from v in Arb.Generate<char>()
                          select new Move(x, y, v);

            return genMove.ToArbitrary();
        }
    }
}
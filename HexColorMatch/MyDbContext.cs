namespace HexColorMatch
{
    internal class MyDbContext : IDisposable
    {
        public MyDbContext()
        {
            HexColors = new List<HexColor>()
            {
                new HexColor("#6B8EAE", "antique blue"),
                new HexColor("#BDA999", "beige"),
                new HexColor("#000000", "black"),
                new HexColor("#7489A2", "blue"),
                new HexColor("#cfb59e", "Oak"),
                new HexColor("#DABC94", "brandy"),
                new HexColor("#4A3A30", "brown")
            };
        }

        public IList<HexColor> HexColors { get; }

        public void Dispose()
        {
        }
    }
}

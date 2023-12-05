namespace EverliteData
{
    class Planet
    {
        public string name { get; set; }
        public uint[] random { get; set; }
        public uint[] position { get; set; }
        public string inhabitans { get; set; }
        public string inhabitansname { get; set; }
        public string basespecies { get; set; }
        public bool humancolonists { get; set; }
        public string species { get; set; } 
        public uint government { get; set; }
        public uint[] economy { get; set; }
        public uint techlevel { get; set; }
        public uint population { get; set; }
        public uint productivity { get; set; }
        public uint planetradius { get; set; }
        public string planetarydescription { get; set; }
        public string governmentdescription { get; set; }
        public string economydescription { get; set; }
    }
}
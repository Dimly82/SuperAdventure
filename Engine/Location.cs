namespace Engine {
    public class Location {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Location(int id, string name, string description) {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
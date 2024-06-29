namespace CharacterClass
{
    public class HealthItem
    {

        private long _id;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _icon = string.Empty;
        private int _healthPointsCured;

        public long Id => _id;
        public string Name => _name;
        public string Description => _description;
        public string Icon => _icon;
        public int HealthPointsCured => _healthPointsCured;

        public HealthItem(long id, string name, string description, int healthPointsCured) 
        { 
            _id = id;
            _name = name;
            _description = description;
            _healthPointsCured = healthPointsCured;
        }

    }
}
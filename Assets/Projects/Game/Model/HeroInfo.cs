namespace Game.Model {
    public class HeroInfo {
        public readonly HeroType Type;
        public readonly AbilityType AbilityType;
        public readonly Price Price;
        public readonly int AbilityMaxUsages;

        public HeroInfo(HeroType type, AbilityType abilityType, Price price, int abilityUsages) {
            Type = type;
            AbilityType = abilityType;
            Price = price;
            AbilityMaxUsages = abilityUsages;
        }
    }
}
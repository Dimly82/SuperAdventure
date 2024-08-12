using System.Collections.Generic;

namespace Engine {
    public static class World {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static World() {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems() {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, Engine.World_PopulateItems_Rusty_sword, Engine.World_PopulateItems_Rusty_swords, 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, Engine.World_PopulateItems_Rat_tail, Engine.World_PopulateItems_Rat_tails));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, Engine.World_PopulateItems_Piece_of_fur, Engine.World_PopulateItems_Pieces_of_fur));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, Engine.World_PopulateItems_Snake_fang, Engine.World_PopulateItems_Snake_fangs));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, Engine.World_PopulateItems_Snakeskin, Engine.World_PopulateItems_Snakeskins));
            Items.Add(new Weapon(ITEM_ID_CLUB, Engine.World_PopulateItems_Club, Engine.World_PopulateItems_Clubs, 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, Engine.World_PopulateItems_Healing_potion, Engine.World_PopulateItems_Healing_potions, 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, Engine.World_PopulateItems_Spider_fang, Engine.World_PopulateItems_Spider_fangs));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, Engine.World_PopulateItems_Spider_silk, Engine.World_PopulateItems_Spider_silks));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, Engine.World_PopulateItems_Adventurer_pass, Engine.World_PopulateItems_Adventurer_passes));
        }

        private static void PopulateMonsters() {
            Monster rat = new Monster(MONSTER_ID_RAT, Engine.World_PopulateMonsters_Rat, 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemById(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemById(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, Engine.World_PopulateMonsters_Snake, 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemById(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemById(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, Engine.World_PopulateMonsters_Giant_spider, 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemById(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemById(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests() {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    Engine.World_PopulateQuests_Clear_the_alchemist_s_garden,
                    Engine.World_PopulateQuests_Clear_the_alchemist_s_garden_reward,
                    20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemById(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    Engine.World_PopulateQuests_Clear_the_farmer_s_field,
                    Engine.World_PopulateQuests_Clear_the_farmer_s_field_reward,
                    20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemById(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemById(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations() {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, Engine.World_PopulateLocations_Home,
                Engine.World_PopulateLocations_Home_description);

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, Engine.World_PopulateLocations_Town_square, Engine.World_PopulateLocations_Town_square_description);

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, Engine.World_PopulateLocations_Alchemist_s_hut,
                Engine.World_PopulateLocations_Alchemist_s_hut_description);
            alchemistHut.QuestAvailableHere = QuestById(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, Engine.World_PopulateLocations_Alchemist_s_garden,
                Engine.World_PopulateLocations_Alchemist_s_garden_description);
            alchemistsGarden.MonsterLivingHere = MonsterById(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, Engine.World_PopulateLocations_Farmhouse,
                Engine.World_PopulateLocations_Farmhouse_description);
            farmhouse.QuestAvailableHere = QuestById(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, Engine.World_PopulateLocations_Farmer_s_field,
                Engine.World_PopulateLocations_Farmer_s_field_description);
            farmersField.MonsterLivingHere = MonsterById(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, Engine.World_PopulateLocations_Guard_post,
                Engine.World_PopulateLocations_Guard_post_description, ItemById(ITEM_ID_ADVENTURER_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, Engine.World_PopulateLocations_Bridge, Engine.World_PopulateLocations_Bridge_description);

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, Engine.World_PopulateLocations_Forest,
                Engine.World_PopulateLocations_Forest_description);
            spiderField.MonsterLivingHere = MonsterById(MONSTER_ID_GIANT_SPIDER);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemById(int id) {
            foreach (Item item in Items)
                if (item.Id == id)
                    return item;
            return null;
        }

        public static Monster MonsterById(int id) {
            foreach (Monster monster in Monsters)
                if (monster.Id == id)
                    return monster;
            return null;
        }

        public static Quest QuestById(int id) {
            foreach (Quest quest in Quests)
                if (quest.Id == id)
                    return quest;
            return null;
        }

        public static Location LocationById(int id) {
            foreach (Location location in Locations)
                if (location.Id == id)
                    return location;
            return null;
        }
    }
}
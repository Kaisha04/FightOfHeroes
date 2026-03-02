⚔️ Fight Of Heroes
Fight Of Heroes is a console-based, turn-based combat game developed as a learning pet project. It features a strategic battle system where players can choose different hero classes, manage resources, and fight against a friend or an automated bot.

🎓 Learning Objectives & Achievements
Through this project, I have explored and implemented several core programming concepts in C#:

Object-Oriented Programming (OOP):

Inheritance & Abstraction: Created an abstract base class Hero to define common behaviors while allowing specific hero types (Paladin, Assassin, Mage, Vampire) to have unique attributes.

Interfaces: Implemented the IHeal interface to provide specific abilities to only certain hero classes, ensuring a flexible and decoupled design.

Encapsulation: Managed internal states like Health, Stamina, and Armor using properties with restricted access modifiers to maintain data integrity.

Game Logic & Mechanics:

Turn-Based Loop: Developed a GameLoop that handles player moves sequentially and checks for victory conditions.

Resource Management: Designed a stamina-based combat system where attacks and healing depend on the current stamina level.

Randomization: Used the Random class to create dynamic combat outcomes, including varied damage, armor block percentages, and stamina restoration.

Software Design Patterns:

Factory-like Pattern: Utilized the PlayerManager class to handle the creation of both human players and bots using switch expressions and enums.

Utility Classes: Built an InputHandler to centralize and validate user input, making the main code cleaner and more robust.

🛠 Features
Diverse Hero Classes: Choose from multiple classes, each with different starting stats and abilities.

PvP and PvE Modes: Play against another human locally or challenge a randomly generated bot.

Dynamic Combat: Manage your hero's stamina and armor to survive the battle.

Healing Mechanics: Specialized classes can sacrifice stamina to restore health.

🚀 Future Roadmap
Improve Bot AI to make decisions more strategically.

Rebalance the stamina system for more competitive gameplay.

Add more unique items and special abilities for each hero class.

# Guinevere Cranton’s Modular Game AI

## Abstract

For my project, I built an extensible modular AI system and implemented tactical position selection in it. I used the Unity Game Engine and its built in pathfinding so that I could focus on the higher-level decision making. As of submission time, my AI is capable of seeking out the player or good cover locations in order to preserve its life and attack the player. It uses a ranked utility system, and picks the best combination of actions for any given circumstance.


## Goals

I entered this project with the main goal of creating a robust framework – the actual demo was a secondary priority compared to the coding task of the underlying systems. I wanted to extend the tactical position selection algorithm described in the GameAIPro paper to all forms of action. In theory, my AI system should be capable of handling everything from conversational interactions to group tactical coordination without any changes to the central architecture.


## Implementation

My AI system is comprised of several base interfaces which serve as extensible abstractions. These are:



* Options
* Generators
* Conditions
* Evaluators
* The Option Chooser
* The AI itself


### Options

Options represent the different actions an AI can take. Each is tagged with an OptionTag that represents a mutually exclusive type of action. In my current implementation, there are only two OptionTags: Position and Action. Position is applied to any Option that moves the AI, while Action is applied to any Option that involves the Gun (Fire and Reload are two examples of Action-tagged Options). Each Option also has a list of Conditions and Evaluators used by the Option Chooser to eliminate and rank the generated options.


### Generators

Generators are all held by an AI Manager object in the game. They each return a list of Options, but do no evaluation on their own. The only parameter they take is a range; the AI can choose how far away it wants to plan. Currently the only two Generators used in my demo are the CoverPositionGenerator which scans the scene on startup and creates an Option for every placed cover point and the ShootingGenerator which is a simple holder for one of each option related to using a gun.


### Conditions

Conditions are any factor that eliminates an Option from consideration. Each Condition is initialized with the relevant information, and can have Check() called on it to return whether or not the condition is true. To reduce duplication, each Condition also has a boolean called ‘positive’ which effectively allows for the Condition to be used for two different circumstances. For example, an InRangeCondition checks whether or not the target is in range to be shot. If it is positive, it will eliminate the parent Option if the target is not in range. If it is negative, however, it will eliminate the Option if the target _is_ in range. This allows for great flexibility in how each Option can be evaluated.


### Evaluators

Evaluators are the utility functions used to rate Options. Like Conditions, they have a bool indicating whether high or low values are desirable (‘wantHigh’). They also each have a weight associated with them. When Evaluator.Evaluate() is called, they return a number from 0-1, multiplied by the associated weight.


### Option Chooser

The Option Chooser is a holder class for static functions used to rate and prune Options. PruneOptions() goes through the given list of options and removes any with even a single condition that returns false. RateOption does a weighted average of all the Evaluators on a single Object to return a value between 0 and 1. This ensures that all Options are easily compared, as they are all rated on the same scale no matter what. 


### AI Enemy

Every frame, the AI calls each of its currently selected Options’ Update() functions. If the Update function returns false, meaning it is no longer a relevant choice, or if a timer runs out, the AI chooses a new set of Options. 

When an AI wants to make a decision, it asks the AI Manager for a list of Options. It then asks the OptionChooser to prune that list, and then to rank it by each Option’s Evaluator average. Finally, it chooses the highest rated Options without mutually exclusive tags. This ensures a level of seeming intelligence without too much work. For instance, an AI can choose to go to cover while firing at the player, or chase a fleeing player while reloading. As the number of possible Option combinations increases, the AI’s tactical freedom increases exponentially.


## Postmortem

I am very happy with the final state of the framework itself. It is robust and functional, making creating new AI behavior simple and easy. However, my deprioritization of the actual demo has led to some disappointments. It is hard to tell just from watching exactly what any given AI enemy is doing, and the actual game implementation is lacking. Furthermore, there is one very major bug that I could not iron out in time for the project presentation.

The bug is in one specific Option’s Conditions: the CoverOption. For a reason I cannot figure out, the Condition that is supposed to ensure the AI doesn’t stay in ‘cover’ that doesn’t actually break line of sight to the player doesn’t work perfectly. It vastly diminishes the look and feel of the game if an Enemy supposedly hiding because it’s health is low stays in place as you round the corner and keep firing at it. From all my testing, I am certain the issue is not with the actual decision making logic. Rather, it is in my lack of understanding of the nuances of Unity’s Raycast system. The game, in certain circumstances, simply does not detect that the player has line of sight to the given position, and I did not have time to fully diagnose the issue.

With that major bug aside, I am actually quite impressed with the AI I made. While it sometimes stays in cover when it really shouldn’t, the decision to move to cover in the first place seems truly intelligent. It is ridiculously fun to have an AI charge you, shoot at it, and have it make at first a fighting retreat and then an all out panicked run to hide behind a wall from you. The OptionTag system enhances gameplay, as with the relatively small number of choices I gave the AI it can actually serve quite a challenge to fight.

With more time (and I very well might spend more time working on this in the future, just for fun) I believe I could have ironed out the bugs and made a fully competent functional AI Enemy from scratch. I want to implement Evaluators and Conditions that take into account what other AI are doing, and properly simulate team behavior. I am proud of the fact that such an addition would only entail tiny changes to my current system, requiring simply the creation of the new Evaluator or Condition and adding it to the list of others for the Option. If I build upon this in the future, it could become the foundation for a great game.


## Resources Used



* Unity Game Engine
    * NavMesh pathfinding tool
* [http://www.gameaipro.com/GameAIPro/GameAIPro_Chapter26_Tactical_Position_Selection.pdf](http://www.gameaipro.com/GameAIPro/GameAIPro_Chapter26_Tactical_Position_Selection.pdf)
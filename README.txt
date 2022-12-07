Game Submission
- Working Executable
[DONE] Win Loss Condition 

Object Pooling
[DONE] Object pooling was implemented to both the pellets and the ghosts. It uses a single class to handle the pooling behavior, but multiple instances of the class are created to handle the pooling of different objects. In the screenshot, I demonstrate that while the pellets use object pooling, the ghosts do not.  You can immediately notice the different in performance, identifying that the garbage collection values remain extremely low, even when collecting pellets, but whenever a ghost is instantiated into the scene, there is a relatively large spike in memory being allocated towards the instantiation of the ghost. 
- This demonstrates how useful Object Pooling is in a game like pacman, where both ghosts and pellets will be switched on and off regularly as opposed to being destroyed and reinstantiated.  This can save a lot of memory and improve the overall performance of the game itself.  

Command Pattern
[DONE] The command pattern was implemented into the game using three separate classes: the abstract Command class, the UndoCommand class which inherits from the Command class, and then finally the CommandInvoker class.  The Command class is an abstract class with only a single function: Invoke(); The UndoCommand inherits from the Command class, and overrides the Invoke function with its own functionality.  In this case, the UndoCommand holds a static list of GameObjects that is used to store the information of all the pellets collected by the player in order, so that the Invoke function can undo the last 7.  Two for loops are used to achieve this result: the first is responsible for how many pellets can be undone (in the case that there are not a full 7 pellets) as well as which ones they are.  The second loop re-enables these pellets and also removes them from the static list that tracks them.  
[DONE] This may be not only by the developer to test the systems of restoring the state of pellets, fruit, and enemies, but can also be permanently used by the game itself to restore the state of the game once a level is completed.  The command invoker does not have to rely on the player providing input for it to activate, but rather can use events to invoke a specific command, such as the previously mentioned completion of a level.  

Explanation of DLL or Management System
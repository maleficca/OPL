# OPL
On this repository you can find working code for every OPL instruction we'll be doing on classes. Please use it as a base and asset in creating your own code. Before you start working on it please read the notes below, as they contain useful information for understanding the instruction and the code itself.

# TEST_2
The BBP formula should always calculate the Pi value with higher accuracy. The most difficult part of this code is typing the long formula with many variables, so make sure you get that part right.

# TEST_3
The uploaded code is made using an old instruction where you have to declare a List and do operations on it. The new instruction includes only operations on previously declared array, so the List is not needed. The code needs some modifications in that case.

# TEST_4
The code in this instruction relies heavily on strings, so you absolutely mustn't copy it directly during class. That is because it contains many Console.WriteLine() instructions that display text in Console and make copies of the same code immediately visible. 

The instruction doesn't specify in what manner you should compare the two strings, so in the code you can find two kinds of comparison - one made by using String.Compare method (to "alphabetically" compare two strings) and the second using String.Length method comparing the length value of two strings. I assume that you can use either or both of them in your code, so you can decide by yourself which seems more appropriate.

# TEST_5
This program is kinda tricky, but once you understand it, you will get the general idea behind object programming. Think of 3 methods that are created at the start, as a "standalone" parts of code, made for one purpose (calculating sum, mean and displaying array values). The first two methods need a input variable (float[] tab) to run the calculations included in them. The 3rd method is a void type method, which means that it doesn't return any value like the previous ones.

It's always a good idea in programming to create parts of code like that, if you're going to need them many times in throught your program. Usually if you're constantly repeating the same instruction lines in your code, you're probably doing something wrong. This way the code is much more "cleaner" and the debugging process is easier.

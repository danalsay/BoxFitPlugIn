# BoxFitPlugIn
A Windows Forms Module Demonstrating 2d Best fit Algorithm utilizing Binary Tree 


Abstract: Develop rapidly a Plug-in that to optimize the packing of a multiple variant odd shaped product boxes, into a prescribed container dimensions. The solution can and should be open to enhancements or optimization

Discussion:  
Even though the problem describes a real life scenario of 3 dimensions, It is assumed that it can be reduced to 2 dimensional solution. Meaning that the boxes will not be stacked on top of one another.

This problem is often described as a 2 dimensional bin packing problem (2BP) and is classified as NP-hardness complexity with the complexity increasing with number of shapes, variety of shapes, and sizes, concave shapes, etc. As such, the approach is to try to solve for simpler scenario and adding complexity at later iterations.

For this initial approach we will assume the following:
1. The boxes cannot be rotated. 
This feature can later be added.	
2. The container shape will set initially based on set dimensions (based on boxes size)
	This can later be modified to be inputted by user
3.  The shapes will be set and part of plug-in start up
	This can be modified at a later time.
 4. The boxes will be fitted based on the rectangle formed from their widest width and height   
	 
The solution requires a fitting algorithm with heuristic approach (fast with best approximation for optimal solution). After considering different approaches of sorting and fitting the shapes, the approach that is offered here is of sorting and Binary Tree. 

The Binary tree fits the Largest Box based on its smallest possible rectangular ‘footprint’.
It then splits the remaining available space into a right Node and a Bottom node and attempts to fit next box into the right node and then bottom node. This is done recursively.

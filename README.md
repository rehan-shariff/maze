# Maze

## Table of Contents
1. [Objective](#objective)
2. [Build](#build)
3. [Run](#run)
4. [Contribute](#contribute)
6. [License](#license)

## Objective 

GIVEN a block of square rooms (X by Y) with an opening in the center of each wall

AND a laser which enters horizontally or vertically one of the outside openings in the outside walls

FIND the exit point of a laser and its final orientation after it has advanced through the maze

Some rooms have mirrors at a 45-degree angle. They can be oriented left or right. They can reflect on both sides or just one. When the laser hits a reflective side, the laser reflects at a 90 degree angle.

The block, the mirror positions and orientations, and laser starting position and orientation are provided as inputs via a text file.

The file format is:

~~~~
X,Y
-1
Mirrors
-1
Laser position and orientation
~~~~

*Note: See the [sample input file](https://github.com/rehan-shariff/maze/blob/master/sample_maze_input.txt)*

## Build

#### Visual Studio

1. Open Maze.sln in Visual Studio
2. Click on Build->Build All
3. Click on the Maze.UnitTests project
4. Click on Run->Run Unit Tests

*Note: This project was built using Visual Studio for Mac 2017 on macOS 10.13.3*

#### Travis CI

[![Build Status](https://travis-ci.com/rehan-shariff/maze.svg?branch=master)](https://travis-ci.com/rehan-shariff/maze)

## Run

You may use this [binary](https://github.com/rehan-shariff/maze/blob/master/bin/Release/Maze.exe). It was built using Visual Studio for Mac 2017 on macOS 10.13.3 and mono 5.10.1.57.

#### Usage

~~~~
Maze.exe input_file_path/input_file_name.txt
~~~~

#### Restrictions

1. X > 0 and Y > 0 (you must have at least 1 room!)
2. X < MAX_INT and Y < MAX_INT
3. The laser can only enter from a room on the outside
4. The laser can only enter from an outside opening in a room on the outside
5. If there are two parallel openings on the outside, the laser will enter from the opening closest to the left or bottom, depending on the laser orientation. (Imagine just 1 room where X = 1, Y = 1. This leads to a situation where the laser could enter from 4 openings. If the laser orientation is H, it will enter from the left opening. If the laser orientation is V, it will enter from the bottom opening.)
6. The file format must be followed exactly, so you cannot have unkown or extra characters

## Contribute

1. Add unit tests (must be TDD)
2. Follow [SOLID](http://butunclebob.com/ArticleS.UncleBob.PrinciplesOfOod) design principles
3. Verify the unit tests pass
4. Check your code for [smells](http://www.industriallogic.com/wp-content/uploads/2005/09/smellstorefactorings.pdf) and refactor
5. Comments are a code smell!
6. Update the [README](https://github.com/rehan-shariff/maze/blob/master/README.md) if relevant
7. Create a pull request

*Note: In the future, FXCop, StyleCop, OpenCover will be added

## License

The maze challenge is not my own, but the code is. Read the license.
